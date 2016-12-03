namespace ArenaGameProject
{
    partial class CharacterSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSelect));
            this.Warrior = new System.Windows.Forms.Button();
            this.Mage = new System.Windows.Forms.Button();
            this.Archer = new System.Windows.Forms.Button();
            this.Priest = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.warrior_box1 = new System.Windows.Forms.PictureBox();
            this.warrior_box2 = new System.Windows.Forms.PictureBox();
            this.mage_box1 = new System.Windows.Forms.PictureBox();
            this.mage_box2 = new System.Windows.Forms.PictureBox();
            this.archer_box1 = new System.Windows.Forms.PictureBox();
            this.archer_box2 = new System.Windows.Forms.PictureBox();
            this.priest_box1 = new System.Windows.Forms.PictureBox();
            this.priest_box2 = new System.Windows.Forms.PictureBox();
            this.AI = new System.Windows.Forms.CheckBox();
            this.WhichTeam = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.Label();
            this.ch_name = new System.Windows.Forms.TextBox();
            this.player_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.warrior_box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warrior_box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mage_box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mage_box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archer_box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archer_box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priest_box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priest_box2)).BeginInit();
            this.SuspendLayout();
            // 
            // Warrior
            // 
            this.Warrior.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Warrior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Warrior.ForeColor = System.Drawing.SystemColors.Control;
            this.Warrior.Image = ((System.Drawing.Image)(resources.GetObject("Warrior.Image")));
            this.Warrior.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Warrior.Location = new System.Drawing.Point(38, 70);
            this.Warrior.Name = "Warrior";
            this.Warrior.Size = new System.Drawing.Size(318, 68);
            this.Warrior.TabIndex = 0;
            this.Warrior.Text = "Warrior";
            this.Warrior.UseVisualStyleBackColor = false;
            this.Warrior.Click += new System.EventHandler(this.Warrior_Click);
            this.Warrior.MouseEnter += new System.EventHandler(this.Warrior_MouseEnter);
            this.Warrior.MouseLeave += new System.EventHandler(this.Warrior_MouseLeave);
            // 
            // Mage
            // 
            this.Mage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Mage.ForeColor = System.Drawing.SystemColors.Control;
            this.Mage.Image = ((System.Drawing.Image)(resources.GetObject("Mage.Image")));
            this.Mage.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Mage.Location = new System.Drawing.Point(362, 70);
            this.Mage.Name = "Mage";
            this.Mage.Size = new System.Drawing.Size(318, 68);
            this.Mage.TabIndex = 1;
            this.Mage.Text = "Mage";
            this.Mage.UseVisualStyleBackColor = false;
            this.Mage.Click += new System.EventHandler(this.Mage_Click);
            this.Mage.MouseEnter += new System.EventHandler(this.Mage_MouseEnter);
            this.Mage.MouseLeave += new System.EventHandler(this.Mage_MouseLeave);
            // 
            // Archer
            // 
            this.Archer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Archer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Archer.ForeColor = System.Drawing.SystemColors.Control;
            this.Archer.Image = ((System.Drawing.Image)(resources.GetObject("Archer.Image")));
            this.Archer.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Archer.Location = new System.Drawing.Point(686, 70);
            this.Archer.Name = "Archer";
            this.Archer.Size = new System.Drawing.Size(318, 68);
            this.Archer.TabIndex = 2;
            this.Archer.Text = "Archer";
            this.Archer.UseVisualStyleBackColor = false;
            this.Archer.Click += new System.EventHandler(this.Archer_Click);
            this.Archer.MouseEnter += new System.EventHandler(this.Archer_MouseEnter);
            this.Archer.MouseLeave += new System.EventHandler(this.Archer_MouseLeave);
            // 
            // Priest
            // 
            this.Priest.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Priest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Priest.ForeColor = System.Drawing.SystemColors.Control;
            this.Priest.Image = ((System.Drawing.Image)(resources.GetObject("Priest.Image")));
            this.Priest.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Priest.Location = new System.Drawing.Point(1010, 70);
            this.Priest.Name = "Priest";
            this.Priest.Size = new System.Drawing.Size(318, 68);
            this.Priest.TabIndex = 3;
            this.Priest.Text = "Priest";
            this.Priest.UseVisualStyleBackColor = false;
            this.Priest.Click += new System.EventHandler(this.Priest_Click);
            this.Priest.MouseEnter += new System.EventHandler(this.Priest_MouseEnter);
            this.Priest.MouseLeave += new System.EventHandler(this.Priest_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.ControlText;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.Exit.Location = new System.Drawing.Point(1178, 697);
            this.Exit.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(150, 55);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Main menu";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // warrior_box1
            // 
            this.warrior_box1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("warrior_box1.BackgroundImage")));
            this.warrior_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warrior_box1.Location = new System.Drawing.Point(38, 144);
            this.warrior_box1.Name = "warrior_box1";
            this.warrior_box1.Size = new System.Drawing.Size(318, 76);
            this.warrior_box1.TabIndex = 6;
            this.warrior_box1.TabStop = false;
            this.warrior_box1.Visible = false;
            // 
            // warrior_box2
            // 
            this.warrior_box2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("warrior_box2.BackgroundImage")));
            this.warrior_box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warrior_box2.Location = new System.Drawing.Point(38, 144);
            this.warrior_box2.Name = "warrior_box2";
            this.warrior_box2.Size = new System.Drawing.Size(318, 445);
            this.warrior_box2.TabIndex = 7;
            this.warrior_box2.TabStop = false;
            this.warrior_box2.Visible = false;
            // 
            // mage_box1
            // 
            this.mage_box1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mage_box1.BackgroundImage")));
            this.mage_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mage_box1.Location = new System.Drawing.Point(362, 144);
            this.mage_box1.Name = "mage_box1";
            this.mage_box1.Size = new System.Drawing.Size(318, 76);
            this.mage_box1.TabIndex = 8;
            this.mage_box1.TabStop = false;
            this.mage_box1.Visible = false;
            // 
            // mage_box2
            // 
            this.mage_box2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mage_box2.BackgroundImage")));
            this.mage_box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mage_box2.Location = new System.Drawing.Point(362, 144);
            this.mage_box2.Name = "mage_box2";
            this.mage_box2.Size = new System.Drawing.Size(318, 445);
            this.mage_box2.TabIndex = 9;
            this.mage_box2.TabStop = false;
            this.mage_box2.Visible = false;
            // 
            // archer_box1
            // 
            this.archer_box1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("archer_box1.BackgroundImage")));
            this.archer_box1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.archer_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.archer_box1.Location = new System.Drawing.Point(686, 144);
            this.archer_box1.Name = "archer_box1";
            this.archer_box1.Size = new System.Drawing.Size(318, 76);
            this.archer_box1.TabIndex = 10;
            this.archer_box1.TabStop = false;
            this.archer_box1.Visible = false;
            // 
            // archer_box2
            // 
            this.archer_box2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("archer_box2.BackgroundImage")));
            this.archer_box2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.archer_box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.archer_box2.Location = new System.Drawing.Point(686, 144);
            this.archer_box2.Name = "archer_box2";
            this.archer_box2.Size = new System.Drawing.Size(318, 445);
            this.archer_box2.TabIndex = 11;
            this.archer_box2.TabStop = false;
            this.archer_box2.Visible = false;
            // 
            // priest_box1
            // 
            this.priest_box1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("priest_box1.BackgroundImage")));
            this.priest_box1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.priest_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priest_box1.Location = new System.Drawing.Point(1010, 144);
            this.priest_box1.Name = "priest_box1";
            this.priest_box1.Size = new System.Drawing.Size(318, 76);
            this.priest_box1.TabIndex = 12;
            this.priest_box1.TabStop = false;
            this.priest_box1.Visible = false;
            // 
            // priest_box2
            // 
            this.priest_box2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("priest_box2.BackgroundImage")));
            this.priest_box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priest_box2.Location = new System.Drawing.Point(1010, 144);
            this.priest_box2.Name = "priest_box2";
            this.priest_box2.Size = new System.Drawing.Size(318, 445);
            this.priest_box2.TabIndex = 13;
            this.priest_box2.TabStop = false;
            this.priest_box2.Visible = false;
            // 
            // AI
            // 
            this.AI.AutoSize = true;
            this.AI.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AI.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AI.Checked = true;
            this.AI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AI.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.AI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.AI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AI.Image = ((System.Drawing.Image)(resources.GetObject("AI.Image")));
            this.AI.Location = new System.Drawing.Point(38, 694);
            this.AI.Name = "AI";
            this.AI.Size = new System.Drawing.Size(78, 61);
            this.AI.TabIndex = 14;
            this.AI.Text = "Player";
            this.AI.UseVisualStyleBackColor = false;
            // 
            // WhichTeam
            // 
            this.WhichTeam.AutoSize = true;
            this.WhichTeam.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WhichTeam.ForeColor = System.Drawing.SystemColors.Control;
            this.WhichTeam.Image = ((System.Drawing.Image)(resources.GetObject("WhichTeam.Image")));
            this.WhichTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WhichTeam.Location = new System.Drawing.Point(32, 9);
            this.WhichTeam.Name = "WhichTeam";
            this.WhichTeam.Size = new System.Drawing.Size(0, 31);
            this.WhichTeam.TabIndex = 15;
            this.WhichTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player
            // 
            this.player.AutoSize = true;
            this.player.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(32, 694);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(91, 31);
            this.player.TabIndex = 16;
            this.player.Text = "Is Player";
            // 
            // ch_name
            // 
            this.ch_name.BackColor = System.Drawing.SystemColors.ControlText;
            this.ch_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ch_name.ForeColor = System.Drawing.SystemColors.Menu;
            this.ch_name.Location = new System.Drawing.Point(310, 706);
            this.ch_name.Name = "ch_name";
            this.ch_name.Size = new System.Drawing.Size(158, 31);
            this.ch_name.TabIndex = 17;
            this.ch_name.Text = "Name";
            // 
            // player_name
            // 
            this.player_name.AutoSize = true;
            this.player_name.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.player_name.ForeColor = System.Drawing.SystemColors.Control;
            this.player_name.Image = ((System.Drawing.Image)(resources.GetObject("player_name.Image")));
            this.player_name.Location = new System.Drawing.Point(140, 706);
            this.player_name.Name = "player_name";
            this.player_name.Size = new System.Drawing.Size(169, 31);
            this.player_name.TabIndex = 18;
            this.player_name.Text = "Characker Name:";
            // 
            // CharacterSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.player_name);
            this.Controls.Add(this.ch_name);
            this.Controls.Add(this.player);
            this.Controls.Add(this.WhichTeam);
            this.Controls.Add(this.AI);
            this.Controls.Add(this.priest_box2);
            this.Controls.Add(this.priest_box1);
            this.Controls.Add(this.archer_box2);
            this.Controls.Add(this.archer_box1);
            this.Controls.Add(this.mage_box2);
            this.Controls.Add(this.mage_box1);
            this.Controls.Add(this.warrior_box2);
            this.Controls.Add(this.warrior_box1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Priest);
            this.Controls.Add(this.Archer);
            this.Controls.Add(this.Mage);
            this.Controls.Add(this.Warrior);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Viner Hand ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CharacterSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CharacterSelect";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CharacterSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warrior_box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warrior_box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mage_box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mage_box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archer_box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archer_box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priest_box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priest_box2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Warrior;
        private System.Windows.Forms.Button Mage;
        private System.Windows.Forms.Button Archer;
        private System.Windows.Forms.Button Priest;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.PictureBox warrior_box1;
        private System.Windows.Forms.PictureBox warrior_box2;
        private System.Windows.Forms.PictureBox mage_box1;
        private System.Windows.Forms.PictureBox mage_box2;
        private System.Windows.Forms.PictureBox archer_box1;
        private System.Windows.Forms.PictureBox archer_box2;
        private System.Windows.Forms.PictureBox priest_box1;
        private System.Windows.Forms.PictureBox priest_box2;
        private System.Windows.Forms.CheckBox AI;
        private System.Windows.Forms.Label WhichTeam;
        private System.Windows.Forms.Label player;
        private System.Windows.Forms.TextBox ch_name;
        private System.Windows.Forms.Label player_name;
    }
}