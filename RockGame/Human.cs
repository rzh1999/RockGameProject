using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGame
{
    public class Human : Player
    {
        

        public Human()
        {
            
            score = 0;
        }
        public void SetPlayersName()
        {
            //Create a human object sinc ewe are getting players name
            Human human = new Human();
            Console.WriteLine("Please enter the name for player 1: ");
            human.name = Console.ReadLine();

            //Check to make sure something is entered for name
            int number;
            while (string.IsNullOrEmpty(human.name) || int.TryParse(human.name, out number))
            {
                Console.WriteLine($"Player name cannot be empty. Please re-enter a name!");
                human.name = Console.ReadLine();
            }
            
        }

       
    }
}
