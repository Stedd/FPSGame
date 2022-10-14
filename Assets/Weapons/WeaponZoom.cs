using System;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;

public class WeaponZoom : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float _fovNormal;
    [SerializeField] private float _fovZoom;
    [Header("State")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private bool _zoomedIn;

    private void OnEnable()
    {
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        Debug.Assert(_camera != null, nameof(_camera) + " != null");
        _fovNormal = _camera.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            _zoomedIn = !_zoomedIn;
        }

        if (_zoomedIn)
        {
            _camera.m_Lens.FieldOfView = _fovZoom;
        }
        else
        {
            _camera.m_Lens.FieldOfView = _fovNormal;
        }
    }
}