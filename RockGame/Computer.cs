using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGame
{
    public class Computer : Player
    {
        public void SetPlayersName(int input)
        {
            //Create computer object since we are getting name
            Computer computer = new Computer();

            Console.WriteLine("Please enter one or more letters for the prefix name: ");
            string prefixName = Console.ReadLine();

            //Check wether a string is empty or a number
            int number;
            while (string.IsNullOrEmpty(prefixName) || int.TryParse(prefixName, out number))
            {
                Console.WriteLine($"Please enter one or more letters for the prefix name: ");
                prefixName = Console.ReadLine();
            }

            //Build string and set computers name
            computer.name = prefixName.ToUpper() +  input.ToString();
            Console.WriteLine($"Thank you, the computers name is {computer.name}");
        }

        public int GenerateRandomNumber()
        {
            Random random = new Random();

            //Generate and return a random 3 digit number
            return random.Next(100, 999);
        }
    }

    
}
