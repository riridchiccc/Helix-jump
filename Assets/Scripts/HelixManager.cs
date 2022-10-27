using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringsDistance = 5;

    public int numberOfRings;
    public GameObject lastRing;
    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;//spawn additional 5 rings for every level

        for(int i = 0; i < numberOfRings; i++)
        {
            if (i == 0) //to make sure the first ring is the ring000 with all green cylinders to avoid the players death as soon as the game starts
                SpawnRing(0);
            else
            SpawnRing(Random.Range(1, helixRings.Length - 1)); //else spawn every other ring randomly
        }
            SpawnRing(helixRings.Length - 1); //spawning the last ring with the black cylinder signifying the end of the level
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity); //spawning the rings along the y-axis
        go.transform.parent = transform; //spawning the rings with the cylinders
        ySpawn -= ringsDistance; // to make sure the distance between the spawning of rings are equal
    }
}
