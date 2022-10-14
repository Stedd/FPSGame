interface IDamageable
{
    public void ModifyHealth(float healthChange);

    public void SetHealth(float newHealth);

    public void SetMaxHealth(float newHealth);

    public float GetHealth();

    public float GetMaxHealth();

    public float GetHealthFactor();
}