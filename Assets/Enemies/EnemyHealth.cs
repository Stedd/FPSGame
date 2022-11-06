using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private float _maxHealth = 100f;
    [Header("State")]
    [SerializeField] private float _health;
    [field: SerializeField] public bool IsDead { get; private set; }

    private void OnEnable()
    {
        IsDead = false;
        _health = _maxHealth;
    }

    public void ModifyHealth(float healthChange)
    {
        _health += healthChange;
        if (!(_health <= 0)) return;
        HandleDeath();
    }

    private void HandleDeath()
    {
        IsDead = true;
        print("Ded");
        //Destroy(gameObject);
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