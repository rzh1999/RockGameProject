using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGame
{
    public class Simulation
    {
        
        public Human human = new Human();
        public Computer computer = new Computer();
        public Simulation()
        {

        }  

        public void RunSimulation()
        {
            int singleOrVersus = SinglePlayerOrVersus();
            SetPlayersUp(singleOrVersus);
            //Set players names
            //human.SetPlayersName();
            //int random = computer.GenerateRandomNumber();
            //computer.SetPlayersName(random);

            //Generate choice list
            List<String> choices = new List<String>();
            choices = GenerateListChoices();
            DisplayOptions(choices);


            Console.ReadLine();
        }

        public List<String> GenerateListChoices()
        {
            List<String> choices = new List<String>();
            string rock = "Rock";
            string scissors = "Scissors";
            string paper = "Paper";
            string lizzard = "Lizzard";
            string spock = "Spock";

            choices.Add(rock);
            choices.Add(scissors);
            choices.Add(paper);
            choices.Add(lizzard);
            choices.Add(spock);

            return choices;
        }

        public void DisplayOptions(List<String> choices)
        {
            int entryNumber = 1;

            Console.WriteLine($"Please enter a choice: ");

            foreach(String item in choices)
            {
                Console.WriteLine($" {entryNumber}: {item}");
                entryNumber++;

            }
        }
        
        public int SinglePlayerOrVersus()
        {
            Console.WriteLine($"Enter 1 for single player or 2 for multi-player: ");
            string userInput = Console.ReadLine();
            while(userInput != "1" && userInput != "2")
            {
                Console.WriteLine($"Enter 1 for single player or 2 for multi-player: ");
                userInput = Console.ReadLine();
            }

            return int.Parse(userInput);
        }

        public void SetPlayersUp(int players)
        {
            switch (players)
            {
                case 1:
                    human.SetPlayersName();
                    int random = computer.GenerateRandomNumber();
                    computer.SetPlayersName(random);
                    break;
                case 2:
                    human.SetPlayersName();
                    human.SetPlayersName();
                    break;
                default:
                    break;

            }
        }
    }
}
