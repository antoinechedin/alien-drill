using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour
{
    public Worker player;
    public House house;

    Text playerText;
    Text houseText;

    private void Awake() {
        playerText = transform.GetChild(0).GetComponent<Text>();
        houseText = transform.GetChild(1).GetComponent<Text>();
    }

    private void Update() {
        if (player != null) playerText.text = "Red ore: " + player.oreCarrying + "/" + player.maxOre;
        if (house != null) houseText.text = "House ore: " + house.ore;
    }
}
