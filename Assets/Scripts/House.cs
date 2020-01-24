using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int ore;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Worker player = other.GetComponent<Worker>();
            ore += player.oreCarrying;
            player.oreCarrying = 0;
            GetComponent<AudioSource>().Play();
        }
    }
}
