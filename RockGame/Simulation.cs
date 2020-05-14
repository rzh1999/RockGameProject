using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGame
{
    public class Simulation
    {
        public Player player1;
        public Player player2;

        //public Human human = new Human();
        //public Computer computer = new Computer();
        Human human = new Human();
        Computer computer = new Computer();
        
        public Simulation()
        {

        }  

        public void RunSimulation()
        {
            int playType = PlayType();
            SetPlayersUp(playType);
            //Set players names
            //human.SetPlayersName();
            //int random = computer.GenerateRandomNumber();
            //computer.SetPlayersName(random);

            //Generate choice list
            List<String> choices = new List<String>();
            choices = GenerateListChoices();
            // DisplayOptions(choices);
            PlayGame(1, choices);

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

            //Console.WriteLine($"Please enter a choice: ");

            foreach(String item in choices)
            {
                Console.WriteLine($" {entryNumber}: {item}");
                entryNumber++;

            }
        }
        
        public int PlayType()
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
                    player1 = new Human();
                    player2 = new Computer();
                    player1.SetPlayersName();
                    //int random = computer.GenerateRandomNumber();
                    player2.SetPlayersName();
                    
                    break;
                case 2:
                    player1 = new Human();
                    player2 = new Human();
                    player1.SetPlayersName();
                    player2.SetPlayersName();
                    break;
                default:
                    break;

            }
        }

        public void PlayGame(int playType, List<String> choices)
        {
           
            MakeAChoice(player1, choices);
            MakeAChoice(player2, choices);

            // determine a winner
            //set winners score

        }

        public int IsAValidChoice(string choice, List<String> choices)
        {
           
            int choiceCount = choices.Count();
            int numChoice = int.Parse(choice);
            int zero = int.Parse("0");
            //Later on investigate this using recursion?
            while(numChoice <= zero || numChoice > choiceCount)
            {
                Console.WriteLine("Please selecet a valid choice");
                numChoice = int.Parse(Console.ReadLine());

            }
            return numChoice;
        }

        public void MakeAChoice(Player player, List<String> choices)
        {
            Console.WriteLine($"{player.name} select a choice: ");
            DisplayOptions(choices);
            string userInput = Console.ReadLine();
            int playerChoice = IsAValidChoice(userInput, choices);
        }
    }
}
