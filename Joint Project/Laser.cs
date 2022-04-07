using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Joint_Project
{
    /*CLASS DESCRIPTION : CONSIST OF MATHEMATICAL EQUATIONS WHICH ARE USED FOR LASER CREATION*/
    public class Laser
    {
        // Used to define angle of the line in radiance
        double angle;

        // Used to store and solve maths
        double ax1, ax2, ay1, ay2, ox1, ox2, oy1, oy2;

        // Used to draw laser
        public double laserX, laserY;
        public int laserIncreaseX, laserIncreaseY;

        public LevelObject objects;

        public void UpdateMathsValues(PlayerClass player)
            // Updates Variables
        {
            // Adjacent line
            ax1 = player.spriteCentreX;
            ax2 = player.mousePositionX;
            ay1 = player.spriteCentreY;
            ay2 = player.spriteCentreY;

            // Opposite line
            ox1 = player.mousePositionX;
            ox2 = player.mousePositionX;
            oy1 = player.mousePositionY;
            oy2 = player.spriteCentreY;
        }

        public void MathematicalEquations()
            // Used to find angle of a laser
        {
            double adjaisent = DistanceFormulae(ax2, ax1, ay2, ay1);
            double opposite = DistanceFormulae(ox2, ox1, oy2, oy1);
            double hypothenus = Math.Sqrt(Math.Pow(adjaisent, 2) + Math.Pow(opposite, 2));

            double cosine = adjaisent / hypothenus;
            angle = Math.Acos(cosine);
        }
        public double DistanceFormulae(double x1, double x2, double y1, double y2)
            //     ______________________
            // d= /(x2-x1)`2 + (y2-y1)`2
        {   

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y1 - y2, 2));
            return distance;
        }
        public void DrawPlayerLaser(Graphics graphics, PlayerClass player)
            // Draws Laser and allows it to be drawn on 360 degrees
        {
            if (player.mousePositionX < player.spriteCentreX)
                laserX = player.spriteCentreX - laserIncreaseX * Math.Cos(angle);

            else if (player.mousePositionX > player.spriteCentreX)
                laserX = player.spriteCentreX + laserIncreaseX * Math.Cos(angle);

            if (player.mousePositionY < player.spriteCentreY)
                laserY = player.spriteCentreY - laserIncreaseY * Math.Sin(angle);

            else if (player.mousePositionY > player.spriteCentreY)
                laserY = player.spriteCentreY + laserIncreaseY * Math.Sin(angle);

            Pen laser = new Pen(Color.Red);
            graphics.DrawLine(laser, player.spriteCentreX, player.spriteCentreY, (float)laserX, (float)laserY);
        }
        
    }
}