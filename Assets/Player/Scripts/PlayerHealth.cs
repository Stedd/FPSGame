using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private DeathHandler _deathHandler;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [field: SerializeField] private FloatVariable _S_currentHealth;

    private void Awake()
    {
        SetHealth(_maxHealth);
        UpdateUI();
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

        UpdateUI();
    }

    public void SetHealth(float newHealth)
    {
        _health = newHealth;
    }

    public void SetMaxHealth(float newHealth)
    {
        _maxHealth = newHealth;
    }

    private void UpdateUI()
    {
        _S_currentHealth.Value = GetHealthFactor() * 100;
    }
}