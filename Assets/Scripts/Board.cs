using UnityEngine;

public class Board : MonoBehaviour
{
    public Vector2 boardSize = new Vector2(10,10);

    [HideInInspector] public Vector3 bottomLeft;

    private void Awake() {
        bottomLeft = transform.position - new Vector3(boardSize.x, 0, boardSize.y) / 2f;
    }

    public Vector3 RandomPosition()
    {
        float x = Random.Range(bottomLeft.x, bottomLeft.x + boardSize.x);
        float z = Random.Range(bottomLeft.z, bottomLeft.z + boardSize.y);
        return new Vector3(x, transform.position.y, z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.2f, 0.3f, 1f, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(boardSize.x, 1, boardSize.y));
    }

}
