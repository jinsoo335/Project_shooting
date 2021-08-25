using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100;
    private int exp = 0;
    private int level = 1;
    private int levelCount = 4;
    

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void levelUp(int expValue)
    {
        exp += expValue;
        if (exp % levelCount == 0)
        {
            level++;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10.0f);

        }
    }

    void TakeDamage(float damage)
    {
        hp -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
