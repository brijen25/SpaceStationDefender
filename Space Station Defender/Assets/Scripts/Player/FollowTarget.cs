using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private Vector3 m_CameraOffset;

    public void Init(Transform _target)
    {
        m_Target = _target;
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        transform.position = m_Target.transform.position + m_CameraOffset;
    }
}
