using w6_assignment_ksteph.Combat;

namespace w6_assignment_ksteph.Interfaces.CharacterBehaviors
{
    public interface ITargetable
    {
        // Interface tha allows units to be attacked.
        public void Damage(int damage);
        public void Heal(int damage);
        void OnHealthChanged();
        void OnDeath();
        bool IsDead();

    }
}
