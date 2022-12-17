using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            Debug.Log("Game Over");
        }
    }
}
