using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject audioPlayer;
    public GameObject coinPrefab;
    public float coinSpawnInterval = 5f;
    public float coinLifetime = 10f;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;
    public int cloudMove;
    private bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("SpawnCoin", 2, 4);
        score = 0;
        cloudMove = 1;
        gameOver = false;
        AddScore(0);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }
    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;// Update the score with the earned points
        scoreText.text = "Score: " + score;
    }
    void SpawnCoin()
    {
        float x = Random.Range(-horizontalScreenSize * 0.9f, horizontalScreenSize * 0.9f);
        float y = Random.Range(-verticalScreenSize * 0.9f, verticalScreenSize * 0.9f);

        GameObject coin = Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);

        Destroy(coin, coinLifetime);
    }
    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
    public void GameOver()
    {
      gameOverText.SetActive(true);
      restartText.SetActive(true);
      gameOver = true; 
      CancelInvoke();
      cloudMove = 0;
    }
}
