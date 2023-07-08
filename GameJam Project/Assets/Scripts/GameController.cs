using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public int lives = 0;
    public float timer = 0.1f;
    public TMP_Text scoreText, centerText;
    public int highScore;
    private string HIGHSCORE = "HS";
    bool beatHighScore = false;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);
        centerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt(HIGHSCORE, 0);
        timer += Time.deltaTime;
        scoreText.text = "SCORE : " + score;
        if (score > highScore)
        {
            highScore = score;
            beatHighScore = true;
            PlayerPrefs.SetInt(HIGHSCORE, highScore);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title Screen");
        }
    }

    void birdHitSound()
    {

    }

    void increaseScore()
    {
        score = score + 100;
    }

    void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu Systems");
    }

    public void GameOver()
    {
        if ( beatHighScore == true )
        {
            centerText.text =  "YOUR SCORE : " + score + " \n  HIGHEST SCORE :  " + highScore + ". \nDO YOU WANT TO TRY AGAIN?";
            buttons.SetActive(true);
            Invoke("PauseGame", 0.75f);
        }
        else
        {
            centerText.text = "YOUR SCORE : " + score + " \n  HIGHEST SCORE :  " + highScore + ". \nDO YOU WANT TO TRY AGAIN?";
            buttons.SetActive(true);
            Invoke("PauseGame", 0.75f);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void increaseLives()
    {
        lives = lives + 1;
    }

    public void decreaseLives()
    {
        lives = lives - 1;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
