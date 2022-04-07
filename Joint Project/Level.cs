using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Joint_Project
{
    /*CLASS DESCRIPTION : CREATES LEVEL FROM LEVEL AND ENEMY OBJECTS, CALCULATES COLLISION DETECTION*/   
    public class Level
    {
        //Declare Class Objects and Quantities
        public int totalEnemies = 4;
        public int totalWalls = 7;
        public int totalFloors = 14;

        int totalClouds = 3;
        int totalMedipacks = 2;
        int totalAmmo = 1;

        public LevelObject[] cloud = new LevelObject[3];
        public LevelObject[] floor = new LevelObject[15];
        public LevelObject[] wall = new LevelObject[7];
        public LevelObject[] ammo = new LevelObject[1];
        public LevelObject[] medipack = new LevelObject[2];
        public EnemyClass[] enemy = new EnemyClass[4];
        public LevelObject deathLine = new LevelObject(0,600,800,1);

        // Collision Detection 
         CollisionDetection cd;



        public Level()
        // Initializes class arrays (Formally they plot objects on the screen)
        {
            cloud[0] = new LevelObject(45, 90, 67, 40);
            cloud[1] = new LevelObject(697, 20, 57, 30);
            cloud[2] = new LevelObject(201, 50, 37, 12);
            floor[0] = new LevelObject(180, 530, 150, 30);
            floor[1] = new LevelObject(450, 530, 150, 30);
            floor[2] = new LevelObject(290,420,200,20);
            floor[3] = new LevelObject(80,410,130,30);
            floor[4] = new LevelObject(570, 410, 130,30);
            floor[5] = new LevelObject(570, 520, 30, 10);
            floor[6] = new LevelObject(570, 410 , 30,40);
            floor[7] = new LevelObject(80, 150, 110, 20);
            floor[8] = new LevelObject(590, 150, 110, 20);
            floor[9] = new LevelObject(240,300,70,20);
            floor[10] = new LevelObject(470, 300, 70, 20);
            floor[11] = new LevelObject(170, 190, 60, 20);
            floor[12] = new LevelObject(550, 190, 60, 20);
            floor[13] = new LevelObject(250,0,280,20);
            wall[0] = new LevelObject(180, 440, 30, 90);
            wall[1] = new LevelObject(80, 170, 20, 240);
            wall[2] = new LevelObject(680,170,20,240);
            wall[3] = new LevelObject(170,160,20,50);
            wall[4] = new LevelObject(590, 160, 20, 50);
            wall[5] = new LevelObject(130,-15,20,165);
            wall[6] = new LevelObject(630, -15, 20, 165);
            ammo[0] = new LevelObject(394,385,15,30);
            medipack[0] = new LevelObject(200, 160, 20, 20);
            medipack[1] = new LevelObject(550, 160, 20, 20);
            enemy[0] = new EnemyClass(400, 90);
            enemy[1] = new EnemyClass(350, 90);
            enemy[2] = new EnemyClass(450, 90);
            enemy[3] = new EnemyClass(400, 90);
        }

        // Draw Different Level Objects
        public void DisplayAndAnimateCloud(Graphics graphics)
        {   
            SolidBrush cloudColor = new SolidBrush(Color.White);
            Random r = new Random();

            int cloudSpeed = 2;
            int cloudPosition = r.Next(3, 300);

            for (int i = 0; i <= totalClouds - 1; i++)
            {
                cloud[i].DisplayFloor(graphics, cloudColor);
                cloud[i].xPos += cloudSpeed;

                if (cloud[i].xPos > 850)
                {
                    cloud[i].yPos = cloudPosition;
                    cloud[i].xPos = -65;
                }
            } 
        }
        public void DisplayFloor(Graphics graphics)
        {
            SolidBrush floorColor = new SolidBrush(Color.SandyBrown);
            for (int i = 0; i <= totalFloors-1; i++)
                floor[i].DisplayFloor(graphics, floorColor);
        }
        public void DisplayWalls(Graphics graphics)
        {
            SolidBrush wallColor = new SolidBrush(Color.SandyBrown);
            for (int i = 0; i <= totalWalls-1; i++)
                wall[i].DisplayWalls(graphics, wallColor);
        }
        public void DisplayAmmo(Graphics graphics)
        {
            Image ammoSprite = Image.FromFile(Environment.CurrentDirectory + "/Sprites/Ammo.png");
            for (int i = 0; i <= totalAmmo-1; i++)
                ammo[i].DisplayAmmo(graphics, ammoSprite);
        }
        public void DisplayMedipacks(Graphics graphics)
        {
            Image medipackSprite = Image.FromFile(Environment.CurrentDirectory + "/Sprites/Medipack.png");
            for (int i = 0; i <= totalMedipacks-1; i++)
                medipack[i].DisplayMedipacks(graphics, medipackSprite);
        }
        public void DeathLine(Graphics graphics)
        {
            Pen pen = new Pen(Color.Blue);
            deathLine.DeathLine(graphics, pen);
        }

        public void CollisionDetection(PlayerClass player)
            // Calls Collision Detection Class Object
        {
            cd = new CollisionDetection(
                player, 
                floor, 
                totalFloors, 
                wall, totalWalls, 
                enemy,
                totalEnemies, 
                medipack, 
                totalMedipacks, 
                ammo, totalAmmo, 
                deathLine);        
        }

        public void EnemyAndItemRespawn(PlayerClass player)
            // Respawns Enemies
        {
            if (enemy[0].alive == false)
            {
                enemy[0].alive = true;
                enemy[0].xPos = 120;
                enemy[0].yPos = 185;
            }
            if (enemy[1].alive == false)
            {
                enemy[1].alive = true;
                enemy[1].xPos = 625;
                enemy[1].yPos = 185;
            }
            if (enemy[2].alive == false)
            {
                enemy[2].alive = true;
                enemy[2].xPos = 570;
                enemy[2].yPos = -50;
            }
            if (enemy[3].alive == false)
            {
                enemy[3].alive = true;
                enemy[3].xPos = 180;
                enemy[3].yPos = -50;
            }
        }
    }
}