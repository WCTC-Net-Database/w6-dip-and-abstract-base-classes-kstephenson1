using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : CharacterBase, IFlyable
    {
        public string Treasure { get; set; }

        public Ghost(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }
    }
}
