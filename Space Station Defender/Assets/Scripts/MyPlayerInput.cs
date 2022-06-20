using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Brijen.Singleton;

public class MyPlayerInput : Singleton<MyPlayerInput>
{
    public int go = 50;

    [HideInInspector] public UnityEvent<Vector2> OnPressMove = new UnityEvent<Vector2>();
    [HideInInspector] public UnityEvent<float> OnPressRotate = new UnityEvent<float>();
    [HideInInspector] public UnityEvent<float> OnTriggeredZoom = new UnityEvent<float>();

    private PlayerMap m_InputMap;

    protected override void Awake()
    {
        base.Awake();
        m_InputMap = new PlayerMap();
    }

    private void OnEnable()
    {
        m_InputMap.Camera.Enable();
        m_InputMap.Camera.Zoom.performed += ZoomInput;
    }
    private void OnDisable()
    {
        m_InputMap.Camera.Disable();
    }
    private void Update()
    {
        Vector2 l_MoveValue = m_InputMap.Camera.Move.ReadValue<Vector2>();
        OnPressMove.Invoke(l_MoveValue);

        float l_Rotate = m_InputMap.Camera.Rotation.ReadValue<float>();
        OnPressRotate.Invoke(l_Rotate);
    }

    public void ZoomInput(InputAction.CallbackContext context)
    {
        OnTriggeredZoom.Invoke(context.ReadValue<Vector2>().y);

    }
}
