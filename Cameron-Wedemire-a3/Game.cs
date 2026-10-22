// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        //variables
        float playerX = 50;
        float playerY = 200;

        float lastPillarY = 200;
        Pillar[] Pillars = new Pillar[5];//array of pillars

        //the tunnels with be random range placed on the y axis within _ distance in a way that allows the player to not be blocked by a impassable wall
        //the tunnels will have their x value go from right to left at a reasonable speed,
        //if the player hits the wall of a tunnel it will reset the game, 
        //note this was moved into the pillar class

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Pillar Run");
            Window.SetSize(600, 400);

            //iterate over array, to setup each pillar
            for (int i = 0; i < Pillars.Length; i++)
            {
                //for each element in arrey, create new pillar
                Pillars[i] = new Pillar();
                //setup the pillar that was just made
                Pillars[i].Setup(50+ (i*150), lastPillarY);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(25, 25, 25);

            //iterate over array, to update each pillar
            for (int i = 0; i < Pillars.Length; i++)
            {
                //update each pillar
                //Pillars[i].Update(lastPillarY);

                //lastPillarY = Pillars[i].centerY;

                //Console.WriteLine(lastPillarY);

                if (i == 0)
                {
                    Pillars[i].Update(Pillars[Pillars.Length - 1].centerY);
                }
                else
                {
                    Pillars[i].Update(Pillars[i].centerY);
                }
            }
        }
    }

}
