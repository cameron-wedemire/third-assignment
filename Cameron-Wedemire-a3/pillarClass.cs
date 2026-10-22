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

    public void Setup()
    {
        this.centerX = 700; //fix this so it spawns off screen to the right by the minimum
        this.centerY = Random.Float(85, 315);
        this.speed = 1; //change this later to fit the game better if needed
    }

    public void Update()
    {
        this.centerX += this.speed;

        //loop screen
        if (this.centerX < -50)
        {
            this.centerX = 700;//fix this so it spawns off screen to the right by same amount as spawn
            this.centerY = Random.Float(85, 315); //will need a way to change this but keep it possible to jump from last pillar
        }

        Draw.FillColor = (194, 197, 204);
        Draw.LineColor = (0, 0, 0;)
        Draw.Rectangle(this.centerX, this.centerY, 30, 15);
    }

}