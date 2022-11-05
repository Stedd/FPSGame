using System;
using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;

public class WeaponZoom : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float _fovNormal;
    [SerializeField] private float _senseNormal;
    [SerializeField] private float _fovZoom;
    [SerializeField] private float _senseZoom;
    [SerializeField] private StarterAssetsInputs _input;
    [Header("State")]
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private bool _zoomedIn;

    private void Awake()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        Debug.Assert(_camera != null, nameof(_camera) + " != null");
        _fovNormal = _camera.m_Lens.FieldOfView;
    }

    private void OnDisable()
    {
        ZoomOut();
        _zoomedIn = false;
    }

    private void Update()
    {
        if (!Mouse.current.rightButton.wasPressedThisFrame) return;
        _zoomedIn = !_zoomedIn;
        if (_zoomedIn)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        _input.MouseScale = _senseNormal;
        _camera.m_Lens.FieldOfView = _fovNormal;
    }

    private void ZoomIn()
    {
        _input.MouseScale = _senseZoom;
        _camera.m_Lens.FieldOfView = _fovZoom;
    }
}