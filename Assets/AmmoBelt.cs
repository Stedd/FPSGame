using System;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public enum AmmoType
{
    [Description("1A")]
    CrossbowBolt,
    [Description("5.56mm")]
    Five_FiveSix,
    [Description("9mm")]
    Nine,
    [Description("11.5mm")]
    Eleven_Five,
}

public class AmmoBelt : MonoBehaviour
{
    [Serializable] private class AmmoSlot
    {
        [field: SerializeField] public AmmoType AmmoType { get; set; }
        [field: SerializeField] public int MaxBeltAmmoAmount { get; set; }
        [field: SerializeField] public int CurrentBeltAmmoAmount { get; set; }
    }

    [SerializeField] private AmmoSlot[] _ammoSlots;

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
        return (from ammoSlot in _ammoSlots
                where ammoType == ammoSlot.AmmoType
                select ammoSlot.CurrentBeltAmmoAmount)
            .FirstOrDefault();
    }

    public int GetBeltMaxAmmoAmount(AmmoType ammoType)
    {
        return (from ammoSlot in _ammoSlots
                where ammoType == ammoSlot.AmmoType
                select ammoSlot.MaxBeltAmmoAmount)
            .FirstOrDefault();
    }

    public void SetBeltCurrentAmmoAmount(AmmoType ammoType, int value)
    {
        foreach (AmmoSlot ammoSlot in _ammoSlots)
        {
            if (ammoType == ammoSlot.AmmoType)
            {
                ammoSlot.CurrentBeltAmmoAmount = value;
            }
        }
    }

    public void ModifyBeltCurrentAmmoAmount(AmmoType ammoType, int value)
    {
        foreach (AmmoSlot ammoSlot in _ammoSlots)
        {
            if (ammoType == ammoSlot.AmmoType)
            {
                ammoSlot.CurrentBeltAmmoAmount += value;
            }
        }
    }
}