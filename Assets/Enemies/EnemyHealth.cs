using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHealth = 100f;
    [SerializeField] float _health ;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            print("Ded");
            Destroy(gameObject);
        }
    }

    public void ModifyHealth(float _healthChange)
    {
        _health += _healthChange;
    }

    public void SetHealth(float newHealth)
    {
        _health = newHealth;
    }

    public void SetMaxHealth(float newHealth)
    {
        _maxHealth = newHealth;
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public float GetHealthFactor()
    {
        return _health / _maxHealth;
    }

}
