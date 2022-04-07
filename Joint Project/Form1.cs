/*NAME : MIHAS KONOPELKO
  LOGIN : C00157576
  FILE : JOINT PROJECT
  ----------------------
  PROJECT FEATURES:
  
    •	SIMPLE GRAVITY
    •	JUMPS AT A DIRECTION RELATIVE TO MOUSE POSITION
    •	STAMINA BAR AND AMMO BAR.  HEALTH DISPLAYED IN THE SAME WAY
    •	MEDIPACKS AND AMMO
    •	PLAYER CAN SHOOT 360 DEGREES
    •	USES CLASSES, SUB-CLASSES AND ARRAYS FOR SIMPLICITY
    •	SELF-DRAWN SPRITES
    •	SELF-BUILD LEVEL BY IN-PROGRAM CREATED LEVEL BUILDER (SAVED ABOUT 6-7 HOURS OF MY TIME)
    •	AUTOMATED COLLISION DETECTION
    •	ITEMS SPAWN AFTER 1 MINUTE
    •	(DEDICATE TO MINECRAFT) RECTANGULAR CLOUDS
    •	RESTART BUTTON
  ----------------------
  BUGS:
    - SCREEN FLICKERS (for some computers)
    - COULDN'T MAKE PROPER COLLISION DETECTION FOR WALLS WHEN PLAYER JUMPS ON TOP OF IT OR HITS IT UNDERGROUND, SO I WILL USE THEM IN COMBINATION WITH FLOORS (MINOR)
  ----------------------
  DESCRIPTION: THIS IS A SIDE-VIEW PLATFORMER WHERE PLAYER SHALL STAND AGAINST INFINITE AMOUNT OF ROBOTHIC SPIDERS WITH LOW AMMO AND TRY TO GET THE HIGH SCORE*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Joint_Project
{
 /*CLASS DESCRIPTION : INITIALIZES AND BUILDS FORM WINDOW, CHECKS LASER COLLSION*/   

    public partial class Form1 : Form
    {
        // Declare Class Objects
        public GravityClass G = new GravityClass();                        
        public PlayerClass Player = new PlayerClass();                              
        public Level Level = new Level();
        public Laser Laser = new Laser();
             
        int deathAnimationFrames = 0;
        int staminaRestorationRate = 3;

        public Form1()
            // Initialization
        {
            InitializeComponent();
        }                                                   
        public void UpdateWorld()
            // Checks and Updates instances in the world
        {
            // Simulates physics
            G.Physics(Player, Level);   
                               
            // Updates Levels and Enemy sub-class
            for (int i = 0; i <= Level.totalEnemies - 1; i++)
            {
                Level.CollisionDetection(Player);
                Level.enemy[i].Chasing(Player);
                Level.enemy[i].CheckForDeath();
            }                
                
            // Laser Mechanics
            Laser.UpdateMathsValues(Player);
            Laser.MathematicalEquations();
            if (tmr_AmmoReduction.Enabled == false)
                Laser.laserIncreaseX = Laser.laserIncreaseY = 0;


            // Launches Death Code and Animation
            if (Player.healthSize <= 0)
                tmr_PlayerDeathAnimation.Enabled = true;


            SpeedLimitation();                      // Sets Velocity Limits
            HealthAndStaminaMethod();               // Updates Health and Stamina Bars
            Player.FallDamage();                    // Calculates fall damage
            RespawnItems();                         // Respawns Items like Medipacks and Ammo 

            // Score
            lbl_Score.Text = "Score: " + Player.score;
        } 
        public void DrawingMethod(object sender, PaintEventArgs e)
            // Draws instances
        {
            // Initializes Graphics 
            Graphics graphics = e.Graphics;
            
            
            // Draws level objects
            Level.DisplayAndAnimateCloud(graphics);
            Level.DisplayFloor(graphics);
            Level.DisplayWalls(graphics);
            Level.DisplayAmmo(graphics);
            Level.DisplayMedipacks(graphics);
            Level.DeathLine(graphics);

            // Draws Player and Laser
            Player.DrawPlayer(graphics);
            Laser.DrawPlayerLaser(graphics, Player);

            // Player's health, stamina and ammo bar
            Player.DrawHealthAndStaminaAndAmmoBar(graphics);

            // Draws Enemies
            for (int i = 0; i <= Level.totalEnemies - 1; i++)
                Level.enemy[i].DrawEnemyAndFOV(graphics);

        } 
        public void KeyMethod(object sender, KeyEventArgs e)            
            // Reads and inplement User Keyboard Input
            // to process left/right/jump/shot
            // (Has 2 keys per action for player's comfort)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                Player.xVelocity--;
                if (Player.xVelocity <= -6)
                    Player.xVelocity = -6;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Player.xVelocity++;
                if (Player.xVelocity >= 6)
                    Player.xVelocity = 6;
            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.ControlKey)
                Player.JumpMethod();

            if (e.KeyCode == Keys.Q)
            {            
                if (tmr_AmmoReduction.Enabled == true)
                tmr_AmmoReduction.Enabled = false;

            else
                tmr_AmmoReduction.Enabled = true;
            }

            if (e.KeyCode == Keys.R)
                Application.Restart();

        }
        private void Shoot_Button(object sender, MouseEventArgs e)
            // Alternative Key for Shooting 
        {
            if (tmr_AmmoReduction.Enabled == true)
                tmr_AmmoReduction.Enabled = false;

            else
                tmr_AmmoReduction.Enabled = true;
        }
        public void MouseLocation(object sender, MouseEventArgs e)
            // Reads mouse location and sets Cursor picture
        {
            Player.mousePositionY = e.Y;
            Player.mousePositionX = e.X;
            Cursor.Current = Cursors.Cross;
        }
        public void SlowDownPlayerAndStaminaRestoration(object sender, EventArgs e)
            // Slowdowns Player's velocity as a key is released
            // and restores stamina
        {
            if (Player.xVelocity > 0)
                Player.xVelocity--;

            else if (Player.xVelocity < 0)
                Player.xVelocity++;

            if (Player.xVelocity == 0 && Player.yVelocity <= 0 && Player.staminaSize <100)
                Player.staminaSize += staminaRestorationRate;
        }
        public void HealthAndStaminaMethod()
            // Mechanics for Health, Stamina 
        {
            // Stamina Reduction
            if (Player.xVelocity > 0)
                Player.staminaSize -= Player.xVelocity / 4;

            else if (Player.xVelocity < 0)
                Player.staminaSize += Player.xVelocity / 4;

            else if (Player.yVelocity < 0)
                Player.staminaSize += Player.yVelocity / 2;


            // Actions if stamina/health equals 0
            
            if (Player.staminaSize <= 0)
            {
                Player.staminaSize = 0;
                
                if (Player.yVelocity ==0)
                    Player.xVelocity/=2;
                if (Player.yVelocity<0)
                    Player.yVelocity/=2;
            }         
        }
        public void SpeedLimitation()
            // Sets the limit for the player's movement
        {
            if (Player.xVelocity > 6 && Player.yVelocity == 0)
                Player.xVelocity--;

            else if (Player.xVelocity < -6 && Player.yVelocity == 0)
                Player.xVelocity++;
        }
        private void tmr_AmmoReductionAndLaserCollisionDetectionAndScoring_Tick(object sender, EventArgs e)
            // Collision Detection for Laser, Ammo Reduction and Score addition
        {
            int speed = 24;
            double ammoConsumption = 2.9;

            Laser.laserIncreaseX += speed;
            Laser.laserIncreaseY += speed;
            Player.ammoSize -= ammoConsumption;

            if (Player.ammoSize <= 0)
            { 
                tmr_AmmoReduction.Enabled = false;
                Player.ammoSize = 0;
                Laser.laserIncreaseX = Laser.laserIncreaseY = 0;
            }
            
            for (int i = 0; i <= Level.totalEnemies -1; i++)
            {
                if (Laser.laserX > Level.enemy[i].xPos && Laser.laserX < Level.enemy[i].xPos + Level.enemy[i].width && (Laser.laserY <= Level.enemy[i].yPos + Level.enemy[i].height && Laser.laserY >= Level.enemy[i].yPos))
                {
                        tmr_AmmoReduction.Enabled = false;
                        Laser.laserIncreaseX = Laser.laserIncreaseY = 0;
                        Level.enemy[i].alive = false;
                        Player.score+=10;
                }
            }

            for (int i = 0; i <= Level.totalWalls - 1;i++)
            {
                if (Laser.laserX >= Level.wall[i].xPos && Player.xPos + Player.width <= Level.wall[i].xPos && (Laser.laserY < Level.wall[i].yPos + Level.wall[i].height && Laser.laserY > Level.wall[i].yPos) || Laser.laserX <= Level.wall[i].xPos + Level.wall[i].width && Player.xPos >= Level.wall[i].xPos && (Laser.laserY < Level.wall[i].yPos + Level.wall[i].height && Laser.laserY > Level.wall[i].yPos))
                {
                    tmr_AmmoReduction.Enabled = false;
                    Laser.laserIncreaseX = Laser.laserIncreaseY = 0;
                }
            }

            for (int i = 0; i <= Level.totalFloors - 1; i++)
            {
                if (Level.floor[i].yPos + Level.floor[i].height > Laser.laserY && Level.floor[i].yPos < Laser.laserY && Level.floor[i].xPos < Laser.laserX && Laser.laserX < Level.floor[i].xPos + Level.floor[i].width)
                {
                    tmr_AmmoReduction.Enabled = false;
                    Laser.laserIncreaseX = Laser.laserIncreaseY = 0;
                }
            }

        }
        private void tmr_PlayerDeathAnimation_Tick(object sender, EventArgs e)
            // Runs Death Animation
        {
            // Disables any action by Player
            Player.xVelocity = 0;
            Player.yVelocity = 0;
            Player.ammoSize = 0;
            Player.staminaSize = 0;
            staminaRestorationRate = 0;
            
            deathAnimationFrames++;

            if (Player.mousePositionX < Player.spriteCentreX && deathAnimationFrames < 7)
            {
                Player.playerSpriteDirection = "/Sprites/Death Animation/LeftPlayerDeath" + deathAnimationFrames + ".png";
            }

            else if (Player.mousePositionX >= Player.spriteCentreX && deathAnimationFrames < 7)
            {
                Player.playerSpriteDirection =   "/Sprites/Death Animation/RightPlayerDeath" + deathAnimationFrames + ".png";
            }
        }
        private void tmr_EnemyRespawn_Tick(object sender, EventArgs e)
            // Respawn Enemies after they were killed
        {
            Level.EnemyAndItemRespawn(Player);
        }
        private void RespawnItems()
            // Respawns Items by staritng timer(s) allocated to them
        {
            if (Level.medipack[0].yPos == 1000)
                tmr_RespawnMedi0.Enabled = true;
            
            if (Level.medipack[1].yPos == 1000)
                tmr_RespawnMedi1.Enabled = true;
            
            if (Level.ammo[0].yPos == 1000)
                tmr_RespawnAmmo.Enabled = true;
        
        }
            
            // Timers themselves
        private void tmr_RespawnMedi0_Tick(object sender, EventArgs e)
        {
            Level.medipack[0].yPos = 160;
            tmr_RespawnMedi0.Enabled = false;
        }
        private void tmr_RespawnMedi1_Tick(object sender, EventArgs e)
        {
            Level.medipack[1].yPos = 160;
            tmr_RespawnMedi1.Enabled = false;
        }
        private void tmr_RespawnAmmo_Tick(object sender, EventArgs e)
        {
            Level.ammo[0].yPos = 385;
            tmr_RespawnAmmo.Enabled = false;
        }
    }
}
