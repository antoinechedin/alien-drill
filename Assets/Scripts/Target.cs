using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0, 3)]
    public int id;
    public Board board;

    private void Update() {
        transform.position = board.WebcamToWorld(board.webcamController.markerWrapPositions[id]);
    }
}
