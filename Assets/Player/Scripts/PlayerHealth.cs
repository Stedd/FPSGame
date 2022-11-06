using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private DeathHandler _deathHandler;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    private void Awake()
    {
        SetHealth(_maxHealth);
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

    public bool IsProvoked { get; set; }

    public void ModifyHealth(float healthChange)
    {
        _health += healthChange;
        
        if (_health <= 0)
        {
            _health = 0;
            _deathHandler.HandleDeath();
        }
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