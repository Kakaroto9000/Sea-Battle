namespace SeaBattle
{
    internal class Game
    {
        public Player player1 = new Player();
        public Player player2 = new Player();
        public Arena arena1 = new Arena();
        public Arena arena2 = new Arena();
        public int GameType;
        public int StartRound()
        {
            GameType = ChosingTypeOfGame();
            PreGameSetup(GameType);
            while (player2.GameEndCheck(arena1) == false)
            {
                PlayerTurn(player1, arena1, arena2);
                if (player1.GameEndCheck(arena2) == true)
                    break;
                PlayerTurn(player2, arena2, arena1);
            }
            PostGame();
            if (player2.GameEndCheck(arena1) == false)
            {
                Console.WriteLine("Player 1 Win");
                return (1);
            }
            else
            {
                Console.WriteLine("Player 2 Win");
                return (2);
            }
        }
        private void PlayerTurn(Player player, Arena arena, Arena enemyarena)
        {
            player.TurnEnd = false;
            Console.Clear();
            ArenasReveal(arena);
            while (player.TurnEnd == false && player.GameEndCheck(enemyarena) == false)
            {
                player.Turn(arena, enemyarena);
                Console.Clear();
                arena.reveal(arena.arena);
                arena.reveal(arena.YourShoots);
            }
            if (player.IsBot == false)
            {
                Console.WriteLine("Press ENTER to end turn");
                Console.ReadLine();
            }
        }
        private void ArenasReveal(Arena arena)
        {
            if (GameType == 1)
            {
                Console.Clear();
                arena.reveal(arena.arena);
                arena.reveal(arena.YourShoots);
            }
            else if (GameType == 2)
            {
                arena1.reveal(arena1.arena);
                arena1.reveal(arena1.YourShoots);
            }
            else
            {
                arena1.reveal(arena1.arena);
                arena2.reveal(arena2.arena);
                Console.ReadLine();
            }
        }
        private void PreGameSetup(int gametype)
        {
            ArenasCreations(arena1);
            ArenasCreations(arena2);
            if (gametype == 2)
            {
                player2.IsBot = true;
            }
            else if (gametype == 3)
            {
                player1.IsBot = true;
                player2.IsBot = true;
            }
        }
        private void ArenasCreations(Arena arena)
        {
            arena.ArenaCreator(ref arena.arena);
            arena.ArenaCreator(ref arena.YourShoots);
            arena.ShipsCreator();
        }
        private void PostGame()
        {
            Console.Clear();
            Console.WriteLine("First Player Arena");
            arena1.reveal(arena1.arena);
            Console.WriteLine("Second Player Arena");
            arena2.reveal(arena2.arena);
        }
        private int ChosingTypeOfGame()
        {
            Console.WriteLine("Choose game type");
            Console.WriteLine("Press 1 to choose Player vs Player");
            Console.WriteLine("Press 2 to choose Player vs AI");
            Console.WriteLine("Press 3 to choose AI vs AI");
            string Input = Console.ReadLine();
            int Result;
            while (!int.TryParse(Input, out Result) && Result < 4 && Result > 0)
            {
                Console.WriteLine("Write Number Of Matches");
                Input = Console.ReadLine();
            }
            return Result;
        }
    }
}
