using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Joint_Project
{
    /*CLASS DESCRIPTION : STORES PLAYER METHODS AND VARIABLES*/
    public class PlayerClass
    {// Declare Variables

        // Player's sizes
        public int xPos = 240;
        public int yPos = 420;
        public int width = 30;
        public int height = 65;
        public string playerSpriteDirection = "/Sprites/Player-Left.png";

        // Velocity
        public int xVelocity;
        public int yVelocity;

        // Cursor location
        public int mousePositionX=0;
        public int mousePositionY=0;

        // Sprite centre
        public int spriteCentreX=0;
        public int spriteCentreY=0;

        // Health and Stamina bar sizes
        public int healthSize = 100;
        public int staminaSize = 100;
        public double ammoSize = 100;

        // Stores fall damage
        int fallDamage = 0;

        // Score
        public int score = 0;


        public void DrawPlayer(Graphics graphics)
            // Draws player
        {
            spriteCentreX = xPos + width / 2;
            spriteCentreY = yPos + height / 2;

            
            Image playerSprite;

            if (mousePositionX < spriteCentreX && healthSize > 0)
                playerSpriteDirection = "/Sprites/Player-Left.png";

            else if (mousePositionX > spriteCentreX && healthSize > 0)
                playerSpriteDirection = "/Sprites/Player-Right.png";


            playerSprite = Image.FromFile(Environment.CurrentDirectory + playerSpriteDirection);
            graphics.DrawImage(playerSprite, xPos, yPos);
        } 
        public void JumpMethod()
            // Consist of different jump directions depending on the cursor location
        {
            if (yVelocity == 0)
            {
                if (mousePositionX >= spriteCentreX - 20 && mousePositionX <= spriteCentreX + 20)
                {
                    yVelocity = -25;
                }
                else if (mousePositionX >= spriteCentreX - 40 && mousePositionY <= spriteCentreY - 30)
                {
                    xVelocity += 10;
                    yVelocity = -18;
                }
                else if (mousePositionX <= spriteCentreX + 40 && mousePositionY <= spriteCentreY - 30)
                {
                    xVelocity -= 10;
                    yVelocity = -18;
                }
                else if (mousePositionX < spriteCentreX + 50 )
                {
                    xVelocity -= 12;
                    yVelocity = -15;
                }
                else if (mousePositionX > spriteCentreX - 50 )
                {
                    xVelocity += 12;
                    yVelocity = -15;
                }
            }
        }
        public void DrawHealthAndStaminaAndAmmoBar(Graphics graphics)
            // Draws bars
        {
            SolidBrush health = new SolidBrush(Color.Red);
            SolidBrush stamina = new SolidBrush(Color.Green);
            SolidBrush ammo = new SolidBrush(Color.Purple);
            graphics.FillRectangle(ammo, 10, 70, 30, (int)ammoSize);
            graphics.FillRectangle(health, 10, 10, healthSize, 20);
            graphics.FillRectangle(stamina, 10, 40, staminaSize, 20);
        }
        public void FallDamage()
            // Obvious
        {
            if (yVelocity >= 25)
            {
                fallDamage += yVelocity / 3;
            }
            if (yVelocity == 0)
            {
                healthSize -= fallDamage;
                fallDamage = 0;
            }
        }
    }
}
