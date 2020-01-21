using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public List<Rock> rockPrefab;
    public Board board;
    public float spawnDuration = 5f;
    public int maxNumOfRocks = 10;

    float timer;
    [HideInInspector] public List<Rock> rocks;

    private void Awake()
    {
        rocks = new List<Rock>();
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
                
                Vector3 pos = board.RandomPosition();
                StartCoroutine(FindObjectOfType<CameraShake>().Shake(0.15f, 0.1f));
                Rock rock = Instantiate(rockPrefab[(int)Random.Range(0, 4)], pos - Vector3.up * 5, Quaternion.Euler(0, Random.Range(0f, 360), 0f), transform).GetComponent<Rock>();
                rock.rockSpawner = this;
                rocks.Add(rock);

                if (rocks.Count >= maxNumOfRocks) timer = 0f;
            }
        }
    }
}
