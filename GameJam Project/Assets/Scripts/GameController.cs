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
    public TMP_Text scoreText, centerText, liveText;
    public int highScore;
    private string HIGHSCORE = "HS";
    bool beatHighScore = false;
    public GameObject buttons;
    public bool GamePaused;
    public AudioSource birdHitWallSound, birdHitSpikesSound, heartSound, loseLifeSound, bombSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);
        centerText.text = "";
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt(HIGHSCORE, 0);
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        scoreText.text = "COINS : " + score;
        liveText.text = "LIVES : " + lives;
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

    public void BirdHitWallSound()
    {
        birdHitWallSound.Play();
    }

    public void BombSound()
    {
        bombSound.Play();
    }

    public void HeartSound()
    {
        heartSound.Play();
    }

    public void BirdHitSpikesSound()
    {
        birdHitSpikesSound.Play();
    }

    public void LoseLifeSound()
    {
        loseLifeSound.Play();
    }

    public void increaseScore()
    {
        score = score + 100;
    }

    public void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Systems");
    }

    public void GameOver()
    {
        if ( beatHighScore == true )
        {
            centerText.text =  "YOUR SCORE : " + score + " \n  HIGHEST SCORE :  " + highScore + " \nDO YOU WANT TO TRY AGAIN?";
            buttons.SetActive(true);
            Invoke("PauseGame", 0.75f);
        }
        else
        {
            centerText.text = "YOUR SCORE : " + score + " \n  HIGHEST SCORE :  " + highScore + " \nDO YOU WANT TO TRY AGAIN?";
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
        if(lives<=10)
        {
            lives = lives + 1;
        }
    }

    public void decreaseLives()
    {
        if(lives>0)
        {
            lives = lives - 1;
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void PauseGame()
    {
        Debug.Log("game is paused");
        GamePaused = true;
    }
}
