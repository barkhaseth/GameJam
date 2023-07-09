using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankScript : MonoBehaviour
{
    public GameObject bird;
    public AudioSource shotgunSound;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.transform.position.x == 0 && count == 0)
        {
            Debug.Log("Play shotgun sound");
            shotgunSound.Play();
            count++;
        }
    }
}
