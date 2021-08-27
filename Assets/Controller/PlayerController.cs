using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.01f;
    public GameObject BulletPrefab;

    public float visionOfPlayer = 10f;
    public float bulletSpawnSpeed = 2f;

    void Start()
    {
        StartCoroutine("shotBullet");
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-playerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -playerSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(playerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, playerSpeed, 0);
        }

    }


    IEnumerator shotBullet()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, visionOfPlayer);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Enemy"))
                {
                    GameObject bullet = Instantiate(BulletPrefab);
                    bullet.transform.position = transform.position;
                    break;
                    
                }
                
            }
            yield return new WaitForSeconds(bulletSpawnSpeed);
            StartCoroutine("shotBullet");
        }
        else
        {
            StartCoroutine("shotBullet");
        }
    }
}
