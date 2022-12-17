using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCup : MonoBehaviour
{
    public GameObject groundGenerator;
    public AudioSource cupFX;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cup collected");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cup collected 2 ");
            cupFX.Play();
            groundGenerator.gameObject.GetComponent<GroundGenerator>().score  = groundGenerator.gameObject.GetComponent<GroundGenerator>().score * 2;
            this.gameObject.SetActive(false);
        }
    }
}
