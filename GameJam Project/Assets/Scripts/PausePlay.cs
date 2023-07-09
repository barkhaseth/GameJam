using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PausePlay : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject PauseButton;
    GameController gameController;

    bool GamePaused;


    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        if (GamePaused == false && gameController.GamePaused == false)
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void QuitGame()
    {
        GamePaused = false;
        SceneManager.LoadScene("Menu Systems");
    }
}