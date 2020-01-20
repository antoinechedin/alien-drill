using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0, 3)]
    public int id;
    public Board board;
    public bool controlWithCam;

    private void Update() {
        if (controlWithCam)
            transform.position = board.WebcamToWorld(board.webcamController.markerWrapPositions[id]);
    }
}
