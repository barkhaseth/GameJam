using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Story : MonoBehaviour
{
    public AudioSource shotgunSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShotgunSound()
    {
        shotgunSound.Play();
    }

    public void skip()
    {
        SceneManager.LoadScene("Menu Systems");
    }

    public void story1()
    {
        SceneManager.LoadScene("Story1");
    }

    public void story2()
    {
        SceneManager.LoadScene("Story2");
    }

    public void story3()
    {
        SceneManager.LoadScene("Story3");
    }

    public void title()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void play()
    {
        SceneManager.LoadScene("SinglePlayer Test");
    }
}
