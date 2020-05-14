using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGame
{
    public class Simulation
    {
        public string player1;
        public string player2;

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

            Console.WriteLine($"Please enter a choice: ");

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
                    human.SetPlayersName();
                    int random = computer.GenerateRandomNumber();
                    computer.SetPlayersName(random);
                    player1 = human.name;
                    player2 = computer.name;
                    break;
                case 2:
                    human.SetPlayersName();
                    human.SetPlayersName();
                    player1 = human.name;
                    player2 = human.name;
                    break;
                default:
                    break;

            }
        }

        public void PlayGame(int playType, List<String> choices)
        {
            //Set whos playing human vs human or human vs computer ie player 1 player 2
            //use a switch here because I expect to see more play types added

            //string player1="";
            //string player2="";
            //switch (playType)
            //{
            //    case 1:
            //        //Human vs Computer
            //        player1 = human.name;
            //        player2 = computer.name;
            //        break;
            //    case 2:
            //        player1 = human.name;
            //        player2 = otherHuman.name;
            //        break;
            //}

            //ask player1 to choose from list of choices
            //Console.WriteLine($"{player1} select a choice: ");
            //DisplayOptions(choices);
            //string userInputA = Console.ReadLine();
            //string player1Choice = IsAValidChoice(userInputA, choices);
            MakeAChoice(player1, choices);

            //ask player2 to choose from list of choices
            //Console.WriteLine($"{player2} select a choice: ");
            //DisplayOptions(choices);
            //string userInputB = Console.ReadLine();
            //string player2Choice = IsAValidChoice(userInputA, choices);
            MakeAChoice(player2, choices);

            // determine a winner
            //set winners score

        }

        public string IsAValidChoice(string choice, List<String> choices)
        {
            bool isOk = false;
            int choiceCount = choices.Count();
            int numChoice = int.Parse(choice);
            int zero = int.Parse("0");

            //Need to fix this logic its not working
            //Need to fix this logic its not working
            //Need to fix this logic its not working
            //Need to fix this logic its not working
            //Need to fix this logic its not working
            //Need to fix this logic its not working
            //Need to fix this logic its not working
            while(numChoice <= zero || numChoice > choiceCount)
            {
                Console.WriteLine("Please selecet a valid choice");
                choice = Console.ReadLine();

            }
            return choice;
        }

        public void MakeAChoice(string player, List<String> choices)
        {
            Console.WriteLine($"{player} select a choice: ");
            DisplayOptions(choices);
            string userInput = Console.ReadLine();
            string playerChoice = IsAValidChoice(userInput, choices);
        }
    }
}
