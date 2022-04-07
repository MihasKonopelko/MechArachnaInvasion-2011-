using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Joint_Project
{
    /*CLASS DESCRIPTION : STORES LEVEL OBJECTS */   
    public class LevelObject
    {
        // Declares Variables
        public int xPos;
        public int yPos;
        public int width;
        public int height;

        public LevelObject(int x, int y, int w, int h)
        // Initializes Variables
        {
            xPos = x;
            yPos = y;
            width = w;
            height = h;
        }

        // Doesn't need much.  Makes code easier to read
        public void DisplayCloud(Graphics graphics, SolidBrush solidBrush)
        { 
            graphics.FillRectangle(solidBrush, xPos, yPos, width, height); 
        }
        public void DisplayFloor(Graphics graphics, SolidBrush solidBrush)
        {
            graphics.FillRectangle(solidBrush, xPos, yPos, width, height);
        }
        public void DisplayAmmo(Graphics graphics, Image sprite)
        {
            graphics.DrawImage(sprite, xPos, yPos);
        }
        public void DisplayMedipacks(Graphics graphics,Image sprite)
        {
            graphics.DrawImage(sprite, xPos, yPos);
        }
        public void DeathLine(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, xPos, yPos, width, height);
        }
        public void DisplayWalls(Graphics graphics, SolidBrush solidBrush)
        {
            graphics.FillRectangle(solidBrush, xPos, yPos, width, height);
        }

    }

}
