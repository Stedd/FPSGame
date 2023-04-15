using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _weaponDamage = 25f;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _timeBetweenReloads;

    [Header("Connections")]
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _bulletImpact;
    [SerializeField] private Ammo _ammo;

    [Header("State")]
    [SerializeField] private int _index;
    [SerializeField] private bool _canShoot;

    private void Awake()
    {
        _canShoot = true;
        _fpCamera = FindObjectOfType<Camera>();
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        _ammo = GetComponent<Ammo>();
    }

    public int Index
    {
        get => _index;
        set => _index = value;
    }

    public void OnFire()
    {
        if (_canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public void OnReload()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _canShoot = false;
        print($"Reloading {gameObject.name}");
        _ammo.Reload();
        yield return new WaitForSeconds(_timeBetweenReloads);
        _canShoot = true;
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        if (_ammo.CurrentMagAmmoAmount > 0)
        {
            _ammo.ModifyMagAmmo(-1);
            Animation();
            ProcessHit();
        }

        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    private void Animation()
    {
        if (_muzzleFlash != null)
        {
            _muzzleFlash.Play();
        }
    }

    private void ProcessHit()
    {
        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out RaycastHit hit, _range))
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

        if (hit.transform.GetComponent<IAggroable>() != null)
        {
            hit.transform.GetComponent<IAggroable>().IsProvoked = true;
        }
    }

    private void ImpactAnimation(RaycastHit hit)
    {
        GameObject impactEffect = Instantiate(_bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, 1);
    }
}