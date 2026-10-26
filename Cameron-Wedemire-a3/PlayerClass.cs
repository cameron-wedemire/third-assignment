using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D;

public class Player
{
    // Variables local to this class
    public float centerX;
    public float centerY;
    public float ySpeed;

    public void Setup()
    {
        this.centerX = 40;
        this.centerY = 200;
        //this is mainly used for gravity calculation application to the player so -speed is going towards the bottom of the screen
        this.ySpeed = 0;
    }

    public void Update(int playerOnGround)
    {
        //player Y movement
        if (playerOnGround == 0)
        {
            this.ySpeed -= 0.05f;//fine tune value later
            this.centerY -= this.ySpeed;
        }
        else
        {
            //reset ySpeed to 0 as its lost its gravity value as it hit ground
            this.ySpeed = 0;
        }

        //need to add a thing that when hitting a pillar will move on the x axis along with the pillar


        //will change the colors later
        Draw.SetFillColor(210, 130, 140); //was 194, 197, 204
        Draw.SetLineColor(75,0,0);

        //draw the player
        Draw.SetLineSize(1);
        Draw.Circle(this.centerX - 3, this.centerY - 13, 5);
        Draw.SetLineSize(3);
        Draw.Line(this.centerX - 3, this.centerY - 15, this.centerX, this.centerY - 15);
        Draw.SetLineSize(1);
        Draw.Circle(this.centerX - 3, this.centerY - 3, 8);
    }

}