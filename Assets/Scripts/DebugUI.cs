using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour
{
    public List<Worker> player;
    public List<House> house;
    public List<Text> playerText;
    public List<Text> houseText;
    public List<string> colorString;

    private void Update()
    {
        for(int i = 0; i < player.Count; i++)
        {
            if (player[i] != null)
                playerText[i].text = colorString[i] + " player ore: " + player[i].oreCarrying + "/" + player[i].maxOre;
            if (house[i] != null)
                houseText[i].text = colorString[i] + " house ore: " + house[i].ore;
        }  
    }
}
