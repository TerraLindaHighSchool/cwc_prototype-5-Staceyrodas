﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winnerText;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {

       

    }


    // Update is called once per frame
  
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets2.Count);
            Instantiate(targets2[index]);

            
        }
       
    }

     public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score >= 200)
        {
            Winner();
        }
    }

    public void Winner()
    {
        winnerText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }
    public void WinnerText()
    {
        if (score >= 200)
        {
            winnerText.gameObject.SetActive(true);
        }
    }


    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

        //If "Bomb" exits the game then continue game
        {
          
        }
        

        // if the winner text is active 
        {
            gameOverText.gameObject.SetActive(false);
        }

        // if the winner text is not active 
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    
    public void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // if the winner text is active 
        {
            gameOverText.gameObject.SetActive(false);
        }

        // if the winner text is not active 
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}

