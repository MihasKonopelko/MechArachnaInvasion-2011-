namespace Joint_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmr_SlowDownAndRestoreStamina = new System.Windows.Forms.Timer(this.components);
            this.tmr_AmmoReduction = new System.Windows.Forms.Timer(this.components);
            this.tmr_PlayerDeathAnimation = new System.Windows.Forms.Timer(this.components);
            this.lbl_Health = new System.Windows.Forms.Label();
            this.lbl_Stamina = new System.Windows.Forms.Label();
            this.lbl_Ammo = new System.Windows.Forms.Label();
            this.tmr_EnemyRespawn = new System.Windows.Forms.Timer(this.components);
            this.lbl_Score = new System.Windows.Forms.Label();
            this.tmr_RespawnMedi0 = new System.Windows.Forms.Timer(this.components);
            this.tmr_RespawnMedi1 = new System.Windows.Forms.Timer(this.components);
            this.tmr_RespawnAmmo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmr_SlowDownAndRestoreStamina
            // 
            this.tmr_SlowDownAndRestoreStamina.Enabled = true;
            this.tmr_SlowDownAndRestoreStamina.Tick += new System.EventHandler(this.SlowDownPlayerAndStaminaRestoration);
            // 
            // tmr_AmmoReduction
            // 
            this.tmr_AmmoReduction.Interval = 25;
            this.tmr_AmmoReduction.Tick += new System.EventHandler(this.tmr_AmmoReductionAndLaserCollisionDetectionAndScoring_Tick);
            // 
            // tmr_PlayerDeathAnimation
            // 
            this.tmr_PlayerDeathAnimation.Interval = 60;
            this.tmr_PlayerDeathAnimation.Tick += new System.EventHandler(this.tmr_PlayerDeathAnimation_Tick);
            // 
            // lbl_Health
            // 
            this.lbl_Health.AutoSize = true;
            this.lbl_Health.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Health.Font = new System.Drawing.Font("Quartz MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Health.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Health.Location = new System.Drawing.Point(7, 6);
            this.lbl_Health.Name = "lbl_Health";
            this.lbl_Health.Size = new System.Drawing.Size(81, 23);
            this.lbl_Health.TabIndex = 0;
            this.lbl_Health.Text = "Health";
            // 
            // lbl_Stamina
            // 
            this.lbl_Stamina.AutoSize = true;
            this.lbl_Stamina.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Stamina.Font = new System.Drawing.Font("Quartz MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Stamina.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Stamina.Location = new System.Drawing.Point(7, 38);
            this.lbl_Stamina.Name = "lbl_Stamina";
            this.lbl_Stamina.Size = new System.Drawing.Size(95, 23);
            this.lbl_Stamina.TabIndex = 1;
            this.lbl_Stamina.Text = "Stamina";
            // 
            // lbl_Ammo
            // 
            this.lbl_Ammo.AutoSize = true;
            this.lbl_Ammo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Ammo.Font = new System.Drawing.Font("Quartz MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ammo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Ammo.Location = new System.Drawing.Point(12, 72);
            this.lbl_Ammo.Name = "lbl_Ammo";
            this.lbl_Ammo.Size = new System.Drawing.Size(29, 92);
            this.lbl_Ammo.TabIndex = 2;
            this.lbl_Ammo.Text = "a\r\nm\r\nm\r\no";
            // 
            // tmr_EnemyRespawn
            // 
            this.tmr_EnemyRespawn.Enabled = true;
            this.tmr_EnemyRespawn.Interval = 700;
            this.tmr_EnemyRespawn.Tick += new System.EventHandler(this.tmr_EnemyRespawn_Tick);
            // 
            // lbl_Score
            // 
            this.lbl_Score.AutoSize = true;
            this.lbl_Score.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Score.Font = new System.Drawing.Font("Quartz MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Score.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Score.Location = new System.Drawing.Point(346, 32);
            this.lbl_Score.Name = "lbl_Score";
            this.lbl_Score.Size = new System.Drawing.Size(86, 29);
            this.lbl_Score.TabIndex = 6;
            this.lbl_Score.Text = "Score";
            // 
            // tmr_RespawnMedi0
            // 
            this.tmr_RespawnMedi0.Interval = 30000;
            this.tmr_RespawnMedi0.Tick += new System.EventHandler(this.tmr_RespawnMedi0_Tick);
            // 
            // tmr_RespawnMedi1
            // 
            this.tmr_RespawnMedi1.Interval = 30000;
            this.tmr_RespawnMedi1.Tick += new System.EventHandler(this.tmr_RespawnMedi1_Tick);
            // 
            // tmr_RespawnAmmo
            // 
            this.tmr_RespawnAmmo.Interval = 30000;
            this.tmr_RespawnAmmo.Tick += new System.EventHandler(this.tmr_RespawnAmmo_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(798, 597);
            this.Controls.Add(this.lbl_Score);
            this.Controls.Add(this.lbl_Ammo);
            this.Controls.Add(this.lbl_Stamina);
            this.Controls.Add(this.lbl_Health);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Mesh - Arachna Invasion";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingMethod);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyMethod);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Shoot_Button);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseLocation);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_SlowDownAndRestoreStamina;
        private System.Windows.Forms.Timer tmr_AmmoReduction;
        private System.Windows.Forms.Timer tmr_PlayerDeathAnimation;
        private System.Windows.Forms.Label lbl_Health;
        private System.Windows.Forms.Label lbl_Stamina;
        private System.Windows.Forms.Label lbl_Ammo;
        private System.Windows.Forms.Timer tmr_EnemyRespawn;
        private System.Windows.Forms.Label lbl_Score;
        private System.Windows.Forms.Timer tmr_RespawnMedi0;
        private System.Windows.Forms.Timer tmr_RespawnMedi1;
        private System.Windows.Forms.Timer tmr_RespawnAmmo;
    }
}

