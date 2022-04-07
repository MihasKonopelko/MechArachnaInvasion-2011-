using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Joint_Project
{
    public class EnemyClass
    {
        // Co-ordinate info/sizes for an Enemy and Sprite 
        public int xPos;
        public int yPos;
        public int width = 30;
        public int height = 25;
        string spriteLocation = "/Sprites/Enemy.png";

        // Enemy's Velocity
        public int xVelocity;
        public int yVelocity;

        // Sprite Centre (Used to centralize FOV)
        int spriteCentreX;
        int spriteCentreY;

        // Enemy's Field Of View (Was planning to use it for simulating simple AI)
        int fovSize = 500;
        int xPosOfFov;
        int yPosOfFov;

        // Allows Enemy to exist.  Also Used for Respawn in Level.cs
        public bool alive = true;



        public EnemyClass(int x, int y)
        // Used to create several enemies with their own coordinates
        {
            xPos = x;
            yPos = y;
        }
        public void DrawEnemyAndFOV(Graphics graphics)
        // Draws Enemy and FOV
        {
            spriteCentreX = xPos + width / 2;
            spriteCentreY = yPos + height / 2;

            Image enemySprite = Image.FromFile(Environment.CurrentDirectory + spriteLocation);
            graphics.DrawImage(enemySprite, xPos, yPos);

            xPosOfFov = spriteCentreX - fovSize/2;
            yPosOfFov = spriteCentreY - fovSize/2;
            
            Pen fov = new Pen(Color.Transparent);
            graphics.DrawRectangle(fov, xPosOfFov, yPosOfFov, fovSize, fovSize);



        }
        public void Chasing(PlayerClass player)
        // Enemy Movement
        { 
            if (player.yPos > yPosOfFov && player.yPos < yPosOfFov + fovSize)
            {

                if (player.xPos + player.width >= xPosOfFov && player.xPos + player.width <= spriteCentreX)
                {
                    xVelocity = -3;
                    fovSize = 600;
                }

                else if (player.xPos <= xPosOfFov + fovSize && player.xPos >= spriteCentreX)
                {
                    xVelocity = 3;
                    fovSize = 600;
                }

                else if (player.xPos + width < xPosOfFov || player.xPos > xPosOfFov)
                {
                    xVelocity = 0;
                    fovSize = 500;
                }
            }
        }
        public void CheckForDeath()
        // Obvious
        {           
            if (alive == false)
            {
                xPos = yPos = -1000;
                yVelocity = 0;
            }
        } 
    }
}
