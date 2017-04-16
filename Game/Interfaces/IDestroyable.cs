namespace Pokemon.Client.Interfaces
{
    interface IDamagable
    {
        int Health { get; set; }
        bool IsDefeated { get; set; }
        void TakeDamage(int damage);
    }
}
