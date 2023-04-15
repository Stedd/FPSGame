using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private int _pickupAmount;

    private void OnTriggerEnter(Collider other)
    {
        var ammoBelt = other.GetComponentInChildren<AmmoBelt>();
        int amountBefore = ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);
        if (ammoBelt != null)
        {
            ammoBelt.ModifyBeltCurrentAmmoAmount(_ammoType, _pickupAmount);
        }

        int amountAfter = ammoBelt.GetBeltCurrentAmmoAmount(_ammoType);

        if (amountBefore != amountAfter)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}