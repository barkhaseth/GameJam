using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirds : MonoBehaviour
{
    public GameObject bird1, bird2, bird3, heart, bomb;
    public int dice, birdNumber;
    public int diceMax;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 0 && timer <= 20)
        {
            diceMax = 100;
        }

        if (timer > 20 && timer <= 35)
        {
            diceMax = 90;
        }

        if (timer > 35 && timer <= 50)
        {
            diceMax = 80;
        }
        if (timer > 50 && timer <= 60)
        {
            diceMax = 70;
        }

        if (timer > 60)
        {
            diceMax = 60;
        }
        dice = Random.Range(1, diceMax);

        if (dice == 1 && Time.timeScale == 1)
        {
            float ySpawn = Random.Range(-3.5f, 4.0f);
            birdNumber = Random.Range(1, 6);

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
            if (birdNumber == 4)
            {
                Instantiate(heart, new Vector3(transform.position.x, ySpawn, 0), transform.rotation);
            }
            if (birdNumber == 5)
            {
                Instantiate(bomb, new Vector3(transform.position.x, ySpawn, 0), transform.rotation);
            }
            dice = 0;
        }
    }
}

