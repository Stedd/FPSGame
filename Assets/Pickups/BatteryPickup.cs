using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _pickupAmount;

    private void OnTriggerEnter(Collider other)
    {
        print("Battery Pickup" + other);
        var flashLight = other.GetComponentInChildren<FlashLight>();
        var amountBefore = flashLight.CurrentCharge;
        if (flashLight != null)
        {
            flashLight.ModifyCharge(_pickupAmount);
        }

        var amountAfter = flashLight.CurrentCharge;

        if (amountBefore != amountAfter)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}