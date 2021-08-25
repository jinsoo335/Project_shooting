using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 25.0f;
    public float enemy_speed = 0.015f;
    Transform target = null;

    void Update()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void TakeDamage(float damgae)
    {
        health -= damgae;

        if(health <= 0)
        {
            Die();
        }
    }

}
