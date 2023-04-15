using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int _pickupAmount;

    private void OnTriggerEnter(Collider other)
    {
        print("Battery Pickup" + other);
        var flashLight = other.GetComponentInChildren<FlashLight>();
        float amountBefore = flashLight.CurrentCharge;
        if (flashLight != null)
        {
            flashLight.ModifyCharge(_pickupAmount);
        }

        float amountAfter = flashLight.CurrentCharge;

        if (Mathf.Approximately(amountBefore, amountAfter))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}