﻿using System;
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
        public string resultSring;
        public List<String> choices = new List<String>();

        public Simulation()
        {

        }  

        public void RunSimulation()
        {
            int playType = PlayType();

            SetPlayersUp(playType);
            
            //Generate choice list
            //List<String> choices = new List<String>();
            choices = GenerateListChoices();

            // DisplayOptions(choices);
            
            while (player1.score < 3 && player2.score < 3)
            {
                Console.WriteLine($"Player ones score {player1.score}");
                PlayGame(1);
            }
            DisplayWinner();



            Console.ReadLine();
        }

        public List<String> GenerateListChoices()
        {
            //List<String> choices = new List<String>();
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

        public void DisplayOptions()
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

        public void PlayGame(int playType)
        {
           
            int player1Choice = MakeAChoice(player1, choices);
            int player2Choice = MakeAChoice(player2, choices);

            // determine a winner
            DetermineWinner(player1Choice, player2Choice);
           
            

        }

        public int IsAValidChoice(string choice)
        {
           
            int choiceCount = choices.Count();
            int numChoice =0;
            //Had to add this logic because the int.Parse fails on empty maybe use try
            if (string.IsNullOrEmpty(choice))
            {
                numChoice = 0;
            }
            else
            {
                
                numChoice = int.Parse(choice);
            }
            int zero = int.Parse("0");
            //Later on investigate this using recursion?
            while(numChoice <= zero || numChoice > choiceCount)
            {
                Console.WriteLine("Please selecet a valid choice");
                numChoice = int.Parse(Console.ReadLine());

            }
            return numChoice;
        }

        public int MakeAChoice(Player player, List<String> choices)
        {
            Console.WriteLine($"{player.name} select a choice: ");
            DisplayOptions();
            string userInput = Console.ReadLine();
            int playerChoice = IsAValidChoice(userInput);
            return playerChoice;
        }

        public void DetermineWinner(int player1Choice, int player2Choice)
        {
            //Return 1 for a winner 2 for no winner and 3 for a tie
            
            string resultString = "";
            //get each users "string" choice in the list
            //Since we know the index of th elist item we want use Item[int32] propertie of list so we dont have to llop through list to get values
            string player1Gesture = choices[player1Choice-1].ToLower();
            string player2Gesture = choices[player2Choice-1].ToLower();
            if (player1Gesture == player2Gesture) {
                resultString = "There was a Tie!!!";
            
                Console.WriteLine(resultSring);
            
            } //no winner
            switch (player1Gesture)
            {
                case "rock":
                    if (player2Gesture == "scissors" || player2Gesture == "lizzard") {
                       player1.score++;
                        if (player2Gesture == "scissors")
                        {
                            resultString = "Rock Crushes Scissors";
                            
                            
                        }
                        if (player2Gesture == "lizzard")
                        {
                            resultString = "Rock Crushes Lizzard";
                            

                        }
                      

                        DisplayMatchInfo(player1.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "paper"){
                        player2.score++;
                        resultString = "Paper Covers Rock";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "spock")
                    {
                        player2.score++;
                        resultString = "Spock Vaporizes Rock";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else {
                        resultString = "No Winner Try Again";
                      
                        Console.WriteLine(resultString);
                        break;
                    }

                case "scissors":
                    if (player2Gesture == "paper" || player2Gesture == "lizzard")
                    {
                        player1.score++;
                        if (player2Gesture == "paper")
                        {
                            resultString = "Scissors Cuts Paper";
                           
                        }
                        if (player2Gesture == "lizzard")
                        {
                            resultString = "Scissors Decapitates Lizzard";
                        }
                      
                        DisplayMatchInfo(player1.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "rock")
                    {
                        player2.score++;
                        resultString = "Rock Crushes Scissors";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "spock")
                    {
                        player2.score++;
                        resultString = "Spock Smashes Scissors";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else
                    {
                        resultString = "No Winner Try Again";
                      
                        break;
                    }
                case "paper":
                    if (player2Gesture == "rock" || player2Gesture == "spock")
                    {
                        player1.score++;
                        if (player2Gesture == "paper")
                        {
                            resultString = "Paper Covers Rock";
                        }
                        if (player2Gesture == "lizzard")
                        {
                            resultString = "Paper Disproves Spock";
                        }
                      
                        DisplayMatchInfo(player1.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "scissors")
                    {
                        player2.score++;
                        resultString = "Scissors Cuts Paper";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "lizzard")
                    {
                        player2.score++;
                        resultString = "Lizzard Eats Paper";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else
                    {
                        resultString = "No Winner Try Again";
                      
                        break;
                    }
                case "lizzard":
                    if (player2Gesture == "spock" || player2Gesture == "paper")
                    {
                        player1.score++;
                        if (player2Gesture == "spock")
                        {
                            resultString = "Lizzard Poisons Spock";
                        }
                        if (player2Gesture == "paper")
                        {
                            resultString = "Lizzard Eats Paper";
                        }
                      
                        DisplayMatchInfo(player1.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "rock")
                    {
                        player2.score++;
                        resultString = "Rock Crushes Lizzard";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "scissors")
                    {
                        player2.score++;
                        resultString = "Scissors Decapitates Lizzard";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else
                    {
                        resultString = "No Winner Try Again";
                      
                        break;
                    }
                case "spock":
                    if (player2Gesture == "scissors" || player2Gesture == "Rock")
                    {
                        player1.score++;
                        if (player2Gesture == "scissors")
                        {
                            resultString = "Spock Smashes Scissors";
                        }
                        if (player2Gesture == "Rock")
                        {
                            resultString = "Spock vaporizes Rock";
                        }
                      
                        DisplayMatchInfo(player1.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "lizzard")
                    {
                        player2.score++;
                        resultString = "Lizzard Poisons Spock";
                      
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else if (player2Gesture == "paper")
                    {
                        player2.score++;
                        resultString = "Paper Disproves Spock";
                        
                        DisplayMatchInfo(player2.name, resultString);
                        break;
                    }
                    else
                    {
                        resultString = "No Winner Try Again";
                        
                        break;
                    }
                default:
                    break;
            }
            
            
        }

        public void DisplayMatchInfo(string playerName, string resultString)
        {
            Console.WriteLine(resultSring);
            Console.WriteLine($"{playerName} wins!!");
        }

        public void DisplayWinner()
        {
            if (player1.score == 3 )
            {
                Console.WriteLine($"******CONGRATS {player1.name} HAS WON THE GAME");
            }
            if (player2.score == 3)
            {
                Console.WriteLine($"******CONGRATS {player2.name} HAS WON THE GAME");
            }
        }

       
    }
}
