using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    float attackDelay;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay < 0) attackDelay = 0;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        float distance = Vector3.Distance(transform.position, target.position);
        if (attackDelay == 0 && distance <= enemy.fieldOfVision)
        {
            MoveToTarget();
        }

    }
    void MoveToTarget()
    {
        transform.Translate(new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y) * enemy.speed * Time.deltaTime);
    }


}