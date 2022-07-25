using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _FpCamera;
    [SerializeField] private ParticleSystem _MuzzleFlash;
    [SerializeField] private GameObject _BulletImpact;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _weaponDamage = 25f;

    private void Awake()
    {
        _FpCamera = FindObjectOfType<Camera>();
        _MuzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    public void OnFire()
    {
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
            //print($"{hit.transform.name} was hit!");
            ImpactAnimation(hit);
        }
        else
        {
            return;
        }

        if (hit.transform.GetComponent<IDamageable>() != null)
        {
            hit.transform.GetComponent<IDamageable>().ModifyHealth(-_weaponDamage);
        }

        if(hit.transform.GetComponent<EnemyAI>()!= null)
        {
            hit.transform.GetComponent<EnemyAI>().IsProvoked = true;
        }
    }

    private void ImpactAnimation(RaycastHit hit)
    {
        GameObject impactEffect = Instantiate(_BulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, 1);
    }
}
