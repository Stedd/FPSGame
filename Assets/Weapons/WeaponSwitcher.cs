using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon[] _weapons;

    [Header("State")]
    [SerializeField] private int _currentWeapon;

    private void OnEnable()
    {
        _weapons = GetComponentsInChildren<Weapon>();
        var i = 0;
        foreach (Weapon weapon in _weapons)
        {
            weapon.Index = i;
            i++;
        }

        _currentWeapon = 0;
        SelectWeapon(_currentWeapon);
    }

    private void SelectWeapon(int index)
    {
        foreach (Weapon weapon in _weapons)
        {
            if (weapon.Index == _currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
        }
    }

    private void DeselectAllWeapons()
    {
        foreach (Weapon weapon in _weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            _currentWeapon += 1;
            if (_currentWeapon > _weapons.Length - 1)
            {
                _currentWeapon = 0;
            }

            DeselectAllWeapons();
            SelectWeapon(_currentWeapon);
        }
    }
}