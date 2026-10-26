using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D;

public class Pillar
{
    // Variables local to this class
    public float centerX;
    public float centerY;
    public float speed;
    public float newPillarY;
    public int hasToLoop = 1;
    Color tempColor;

    public void Setup(int offset, float lastPillarY)
    {
        this.centerX = 40 + offset; //fix this so it spawns off screen to the right by the minimum
        this.speed = -1; //change this later to fit the game better if needed
        this.tempColor = Random.Color(); //this is for testing loop purposes

        //chose the random Y position of the pillar
        if (offset == 50)
        {
            this.centerY = 200; //first pillar is always in the middle of the screen to support the player on spawn
        }
        else
        {
            //retry to find a value when the difference is too great to jump between them, this avoids impossible jumps that would break the game
            while (hasToLoop == 1)//change the 100 here and lower to a better number once you get the jump figured out
            {
                newPillarY = Random.Float(85, 315);

                if ((Math.Abs(newPillarY - lastPillarY) < 75) && (Math.Abs(lastPillarY - newPillarY) < 50)) //the min is not working
                {
                    hasToLoop = 0;
                }
            }
            this.centerY = newPillarY;
        }
    }

    public void Update(float lastPillarY)
    {
        this.centerX += this.speed;

        //loop screen
        if (this.centerX < -50)
        {
            this.centerX = 700;//fix this so it spawns off screen to the right by same amount as spawn

            //retry to find a value when the difference is too great to jump between them, this avoids impossible jumps that would break the game
            while (hasToLoop == 1)//change the 100 here and lower to a better number once you get the jump figured out
            {
                newPillarY = Random.Float(85, 315);

                if ((Math.Abs(newPillarY - lastPillarY) < 75) && (Math.Abs(lastPillarY - newPillarY) < 50))
                {
                    hasToLoop = 0;
                }
            }
            this.centerY = newPillarY;
        }

        //draws the pillar
        Draw.SetFillColor(194, 197, 204);
        Draw.SetLineColor(0, 0, 0);
        Draw.Rectangle(this.centerX - 30, this.centerY-340, 60, 300);
        Draw.Rectangle(this.centerX - 30, this.centerY +40, 60, 300);
    }

}