using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _fpCamera;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _bulletImpact;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _weaponDamage = 25f;

    private void Awake()
    {
        _fpCamera = FindObjectOfType<Camera>();
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
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
        _muzzleFlash.Play();
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