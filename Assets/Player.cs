using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hp = 100f;
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
            Debug.Log("Level Up!");
            level++;
            levelCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10.0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        for(int i =0; i < 9; i++)
        {
            if(col.gameObject.CompareTag("Tile" + i))
            {
                col.gameObject.GetComponentInParent<LoopBackground>().tileMove(i);
            }
        }
    }

    void TakeDamage(float damage)
    {
        if(hp - damage <= 0)
        {
            Die();
        }
        else
        {
            hp -= damage;
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
