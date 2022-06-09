using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private int X = default;
    private int Y = default;
    private int Z = default;

    private MeshRenderer rend;
    public void Init(Vector3 l_GridCoordinates)
    {
        X = (int)l_GridCoordinates.x;
        Y = (int)l_GridCoordinates.y;
        Z = (int)l_GridCoordinates.z;
        transform.position = l_GridCoordinates;
        rend = GetComponent<MeshRenderer>();
    }
}
