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
        this.ySpeed = 0;
    }

    public void Update()
    {
        this.centerY += this.ySpeed;
        //need to add a thing that when hitting a pillar will move on the x axis along with the pillar

        //Draw.SetFillColor(194, 197, 204); //this will be the real one maybe
        //will change the colors later
        Draw.SetFillColor(255,0,0);
        Draw.SetLineColor(75,0,75);
        //will change the shape later
        Draw.Circle(this.centerX - 3, this.centerY - 3, 6);
    }

}