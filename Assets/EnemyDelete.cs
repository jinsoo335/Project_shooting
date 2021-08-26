using UnityEngine;

public class EnemyDelete : MonoBehaviour
{
    public Transform target;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        float distance = Vector3.Distance(transform.position, target.position);
        if(distance > 5)
        {
            Debug.Log("awwwww");
            Destroy(gameObject);
        }
    }
}
