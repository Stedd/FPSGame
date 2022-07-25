using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FpCamera;
    [SerializeField] float _range = 100f;

    private void Awake()
    {
        _FpCamera = FindObjectOfType<Camera>();
    }

    public void OnFire()
    {
        print($"{gameObject.name} goes: Boom!");
        Shoot();
    }

    public void OnReload()
    {
        print($"Reloading {gameObject.name}");
    }

    private void Shoot()
    {
        Physics.Raycast(_FpCamera.transform.position, _FpCamera.transform.forward, out RaycastHit hit, _range);

        print($"{hit.transform.name} was hit!");
    }
}
