using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy take;
    public Transform target;
    public Transform playerPos;
    public float bulletSpeed = 3f;
    public float bulletDamage = 10f;
    Collider2D[] cols;
    GameObject Enemy;

    void Start()
    {
        Invoke("DestroySelf", 5.0f);
    }
    private void Update()
    {
        //target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        //move();

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cols = Physics2D.OverlapCircleAll(playerPos.position, 10f);
        nearMove(cols);


    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void move()
    {
        Vector2 targetPos = new Vector2(target.position.x, target.position.y); 
        transform.position = Vector2.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);
    }
    public void nearMove(Collider2D[] cols)
    {
        if(cols.Length > 0)
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
            if (nearEnemy != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, nearEnemy.transform.position, bulletSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(bulletDamage);
            DestroySelf();
        }
    }

}
