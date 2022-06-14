using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_Target = default;
    [SerializeField] private float m_Distance = default;
    [SerializeField] private Vector2 m_MaxDistanceRange = default;
    [SerializeField] private float m_MoveSpeed = default;
    [SerializeField] private Vector3 m_Offset = default;

    private Vector3 m_MoveVecter = default;

    private void Update()
    {
        // move camera
        Vector3 l_Forword = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        m_Target.Translate(l_Forword * m_MoveVecter.y * m_MoveSpeed);
        Vector3 l_Left = new Vector3(transform.forward.z, 0, transform.forward.x * -1f).normalized;
        m_Target.Translate(l_Left * m_MoveVecter.x * m_MoveSpeed);
        transform.localPosition = m_Target.localPosition + m_Offset;

        // rotate camera
        Vector3 l_Diraction = m_Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(l_Diraction, Vector3.up);
    }
    public void Move(Vector2 l_MoveVecter)
    {
        m_MoveVecter = l_MoveVecter;
    }

    public void Zoom(float l_ZoomValue)
    {
        if ((l_ZoomValue > 0 && m_MaxDistanceRange.x < m_Offset.y))
        {
            m_Offset.y -= 1f;
        }
        else if (m_MaxDistanceRange.y > m_Offset.y)
        {
            m_Offset.y += 1f;
        }
    }
}
