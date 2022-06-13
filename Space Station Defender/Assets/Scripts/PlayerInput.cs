using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> m_CameraMove = new UnityEvent<Vector2>();
    [SerializeField] private UnityEvent<float> m_CameraRotate = new UnityEvent<float>();
    [SerializeField] private InputAction Action = default;

    private PlayerMap m_InputMap;
    


    private void Awake()
    {
        m_InputMap = new PlayerMap();
    }

    private void OnEnable()
    {
        m_InputMap.Camera.Enable();
    }
    private void OnDisable()
    {
        m_InputMap.Camera.Disable();
    }
    private void Update()
    {
        Vector2 l_MoveValue = m_InputMap.Camera.Move.ReadValue<Vector2>();
        m_CameraMove.Invoke(l_MoveValue);

        float l_Rotate = m_InputMap.Camera.Rotation.ReadValue<float>();
        m_CameraRotate.Invoke(l_Rotate);
    }
}