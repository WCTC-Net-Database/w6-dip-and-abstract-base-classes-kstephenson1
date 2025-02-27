namespace W6_assignment_template.Models
{
    public class Player : CharacterBase
    {
        public int Gold { get; set; }

        public Player(string name, string type, int level, int hp, int gold)
            : base(name, type, level, hp)
        {
            Gold = gold;
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }
    }
}
