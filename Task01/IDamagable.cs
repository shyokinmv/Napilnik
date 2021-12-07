namespace Task01
{
    interface IDamagable
    {
        bool IsAlive { get; }
        void TakeDamage(int damage);
    }
}
