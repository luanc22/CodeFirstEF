using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Necessário para usar as identificações de Keys
using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new GameContext())
            {
                // Cria um novo jogo
                Console.Write("Enter a name for a new game: ");
                var name = Console.ReadLine();

                var game = new Game { Name = name };
                db.Games.Add(game);
                db.SaveChanges();

                Console.WriteLine();

                // Display all games from the database
                var query = from g in db.Games orderby g.Name select g;

                Console.WriteLine("All games in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine();

                Console.WriteLine("Press ENTER to exit.");
                Console.ReadKey();
            }
        }
    }

    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        // Alteração realizada para teste do add-migration
        public string GameType { get; set; }

        public virtual List<Player> Players { get; set; }
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }

    public class Enemy
    {
        // Define a Key no DB.
        [Key]
        public string Name { get; set; }
        public int HP { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Enemy> Enemies { get; set; }

        /*
         * Config com API Fluente
         * protected override void OnModelCreating(DbModelBuilder modelBuilder)
         * {
         *     modelBuilder.Entity<Enemy>().Property(e => e.HP).HasColumnName("Health_Points");
         * }
        */
    }
}