using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    public float xScreenHalfSize;
    public float yScreenHalfSize;
    public Transform playerPos;
    private float xSpawnPos;
    private float ySpawnPos;
    GameObject player;

    public GameObject EnemyPrefab;
    public GameObject ItemPrefab;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    

        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
        StartCoroutine("SpawnEnemyRandom");
        StartCoroutine("SpawnItemRandom");
    }


    IEnumerator SpawnEnemyRandom()
    {
        playerPos = player.GetComponent<Transform>();
       
        xSpawnPos = xScreenHalfSize + (playerPos.position.x + 1);
        ySpawnPos = yScreenHalfSize + (playerPos.position.y + 1);

        float xTemp = Random.Range(0.0f, xScreenHalfSize);
        float yTemp = Random.Range(0.0f, yScreenHalfSize);

        Random.Range(0.0f, xScreenHalfSize);

        switch (Random.Range(0, 4))
        {
            case 0:
                xSpawnPos = Random.Range(-xSpawnPos, xSpawnPos);
                //ySpawnPos = ySpawnPos;
                break;
            case 1:
                ySpawnPos = Random.Range(-ySpawnPos, ySpawnPos);
                //xSpawnPos = xSpawnPos;
                break;
            case 2:
                xSpawnPos = Random.Range(-xSpawnPos, xSpawnPos);
                ySpawnPos = -ySpawnPos;
                break;
            default:
                xSpawnPos = -xSpawnPos;
                ySpawnPos = Random.Range(-ySpawnPos, ySpawnPos);
                break;
        }
        GameObject enemy = Instantiate(EnemyPrefab);
        enemy.transform.position = new Vector3(xSpawnPos, ySpawnPos, 0);

        

        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnEnemyRandom");
    }

    IEnumerator SpawnItemRandom()
    {
        GameObject item = Instantiate(ItemPrefab);
        item.transform.position = new Vector3(Random.Range(-xScreenHalfSize, xScreenHalfSize) + playerPos.position.x, Random.Range(-yScreenHalfSize, yScreenHalfSize) + playerPos.position.y, 0);

        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnItemRandom");
    }



}
