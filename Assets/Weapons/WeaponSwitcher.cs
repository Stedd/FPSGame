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
            weapon.gameObject.SetActive(false);
            if (weapon.Index == index)
            {
                weapon.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            _currentWeapon++;
            if (_currentWeapon > _weapons.Length - 1)
            {
                _currentWeapon = 0;
            }

            SelectWeapon(_currentWeapon);
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            _currentWeapon = 0;
            SelectWeapon(_currentWeapon);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            _currentWeapon = 1;
            SelectWeapon(_currentWeapon);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            _currentWeapon = 2;
            SelectWeapon(_currentWeapon);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            _currentWeapon = 3;
            SelectWeapon(_currentWeapon);
        }
    }
}