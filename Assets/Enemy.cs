using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 25.0f;
    public float enemy_speed = 0.015f;
    public int enemyExp = 1;

    void Update()
    {
        
    }

    void Die()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.levelUp(enemyExp);
        Destroy(gameObject);
    }

    public void TakeDamage(float damgae)
    {
        Debug.Log("Hit!");
        health -= damgae;

        if(health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            TakeDamage(10f);
        }
    }

}
