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
        Player character = new Player();
        float lastPillarY = 200;
        Pillar[] Pillars = new Pillar[5];//array of pillars
        int playerInPillarHitbox = 0;

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

            character.Setup();
            playerInPillarHitbox = 0;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(25, 25, 25);
            //reset the variable of player being in the hitbox to false so it can cange later if it actually is in the hitbox
            playerInPillarHitbox = 0;

            //iterate over array, to update each pillars position
            for (int i = 0; i < Pillars.Length; i++)
            {
                //update each pillar
                if (i == 0)
                {
                    Pillars[i].Update(Pillars[Pillars.Length - 1].centerY);
                }
                else
                {
                    Pillars[i].Update(Pillars[i].centerY);
                }
                //checks if the player hits each pillar (first if statement checkss if the x value contains the players x value)
                if ((Pillars[i].centerX - 30 < character.centerX) && (Pillars[i].centerX + 35 > character.centerX)) //this.centerX -30, this.centerY + 35
                {
                    //Console.WriteLine(i);
                    //Console.WriteLine(Pillars[i].centerX);
                    //Console.WriteLine("");

                    //check if the y value contains the player
                    if (character.centerY - 3 >= Pillars[i].centerY + 35) //this.centerX -30, this.centerY + 35
                    {
                        if (character.centerY - 3 <= Pillars[i].centerY + 50) //this.centerX -30, this.centerY + 35
                        {
                            playerInPillarHitbox = 1;
                        }
                    }
                }
            }
            //Console.WriteLine();
            //update player position
            character.Update(playerInPillarHitbox);
        }
    }

}
