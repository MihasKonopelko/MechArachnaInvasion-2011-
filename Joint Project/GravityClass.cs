using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joint_Project
{
    /*CLASS DESCRIPTION : PROVIDES SIMPLE GRAVITY*/
    public class GravityClass
    {
        public const int gravity = 2;   //pixels per frame!
        public void Physics(PlayerClass player, Level level)
        // Physics for Player and Enemies
        {
            player.yVelocity += gravity;
            player.yPos += player.yVelocity;
            player.xPos += player.xVelocity;

            for (int i = 0; i <= level.totalEnemies-1; i++)
            {
                level.enemy[i].yVelocity += gravity;
                level.enemy[i].yPos += level.enemy[i].yVelocity;
                level.enemy[i].xPos += level.enemy[i].xVelocity;
            }
        }
    }
}

