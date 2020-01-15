using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public Board board;
    public float spawnDuration = 5f;
    public int maxNumOfRocks = 10;

    float timer;
    List<GameObject> rocks;

    private void Awake()
    {
        rocks = new List<GameObject>();
        timer = 0f;

        if (board == null)
        {
            board = GetComponent<Board>();
        }
    }

    private void Update()
    {
        if (rocks.Count < maxNumOfRocks)
        {
            timer += Time.deltaTime;
            if (timer > spawnDuration)
            {
                timer -= spawnDuration;
                GameObject rock = Instantiate(rockPrefab, board.RandomPosition(), Quaternion.Euler(0, Random.Range(0f, 360), 0f), transform);
                rocks.Add(rock);

                if (rocks.Count >= maxNumOfRocks) timer = 0f;
            }
        }
    }
}
