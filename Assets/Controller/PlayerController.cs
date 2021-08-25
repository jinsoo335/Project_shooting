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
        GameObject bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position;

        yield return new WaitForSeconds(4f);
        StartCoroutine("shotBullet");

    }


}
