using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    private void Awake()
    {
        SetHealth(_maxHealth);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Debug.Log($"{transform.name} Died");
        }
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetHealthFactor()
    {
        return _health / _maxHealth;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void ModifyHealth(float healthChange)
    {
        _health += healthChange;
    }

    public void SetHealth(float newHealth)
    {
        _health = newHealth;
    }

    public void SetMaxHealth(float newHealth)
    {
        _maxHealth = newHealth;
    }
}