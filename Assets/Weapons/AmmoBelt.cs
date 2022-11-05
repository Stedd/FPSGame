using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public enum AmmoType
{
    [Description("1A")]
    CrossbowAmmo,
    [Description("5.56mm")]
    HandgunAmmo,
    [Description("9mm")]
    MachinegunAmmo,
    [Description("11.5mm")]
    RevolverAmmo,
}

public class AmmoBelt : MonoBehaviour
{
    [Serializable] private class AmmoSlot
    {
        [field: SerializeField] public AmmoType AmmoType { get; }
        [field: SerializeField] public int MaxBeltAmmoAmount { get; set; }
        [field: SerializeField] public int CurrentBeltAmmoAmount { get; set; }
    }

    [Header("State")]
    [SerializeField] private AmmoSlot[] _ammoSlots;
    [SerializeField] private FloatVariable _S_currentBeltAmmoAmount;

    [Header("State")]
    [SerializeField] private AmmoType _currentWeaponAmmoType;

    public AmmoType CurrentWeaponAmmoType
    {
        get => _currentWeaponAmmoType;
        set => _currentWeaponAmmoType = value;
    }

    private void Awake()
    {
        InitializeAmmoBelt();
    }

    private void InitializeAmmoBelt()
    {
        foreach (AmmoSlot ammoSlot in _ammoSlots)
        {
            ammoSlot.CurrentBeltAmmoAmount = ammoSlot.MaxBeltAmmoAmount;
        }
    }

    public int GetBeltCurrentAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).CurrentBeltAmmoAmount;
    }

    public int GetBeltMaxAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).MaxBeltAmmoAmount;
    }

    public void SetBeltCurrentAmmoAmount(AmmoType ammoType, int value)
    {
        var ammoSlot = GetAmmoSlot(ammoType);

        ammoSlot.CurrentBeltAmmoAmount = value;
        ammoSlot.CurrentBeltAmmoAmount =
            Mathf.Clamp(ammoSlot.CurrentBeltAmmoAmount, 0, ammoSlot.MaxBeltAmmoAmount);

        UpdateBeltAmmoUI(ammoSlot.AmmoType);
    }

    public void ModifyBeltCurrentAmmoAmount(AmmoType ammoType, int value)
    {
        var ammoSlot = GetAmmoSlot(ammoType);

        ammoSlot.CurrentBeltAmmoAmount += value;
        ammoSlot.CurrentBeltAmmoAmount =
            Mathf.Clamp(ammoSlot.CurrentBeltAmmoAmount, 0, ammoSlot.MaxBeltAmmoAmount);

        UpdateBeltAmmoUI(ammoSlot.AmmoType);
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        return _ammoSlots.FirstOrDefault(ammoSlot => ammoType == ammoSlot.AmmoType);
    }

    public void UpdateBeltAmmoUI(AmmoType ammoType)
    {
        if (_currentWeaponAmmoType == ammoType)
        {
            _S_currentBeltAmmoAmount.Value = GetBeltCurrentAmmoAmount(ammoType);
        }
    }
}