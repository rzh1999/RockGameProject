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
            //Set players names
            human.SetPlayersName();
            int random = computer.GenerateRandomNumber();
            computer.SetPlayersName(random);

            //Generate choice list
            GenerateListChoices();


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
        
    }
}
