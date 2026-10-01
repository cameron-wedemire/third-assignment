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

        //the tunnels with be random range placed on the y axis within _ distance in a way that allows the player to not be blocked by a impassable wall
        //the tunnels will have their x value go from right to left at a reasonable speed,
        //if the player hits the wall of a tunnel it will reset the game, 
        float tunnel1CenterX = -50;
        float tunnel1CenterY = -50;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Tunnel Runner");
            Window.SetSize(600, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(25, 25, 25);
        }
    }

}
