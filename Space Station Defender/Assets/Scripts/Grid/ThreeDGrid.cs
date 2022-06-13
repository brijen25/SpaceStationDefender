using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDGrid : MonoBehaviour
{
    [SerializeField] private CellGenerator m_CellGenerator = default;
    [SerializeField] private Vector3 m_GridSize = default;

    private void Awake()
    {
        Init(m_GridSize);
    }

    private void Init(Vector3 l_gridSize)
    {
        for (int i = 0; i < l_gridSize.x; i++)
        {
            for (int j = 0; j < l_gridSize.y; j++)
            {
                for (int k = 0; k < l_gridSize.z; k++)
                {
                     m_CellGenerator.GetCell(new Vector3(i,j,k), transform);
                }
            }
        }
    }
}
