using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;
    public GameObject BulletPrefab;
    public float bulletSpeed = 0.02f;
    private Transform target;

    public Vector3 direction;
    public float velocity;
    public float accelaration;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        GameObject bullet = Instantiate(BulletPrefab);
        bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, target.position, 3.0f * Time.deltaTime);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }

        
    }



    void shotBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] cols = Physics2D.OverlapCircleAll(pos, 10.0f);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Enemy"))
                {
                    //Vector2 targetPos = new Vector2(cols[i].transform.position.x, cols[i].transform.position.y);
                    bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, target.position, 0.2f * Time.deltaTime);

                    break;
                }
                else
                {
                    target = null;
                }
            }
        }

    }


}
