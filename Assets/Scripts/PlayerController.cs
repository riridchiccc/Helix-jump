using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            //safe
            Debug.Log("safe");
        }

        else if (materialName == "Unsafe (Instance)")
        {
            //unsafe
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }

        else if (materialName == "Last Ring (Instance)" && !GameManager.levelCompleted)
        {
            //game won
           GameManager.levelCompleted = true;
            audioManager.Play("win");
        }
    }
}
