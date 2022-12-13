using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCup : MonoBehaviour
{
    public AudioSource cupFX;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cupFX.Play();
            this.gameObject.SetActive(false);
        }
    }
}
