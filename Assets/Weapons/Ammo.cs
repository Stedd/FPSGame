using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _ammoType;
    [SerializeField] private int _maxBeltAmmoAmount;
    [SerializeField] private int _maxMagAmmoAmount;

    [Header("State")]
    [SerializeField] private int _currentBeltAmmoAmount;
    [SerializeField] private int _currentMagAmmoAmount;

    [Header("Connections")]
    [SerializeField] private FloatVariable _S_currentBeltAmmoAmount;
    [SerializeField] private FloatVariable _S_currentMagAmmoAmount;

    private void OnEnable()
    {
        _currentBeltAmmoAmount = _maxBeltAmmoAmount;
        _currentMagAmmoAmount = _maxMagAmmoAmount;
    }

    #region Public Properties

    public int AmmoType
    {
        get => _ammoType;
        set => _ammoType = value;
    }

    public int MaxMagAmmoAmount
    {
        get => _maxMagAmmoAmount;
        set => _maxMagAmmoAmount = value;
    }

    public int CurrentMagAmmoAmount
    {
        get => _currentMagAmmoAmount;
        set => _currentMagAmmoAmount = value;
    }

    #endregion

    #region Setters

    public void Reload()
    {
        int diff = _maxMagAmmoAmount - _currentMagAmmoAmount;
        print(diff);
        if (diff < _currentBeltAmmoAmount)
        {
            _currentBeltAmmoAmount -= diff;
            _currentMagAmmoAmount += diff;
        }
        else
        {
            _currentMagAmmoAmount += _currentBeltAmmoAmount;
            _currentBeltAmmoAmount = 0;
        }

        AmmoUpdate();
    }

    public void ModifyMagAmmo(int modifyValue)
    {
        _currentMagAmmoAmount += modifyValue;
        if (_currentMagAmmoAmount > _maxMagAmmoAmount)
        {
            _currentMagAmmoAmount = _maxMagAmmoAmount;
        }

        if (_currentMagAmmoAmount <= 0)
        {
            _currentMagAmmoAmount = 0;
        }

        AmmoUpdate();
    }

    #endregion

    #region Getters

    public float GetMagazineAmmoFactor()
    {
        return _currentMagAmmoAmount / (float)_maxMagAmmoAmount;
    }

    public float GetBeltAmmoFactor()
    {
        return _currentBeltAmmoAmount / (float)_maxBeltAmmoAmount;
    }

    #endregion

    private void AmmoUpdate()
    {
        _S_currentBeltAmmoAmount.Value = _currentBeltAmmoAmount;
        _S_currentMagAmmoAmount.Value = _currentMagAmmoAmount;
    }
}