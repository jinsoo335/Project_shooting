using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public Transform playerPos;
    void Start()
    {
        Invoke("DestroySelf", 5.0f);
    }
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        move();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void move()
    {
        Vector2 targetPos = new Vector2(target.position.x, target.position.y); 
        transform.position = Vector2.MoveTowards(transform.position, targetPos, 1.2f * Time.deltaTime);

    }
}
