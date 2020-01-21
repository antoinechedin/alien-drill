using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartSpawner : MonoBehaviour
{
    public Minecart minecartPrefab;
    public GameObject railPrefab;
    public GameObject plankPrefab;

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

            for (int i = 0; i <= (minecartPositions[1] - minecartPositions[0]).magnitude+2; i++)
            {
                GameObject plank1 = Instantiate(plankPrefab, minecartPositions[0] -1f * (minecartPositions[1] - minecartPositions[0]).normalized + (minecartPositions[1] - minecartPositions[0]).normalized * i, Quaternion.identity);
                GameObject plank2 = Instantiate(plankPrefab, minecartPositions[0] -0.5f * (minecartPositions[1] - minecartPositions[0]).normalized + (minecartPositions[1] - minecartPositions[0]).normalized * i, Quaternion.identity);
                plank1.transform.LookAt(minecartPositions[1]);
                plank1.transform.localScale = new Vector3(1.5f, 2f, 2.7f);

                plank2.transform.LookAt(minecartPositions[1]);
                plank2.transform.localScale = new Vector3(1.5f, 2f, 2.7f);
            }

            GameObject go = Instantiate(railPrefab, minecartPositions[0] - 0.46f * (Vector3.Cross((minecartPositions[1] - minecartPositions[0]).normalized, Vector3.up)) - 1.5f * (minecartPositions[1] - minecartPositions[0]).normalized, Quaternion.identity);
            go.transform.LookAt(minecartPositions[1] - 0.46f * (Vector3.Cross((minecartPositions[1] - minecartPositions[0]).normalized, Vector3.up)));
            go.transform.localScale = new Vector3(1, 1, 1.5f*(minecartPositions[1] - minecartPositions[0]).magnitude + 4.5f);

            GameObject go2 = Instantiate(railPrefab, minecartPositions[0] + 0.46f * (Vector3.Cross((minecartPositions[1] - minecartPositions[0]).normalized, Vector3.up)) - 1.5f * (minecartPositions[1] - minecartPositions[0]).normalized, Quaternion.identity);
            go2.transform.LookAt(minecartPositions[1] + 0.46f * (Vector3.Cross((minecartPositions[1] - minecartPositions[0]).normalized, Vector3.up)));
            go2.transform.localScale = new Vector3(1, 1, 1.5f * (minecartPositions[1] - minecartPositions[0]).magnitude + 4.5f);

            minecart.target = minecartPositions[1] + new Vector3(0, 1.52f, 0);
            minecart.transform.LookAt(minecartPositions[1] + new Vector3(0, 1.52f, 0));
        }
    }
}
