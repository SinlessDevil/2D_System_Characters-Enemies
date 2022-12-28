namespace LiveSystem.HealthEntitySystem
{
    public sealed class HealthEnemy : HealthEntity
    {
        public override void Dead()
        {
            gameObject.SetActive(false);
        }
    }
}