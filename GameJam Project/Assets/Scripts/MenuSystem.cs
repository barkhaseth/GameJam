using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScene()
    {
        Debug.Log("playscene is being called");
        SceneManager.LoadScene("SinglePlayer Test");
    }

    public void GoBack()
    {
        Debug.Log("going back to title screen");
        SceneManager.LoadScene("Title Screen");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
