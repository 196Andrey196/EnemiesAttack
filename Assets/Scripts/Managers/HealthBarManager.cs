public class HealthBarManager
{
    public void TakeDamage(ref float curentHealth, float damageCost)
    {
        curentHealth -= damageCost;
    }
}
