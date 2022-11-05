using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _pickupAmount;

    private void OnTriggerEnter(Collider other)
    {
        var ammoBelt = other.GetComponentInChildren<AmmoBelt>();
        var amountBefore = ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);
        if (ammoBelt != null)
        {
            ammoBelt.ModifyBeltCurrentAmmoAmount(_ammoType, _pickupAmount);
        }

        var amountAfter = ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);

        if (amountBefore != amountAfter)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}