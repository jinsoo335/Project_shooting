using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject cover;
    public GameObject scoreNum;
    public SpawnController spawnController;
    public PlayerController playerController;

    int score;
    TextMeshProUGUI scoreText;
    private void Start()
    {
        EventManager.EnemyDieEvent += OnEnemyDie;
        scoreText = scoreNum.GetComponent<TextMeshProUGUI>();
        Debug.Log(scoreText);
    }

    public void OnClickStartBtn()
    {
        cover.SetActive(false);
        spawnController.spawnRandom();
        playerController.bulletSpawn();
    }
    public void OnEnemyDie()
    {
        score++;
        if(scoreText != null)
        {
            scoreText.SetText("Score : {0}", score);
        }
        else
        {
            Debug.Log("null");
        }
    }

}
