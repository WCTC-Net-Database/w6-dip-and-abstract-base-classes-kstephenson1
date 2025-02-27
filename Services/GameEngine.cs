using W6_assignment_template.Data;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Player _player;
        private readonly Goblin _goblin;

        public GameEngine(IContext context)
        {
            _context = context;
            _player = context.Characters.OfType<Player>().FirstOrDefault();
            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
        }

        public void Run()
        {
            if (_player == null || _goblin == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            Console.WriteLine($"Player Gold: {_player.Gold}");

            _goblin.Move();
            _goblin.Attack(_player);

            _player.Move();
            _player.Attack(_goblin);

            Console.WriteLine($"Player Gold: {_player.Gold}");

            // Example CRUD operations for Goblin
            //var newGoblin = new Goblin("New Goblin", "Goblin", 1, 30, "None");
            //_context.AddCharacter(newGoblin);

            //newGoblin.Level = 2;
            //_context.UpdateCharacter(newGoblin);

            //_context.DeleteCharacter("New Goblin");
        }
    }
}
