using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSpawner : MonoBehaviour
{
    public GameObject bird1, bird2, bird3;
    public int dice, birdNumber;
    public int diceMax;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        diceMax = 700;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0 && timer <= 10)
        {
            diceMax = 1500;
        }
        

        if (timer > 10 && timer <= 20)
        {
            diceMax = 1400;
        }

        if (timer > 20 && timer <= 30)
        {
            diceMax = 1300;
        }
        if (timer > 30 && timer <= 40)
        {
            diceMax = 1200;
        }

        if (timer > 40 )
        {
            diceMax = 1100;
        }
        dice = Random.Range(1, diceMax);

        if (dice == 1 && Time.timeScale == 1)
        {
            float ySpawn = Random.Range(-3.3f, 3.3f);
            birdNumber = Random.Range(1, 4);

            if (birdNumber == 1)
            {
                Instantiate(bird1, new Vector3(transform.position.x, ySpawn, 0), transform.rotation);
            }

            if (birdNumber == 2)
            {
                Instantiate(bird2, new Vector3(transform.position.x, ySpawn, 0), transform.rotation);
            }
            if (birdNumber == 3)
            {
                Instantiate(bird3, new Vector3(transform.position.x, ySpawn, 0), transform.rotation);
            }
            dice = 0;
        }
    }
}
