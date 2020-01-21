﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Range(0, 3)]
    public int id;
    public float maxOre = 3;
    [HideInInspector] public float currentOre;
    [HideInInspector] public RockSpawner rockSpawner;

    private void Awake()
    {
        currentOre = maxOre;
        rockSpawner = FindObjectOfType<RockSpawner>();
    }

    private void OnDestroy()
    {
        rockSpawner.rocks.Remove(this);
    }
}
