using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    [SerializeField] private Cell m_CellPrefab = default;



    private void Awake()
    {
        
    }


    public Cell GetCell(Vector3 l_GridCoordinates, Transform l_GridParent)
    {
        Cell l_Cell = Instantiate(m_CellPrefab, l_GridParent);
        l_Cell.Init(l_GridCoordinates);
        return l_Cell;
    }

}
