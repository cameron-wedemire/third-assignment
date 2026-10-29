using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MohawkGame2D;

public class Pillar
{
    // Variables local to this class
    public float centerX;
    public float centerY;
    public float speed;
    float newPillarY;

    float minPillarHeight;
    float maxPillarHeight;

    public void Setup(int offset, float lastPillarY)
    {
        this.centerX = 40 + offset;
        this.speed = -1;
        minPillarHeight = 0;
        maxPillarHeight = 0;

        //chose the random Y position of the pillar
        if (offset == 50)
        {
            this.centerY = 200; //first pillar is always in the middle of the screen to support the player on spawn
        }
        else
        {
            //call the cuntion that chooses a new Y value and resets the pillar
            pillarReset(offset , lastPillarY);
        }
    }

    public void Update(float lastPillarY)
    {
        this.centerX += this.speed;

        //
        if (this.centerX < -50)
        {
            //call the cuntion that chooses a new Y value and resets the pillar
            pillarReset(660, lastPillarY);
        }

        //draws the pillar basic shape (this is what the hitbox is based on)
        Draw.SetFillColor(194, 197, 190);
        Draw.SetLineColor(0, 0, 0);
        Draw.Rectangle(this.centerX - 30, this.centerY-340, 60, 300);
        Draw.Rectangle(this.centerX - 30, this.centerY +40, 60, 300);

        //draws the bottom pillars details
        Draw.SetFillColor(190,90,170);
        Draw.Rectangle(this.centerX - 25, this.centerY + 40, 50, 10);
        Draw.Circle(this.centerX, this.centerY + 75, 12);
        Draw.Circle(this.centerX, this.centerY + 115, 7);

        //draws the top pillars details
        Draw.SetFillColor(190, 90, 170);
        Draw.Rectangle(this.centerX - 25, this.centerY - 50, 50, 10);
        Draw.Circle(this.centerX, this.centerY - 85, 12);
        Draw.Circle(this.centerX, this.centerY - 125, 7);
    }
    public void pillarReset(int offset, float lastPillarY)
    {
        //retry to find a value when the difference is too great to jump between them, this avoids impossible jumps that would break the game
        //min it so it cant go off screen top
        if ((lastPillarY - 50) < 85)
        {
            minPillarHeight = 100;
        }
        else
        {
            minPillarHeight = lastPillarY - 50;
        }
        //max it so it cant go off screen bottom
        if ((lastPillarY + 50) > 315)
        {
            maxPillarHeight = 300;
        }
        else
        {
            maxPillarHeight = lastPillarY + 50;
        }

        //loop inside the minMax untill it has enough difference to not be impossible to jump
        newPillarY = lastPillarY; //temp to make while loop start
        while (Math.Abs(newPillarY - lastPillarY) <= 30)
        {
            newPillarY = Random.Float(minPillarHeight, maxPillarHeight);
        }
        this.centerY = newPillarY;
        this.centerX = 40 + offset;
    }
}