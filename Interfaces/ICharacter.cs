namespace W6_assignment_template.Interfaces
{
    public interface ICharacter
    {
        void Attack(ICharacter target);
        void Move();
        string Name { get; set; }
    }

}
