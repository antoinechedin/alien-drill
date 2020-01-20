using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartSpawner : MonoBehaviour
{
    public Minecart minecartPrefab; 
    public Board board;
    public float spawnSpeed = 0.2f;
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f / spawnSpeed)
        {
            timer -= 1f / spawnSpeed;
            Vector3[] minecartPositions = board.RandomBorderPositions();
            Minecart minecart = Instantiate(minecartPrefab, minecartPositions[0] + new Vector3(0, 1.52f, 0), Quaternion.identity, transform);
            minecart.target = minecartPositions[1] + new Vector3(0, 1.52f, 0);
            minecart.transform.LookAt(minecartPositions[1] + new Vector3(0, 1.52f, 0));
        }
    }
}
