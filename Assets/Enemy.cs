using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject Player;
    public float health;
    public float damage;
    public float speed;
    public float fieldOfVision;
    public float atkRange;
    public int NowExp = 0;
    public int MaxExp = 10;
    int expValue = 0;

    protected Transform target = null;
    public Transform playerPos;
    Collider2D[] cols;
    public GameObject gogo;
    

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
        GameObject.Find("Player").GetComponent<Player>().levelUp(10);
        Debug.Log("다이");
        Destroy(gameObject);

    }

    public void TakeDamage(float damgae)
    {
        Debug.Log("Hit!");
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
    public void PlayerExp(int _PlusExp)
    {
        NowExp += _PlusExp;
        if (MaxExp <= NowExp)
        {
            Debug.Log("레벨업");
        }

    }
    public virtual void Move()
    {

    }


}