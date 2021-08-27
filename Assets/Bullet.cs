using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public float bulletDamage = 10f;

    private float fieldOfVision = 10f;
    private Transform playerPos;
    private Collider2D Enemy;
    private Vector3 lastEnemyPos;
    private bool targetLockOn;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Enemy = nearEnemySearch();
        lastEnemyPos = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y, 0);
        if (Enemy != null)
        {
            targetLockOn = true;
        }

        Invoke("DestroySelf", 5.0f);
    }
    private void Update()
    {
        if(Enemy == null)
        {
            targetLockOn = false;
        }
        
        if (targetLockOn)
        {
            try
            {
                moveBullet(Enemy);
            }
            catch(Exception ex)
            {
                targetLockOn = false;
            }
        }
        else
        {
            moveBullet(lastEnemyPos);
        }
        
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    public Collider2D nearEnemySearch()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(playerPos.position, fieldOfVision);

        if (cols.Length > 0)
        {
            float dis = 1000f;
            Collider2D nearEnemy = null;
            for(int i =0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Enemy"))
                {
                    float temp = Vector2.Distance(cols[i].GetComponent<Transform>().position, transform.position);
                    if(dis > temp)
                    {
                        dis = temp;
                        nearEnemy = cols[i];
                    }
                }
            }
            if(nearEnemy != null)
            {
                return nearEnemy;
            }

        }
        return null;
    }

    public void moveBullet(Collider2D enemy)
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, bulletSpeed * Time.deltaTime);
    }
    public void moveBullet(Vector3 enemy)
    {
        transform.Translate(enemy.normalized * bulletSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(bulletDamage);
            DestroySelf();
        }
    }

}
