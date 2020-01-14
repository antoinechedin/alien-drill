using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WebcamSettings : ScriptableObject
{
    [Range(0, 180)]
    public int lowerH = 0;
    [Range(0, 180)]
    public int higherH = 180;
    [Range(0, 255)]
    public int lowerS = 0;
    [Range(0, 255)]
    public int higherS = 255;
    [Range(0, 255)]
    public int lowerV = 0;
    [Range(0, 255)]
    public int higherV = 255;
}
