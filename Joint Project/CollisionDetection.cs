using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joint_Project
{
    /*AUTOMATED CLASS WHICH CALCULATES COLLISION DETECTION AND BEHAVIOUR PATTERNS BETWEEN EACH OBJECT*/
    public class CollisionDetection
    {
        public CollisionDetection(PlayerClass player, LevelObject[] floor, int totalFloors,LevelObject[] wall,int totalWalls,EnemyClass[] enemy,int totalEnemies,LevelObject[] medipack, int totalMedipacks,LevelObject[] ammo, int totalAmmo,LevelObject deathLine)
        {
           
            
            
            // Player vs Floor
            for (int i = 0; i <= totalFloors-1; i++)
                if (floor[i].yPos + floor[i].height > player.yPos && floor[i].yPos < player.yPos && floor[i].xPos <= player.xPos + player.width && player.xPos+5 < floor[i].xPos + floor[i].width)
                {
                    player.yVelocity = 3;
                }

                else if (floor[i].yPos < player.yPos + player.height && player.yPos < floor[i].yPos + floor[i].height && floor[i].xPos <= player.xPos + player.width && player.xPos <= floor[i].xPos + floor[i].width)
                {
                    player.yPos = floor[i].yPos - player.height;
                    player.yVelocity = 0;
                }

            // Player vs Wall
            for (int i = 0; i <= totalWalls-1; i++)
                if (player.xPos <= wall[i].xPos + wall[i].width && player.xPos + player.width >= wall[i].xPos && player.yPos <= wall[i].yPos + wall[i].height && player.yPos + player.height >= wall[i].yPos)
                {
                    if (player.xVelocity < 0)
                    {
                        player.xPos = wall[i].xPos + wall[i].width;
                        player.xVelocity = 0;
                    }

                    else if (player.xVelocity > 0)
                    {
                        player.xPos = wall[i].xPos - player.width;
                        player.xVelocity = 0;
                    }

                }

            // Player vs Ammo
            for (int i = 0; i <= totalAmmo -1; i++)
                if ((ammo[i].yPos <= player.yPos + player.height && ammo[i].yPos >= player.yPos && ammo[i].xPos <= player.xPos + player.width && player.xPos <= ammo[i].xPos + ammo[i].width))
                {
                    ammo[i].yPos = 1000;
                    player.ammoSize += 40;
                }

            // Player vs Medipacks
            for (int i = 0; i <= totalMedipacks-1; i++)
            {
                if ((medipack[i].yPos <= player.yPos + player.height && medipack[i].yPos >= player.yPos && medipack[i].xPos <= player.xPos + player.width && player.xPos <= medipack[i].xPos + medipack[i].width))
                {
                    if (player.healthSize < 75)
                    {
                        medipack[i].yPos = 1000;
                        player.healthSize += 35;
                    }
                    else if (player.healthSize > 65 && player.healthSize < 100)
                    {
                        medipack[i].yPos = 1000;
                        player.healthSize = 100;

                    }
                }
            }

            // Enemy vs Floor       
            for (int i = 0; i <= totalFloors-1; i++)
                for (int j = 0; j <= totalEnemies-1; j++)
                    if ((floor[i].yPos < enemy[j].yPos + enemy[j].height && enemy[j].yPos < floor[i].yPos + floor[i].height && floor[i].xPos <= enemy[j].xPos + enemy[j].width && enemy[j].xPos <= floor[i].xPos + floor[i].width))
                    {
                        enemy[j].yPos = floor[i].yPos - enemy[j].height;
                        enemy[j].yVelocity = 0;
                    }

            // Enemy vs Wall
            for (int i = 0; i <= totalWalls-1; i++)
                for (int j = 0; j <= totalEnemies-1; j++)
                    if (enemy[j].xPos <= wall[i].xPos + wall[i].width && enemy[j].xPos + enemy[j].width >= wall[i].xPos && enemy[j].yPos <= wall[i].yPos + wall[i].height && enemy[j].yPos + enemy[j].height >= wall[i].yPos)
                    {
                        if (enemy[j].xVelocity < 0)
                        {
                            enemy[j].xPos = wall[i].xPos + wall[i].width + 2;
                            enemy[j].xVelocity = 0;
                        }

                        else if (enemy[j].xVelocity > 0)
                        {
                            enemy[j].xPos = wall[i].xPos - player.width - 2;
                            enemy[j].xVelocity = 0;
                        }

                    }

            // Enemy vs Player
            for (int i = 0; i <= totalEnemies-1; i++)
            {
                if (player.xPos <= enemy[i].xPos + enemy[i].width && player.xPos + player.width >= enemy[i].xPos && enemy[i].yPos >= player.yPos && enemy[i].yPos <= player.yPos + player.height)
                {
                    player.healthSize--;
                }
            }

            // Player and Enemy vs DeathLine
            if (player.yPos + player.height >= deathLine.yPos)
                player.healthSize = 0;

            for (int i = 0; i <= totalEnemies - 1; i++)
            {
                if (enemy[i].yPos + enemy[i].height >= deathLine.yPos)
                    enemy[i].alive = false;
            }
        }
    }
}
