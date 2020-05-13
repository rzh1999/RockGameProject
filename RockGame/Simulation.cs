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
        public Simulation()
        {

        }  

        public void RunSimulation()
        {
            human.GetPlayersName();

            Console.ReadLine();
        }
        
    }
}
