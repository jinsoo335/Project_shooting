using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemExp = 1;
    void Start()
    {
    }


    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().levelUp(itemExp);
            DestorySelf();
        }
        
    }
    void DestorySelf()
    {
        Destroy(gameObject);
    }
}
