using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;
    public GameObject BulletPrefab;
    public float bulletSpeed = 0.02f;
    public Transform target;

    void Start()
    {
        StartCoroutine("shotBullet");
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



    IEnumerator shotBullet()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 10f);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Enemy"))
                {
                    if (Vector3.Distance(cols[i].GetComponent<Transform>().position, transform.position) < 10f)
                    {
                        GameObject bullet = Instantiate(BulletPrefab);
                        bullet.transform.position = transform.position;
                        break;
                    } 
                }
                
            }
            yield return new WaitForSeconds(3f);
            StartCoroutine("shotBullet");
        }
        else
        {
            StartCoroutine("shotBullet");
        }

    }


}
