using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FpCamera;
    [SerializeField] ParticleSystem _MuzzleFlash;
    [SerializeField] float _range = 100f;
    [SerializeField] float _weaponDamage = 25f;

    private void Awake()
    {
        _FpCamera = FindObjectOfType<Camera>();
        _MuzzleFlash = GetComponentInChildren<ParticleSystem>();
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
        Animation();
        ProcessHit();

    }

    private void Animation()
    {
        _MuzzleFlash.Play();
    }

    private void ProcessHit()
    {
        if (Physics.Raycast(_FpCamera.transform.position, _FpCamera.transform.forward, out RaycastHit hit, _range))
        {
            print($"{hit.transform.name} was hit!");
        }
        else
        {
            return;
        }

        if (hit.transform.GetComponent<IDamageable>() != null)
        {
            hit.transform.GetComponent<IDamageable>().ModifyHealth(-_weaponDamage);
        }
    }
}
