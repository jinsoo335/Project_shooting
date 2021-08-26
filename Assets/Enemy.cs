using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float fieldOfVision;
    public float atkRange;
    protected Transform target = null;
    public Transform playerPos;
    Collider2D[] cols;

    private void SetEnemyStatus(float _health, float _damage, float _speed, float _atkRange, float _fieldOfVision)
    {
        health = _health;
        damage = _damage;
        speed = _speed;
        atkRange = _atkRange;
        fieldOfVision = _fieldOfVision;
    }

    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cols = Physics2D.OverlapCircleAll(playerPos.position, 10f);
        //Move();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damgae)
    {
        health -= damgae;

        if (health <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            //TakeDamage(10);
            collision.gameObject.SetActive(false);
        }
    }
    public virtual void Move()
    {

    }


}