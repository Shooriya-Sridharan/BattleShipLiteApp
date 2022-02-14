using BattleShipLibrary;
using System;
using System.Threading;

namespace BattleShipLite
{
    internal class Program
    {
        static string getName(string player)
        {
            Console.Write($"{player} name: ");
            return Console.ReadLine();
        }

        static void PlaceShips(PlayerModel currPlayer)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Where do you want to place your Ship {i + 1}: ");
                while (currPlayer.Place(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Invalid position or Already placed");
                    Console.Write($"Where do you want to place your Ship {i + 1}: ");
                }
            }
        }
        static void Main(string[] args)
        {
            PlayerModel p1 = new PlayerModel();
            PlayerModel p2 = new PlayerModel();


            p1.Name = getName("P1");
            PlaceShips(p1);
            p1.PrintPlacedShips();
            Thread.Sleep(2000);
            Console.Clear();

            p2.Name = getName("P2");
            PlaceShips(p2);
            p2.PrintPlacedShips();
            Thread.Sleep(2000);
            Console.Clear();




            p1.opponent = p2;
            p2.opponent = p1;
            bool p1Won = false;
            Shoot(p1, p2, out p1Won);
            if (p1Won)
            {
                Console.WriteLine($"Congrats {p1.Name} ");

            }
            else
            {
                Console.WriteLine($"Congrats {p2.Name} ");
            }
        }

        private static void Shoot(PlayerModel p1, PlayerModel p2, out bool p1Won)
        {
            p1Won = false;
            while (p1.HasGameWon() == false && p2.HasGameWon() == false)
            {

                Console.Write("P1 shoots: ");
                while (p1.Shoot(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Invalid position or Already shot");
                    Console.Write("P1 shoots: ");
                }
                Console.WriteLine();
                if (p1.HasGameWon())
                {
                    p1Won = true;
                    continue;
                }

                Console.Write("P2 shoots: ");
                while (p2.Shoot(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Invalid position or Already shot");
                    Console.Write("P2 shoots: ");
                }
                Console.WriteLine();
            }
            

        }
    }
}
