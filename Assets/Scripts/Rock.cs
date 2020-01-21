using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float maxOre = 3;
    public Vector3 targetPos;
    public float speedLerp = 0.1f;

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

    void Update()
    {
        if (transform.position.y > targetPos.y) transform.position = targetPos;
        if (transform.position.y < targetPos.y) transform.position += speedLerp * Vector3.up;
    }
}
