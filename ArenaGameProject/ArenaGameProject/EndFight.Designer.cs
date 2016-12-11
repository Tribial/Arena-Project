namespace ArenaGameProject
{
    partial class EndFight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndFight));
            this.AllyWon = new System.Windows.Forms.PictureBox();
            this.EnemyWon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AllyWon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyWon)).BeginInit();
            this.SuspendLayout();
            // 
            // AllyWon
            // 
            this.AllyWon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AllyWon.BackgroundImage")));
            this.AllyWon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AllyWon.Location = new System.Drawing.Point(0, 0);
            this.AllyWon.Name = "AllyWon";
            this.AllyWon.Size = new System.Drawing.Size(1366, 768);
            this.AllyWon.TabIndex = 0;
            this.AllyWon.TabStop = false;
            this.AllyWon.Visible = false;
            this.AllyWon.Click += new System.EventHandler(this.Won_Click);
            // 
            // EnemyWon
            // 
            this.EnemyWon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnemyWon.BackgroundImage")));
            this.EnemyWon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnemyWon.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EnemyWon.Location = new System.Drawing.Point(0, 0);
            this.EnemyWon.Name = "EnemyWon";
            this.EnemyWon.Size = new System.Drawing.Size(1366, 768);
            this.EnemyWon.TabIndex = 1;
            this.EnemyWon.TabStop = false;
            this.EnemyWon.Visible = false;
            this.EnemyWon.Click += new System.EventHandler(this.Won_Click);
            // 
            // EndFight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.EnemyWon);
            this.Controls.Add(this.AllyWon);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Viner Hand ITC", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EndFight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EndFight";
            this.Load += new System.EventHandler(this.EndFight_Load);
            this.Shown += new System.EventHandler(this.EndFight_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.AllyWon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyWon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox AllyWon;
        private System.Windows.Forms.PictureBox EnemyWon;
    }
}