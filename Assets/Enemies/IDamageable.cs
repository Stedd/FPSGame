using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    public void ModifyHealth(float _healthChange);

    public void SetHealth(float newHealth);

    public void SetMaxHealth(float newHealth);

    public float GetHealth();

    public float GetMaxHealth();

    public float GetHealthFactor();
}
