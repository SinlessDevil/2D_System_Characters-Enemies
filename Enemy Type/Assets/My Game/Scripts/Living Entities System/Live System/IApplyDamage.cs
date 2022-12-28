namespace LiveSystem
{
    public interface IApplyDamage
    {
        void ApplyDamage(int damage);

        abstract void Dead();

    }
}