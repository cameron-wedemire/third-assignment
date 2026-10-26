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
        int playerInPillarHitbox;
        int pillarPlayerIsOn;
        int respawnPillar;
        int scoreValue;

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
            pillarPlayerIsOn = 0;
            respawnPillar = 0;
            scoreValue = 0;
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

                //desides if the pillar is the respawnPillar for if the player falls off the map
                if (Pillars[i].centerX - 30 == 70)
                {
                    respawnPillar = i;
                    scoreValue += 1;
                }

                //checks if the player hits each pillar (first if statement checkss if the x value contains the players x value)
                if ((Pillars[i].centerX - 30 < character.centerX) && (Pillars[i].centerX + 40 > character.centerX))
                {
                    pillarPlayerIsOn = i;

                    //check if the y value contains the player (JUMP HITBOX)
                    if (character.centerY - 3 >= Pillars[i].centerY + 31)
                    {
                        if (character.centerY - 3 <= Pillars[i].centerY + 40)
                        {
                            playerInPillarHitbox = 1;
                        }
                    }

                    //check if the y value contains the player (WALL HITBOX)
                    if (character.centerY - 3 <= Pillars[i].centerY -40)
                    {
                        character.centerX -= 1;
                    }
                    else if (character.centerY - 3 >= Pillars[i].centerY + 40)
                    {
                        character.centerX -= 1;
                    }
                }
            }
            //Console.WriteLine(); //remove later
            //update player position
            //if player goes below bottom of the screen it or off the left of the screen it will respawn on the respawnPillar (pillar at x=50)
            if (((character.centerY > 420) || (character.centerX < -5)) && (Pillars[respawnPillar].centerX == 70))
            {
                character.ySpeed = -2;
                character.centerX = 50;
                character.centerY = Pillars[respawnPillar].centerY+20;
                scoreValue = 0;
            }

            character.Update(playerInPillarHitbox, Pillars[pillarPlayerIsOn].centerY);

            //show the players score
            Draw.SetFillColor(210, 130, 140); //was 194, 197, 204
            Draw.SetLineColor(75, 0, 0);
            Draw.Rectangle(250, 40, 100, 40);
            Text.Draw($"{scoreValue}", 250, 50);//i asked in class and was shown the $"{}" thing
        }
    }

}

//to doadd background and better graphics for the pillars, also if you have time try to add a jump bar to show jump strength