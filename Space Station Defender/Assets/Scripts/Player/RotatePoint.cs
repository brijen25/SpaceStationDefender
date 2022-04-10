using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    public LayerMask Ground;
    private Vector3 pointToPass;

    public Vector3 PointToPass
    {
        get {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f, Ground);

            return hit.point;
        }
    }

}
