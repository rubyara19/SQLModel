using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;




namespace _9_1
{

    [Table("SQLModels")]
    internal class Item
    {

        // values
        [Key]
        public string ItemNum { get; set;  }
        public string Description {  get; set; }
        public int OnHand { get; set; }
        public string Category { get; set; }
        public int Storehouse { get; set; }
        public double Price { get; set; }

        // constructor
        public Item(string itemNum, string description, int onHand, string category, int storehouse, double price)
        {
            ItemNum = itemNum;
            Description = description;
            OnHand  = onHand;
            Category = category;
            Storehouse = storehouse;
            Price = price;
        }

        public override string ToString()
        {
            return $"{ItemNum}\t{Description}\t{OnHand}\t{Category}\t{Storehouse}\t{Price}";
        }

    }

    internal class ItemDbContext : DbContext
    {
        static string sqlConnectionString = "Server=localhost\\sqlexpress;Database=SQLModels;Trusted_Connection=True;Encrypt=False";

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionString);
        }
    }

    internal class Program
    {

        private static void AddItems(ItemDbContext db)
        {
            db.Items.Add(new Item("AH74","Patience",9,"GME",3,22.99));
            db.Items.Add(new Item("BR23","Skittles",21,"GME",2,22.99));
            db.Items.Add(new Item("CD33","Wood Block Set (48 piece)", 36, "TOY", 1, 89.49));
            db.Items.Add(new Item("DL51","Classic Railway Set",12,"TOY",3,107.95));
            db.Items.Add(new Item("DR67","Giant Star Brain Teaser",24,"PZL",2,31.95));
            db.Items.Add(new Item("DW23","Mancala",40,"GME",3,50.00));
            db.Items.Add(new Item("FD11","Rocking Horse",8,"TOY",3,124.95));
            db.Items.Add(new Item("FH24","Puzzle Gift Set",65,"PZL",1,38.95));
            db.Items.Add(new Item("KA12","Cribbage Set",56,"GME",3,75.00));
            db.Items.Add(new Item("KD34","Pentominoes Brain Teaser",60,"PZL",2,14.95));
            db.Items.Add(new Item("KL78","Pick Up Sticks",110,"GME",3,75.00));
            db.Items.Add(new Item("MT03","Zauberkasten Brain Teaser",45,"PZL",1,45.79));
            db.Items.Add(new Item("NL89","Wood Block Set (62 Piece)",32,"TOY",3,119.75));
            db.Items.Add(new Item("TR40","Tic Tac Toe",75,"GME",2,13.99));
            db.Items.Add(new Item("TW35","Fire Engine",30,"TOY",2,118.95));

            db.SaveChanges();
            Console.WriteLine("Data Loaded Successfully.\n");

        }


        static void Main(string[] args)
        {
            using (ItemDbContext context = new ItemDbContext())
            {
                AddItems(context);
            }

                Console.WriteLine("Hello, World!");
        }
    }
}
