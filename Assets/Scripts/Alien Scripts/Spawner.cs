using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] alienReference;
    private GameObject spawnedAlien;

    private int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAliens());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAliens()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 7));

            randomIndex = Random.Range(0, alienReference.Length);

            spawnedAlien = Instantiate(alienReference[randomIndex]); // creates a copy

            if (randomIndex < 3)
            {
                spawnedAlien.transform.position = new Vector3(12f, Random.Range(-6f, 4f), -70f);
            }
            else
            {
                spawnedAlien.transform.position = transform.position;
            }
        }
    }
}

    // [SerializeField]
    // private GameObject[] monsterReference;

    // private GameObject spawnedMonster;

    // [SerializeField]
    // private Transform leftPos, rightPos;

    // private int randomIndex;
    // private int randomSide;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     StartCoroutine(SpawnMonsters());
    // }

    // IEnumerator SpawnMonsters()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(Random.Range(1, 5));

    //         randomIndex = Random.Range(0, monsterReference.Length);
    //         randomSide = Random.Range(0, 2);

    //         spawnedMonster = Instantiate(monsterReference[randomIndex]); // creates a copy

    //         if (randomSide == 0)
    //         {
    //             spawnedMonster.transform.position = leftPos.position;
    //             spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
    //         }
    //         else
    //         {
    //             spawnedMonster.transform.position = rightPos.position;
    //             spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
    //             spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
    //         }
    //     }
    // }
