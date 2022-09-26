namespace BattleShipClient
{
    partial class OfferingGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferingGame));
            this.label2 = new System.Windows.Forms.Label();
            this.BYes = new System.Windows.Forms.Button();
            this.BNo = new System.Windows.Forms.Button();
            this.CBEneNicks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(101, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enemies want to play with you,";
            // 
            // BYes
            // 
            this.BYes.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BYes.Location = new System.Drawing.Point(107, 212);
            this.BYes.Name = "BYes";
            this.BYes.Size = new System.Drawing.Size(116, 23);
            this.BYes.TabIndex = 7;
            this.BYes.Text = "Start Game";
            this.BYes.UseVisualStyleBackColor = false;
            this.BYes.Click += new System.EventHandler(this.BYes_Click);
            // 
            // BNo
            // 
            this.BNo.BackColor = System.Drawing.Color.Tomato;
            this.BNo.Location = new System.Drawing.Point(240, 212);
            this.BNo.Name = "BNo";
            this.BNo.Size = new System.Drawing.Size(116, 23);
            this.BNo.TabIndex = 8;
            this.BNo.Text = "Decline";
            this.BNo.UseVisualStyleBackColor = false;
            this.BNo.Click += new System.EventHandler(this.BNo_Click);
            // 
            // CBEneNicks
            // 
            this.CBEneNicks.FormattingEnabled = true;
            this.CBEneNicks.Location = new System.Drawing.Point(105, 98);
            this.CBEneNicks.Name = "CBEneNicks";
            this.CBEneNicks.Size = new System.Drawing.Size(251, 21);
            this.CBEneNicks.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(101, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Choose one!";
            // 
            // OfferingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBEneNicks);
            this.Controls.Add(this.BNo);
            this.Controls.Add(this.BYes);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OfferingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship - Let\'s play";
            this.Load += new System.EventHandler(this.OfferingGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BYes;
        private System.Windows.Forms.Button BNo;
        private System.Windows.Forms.ComboBox CBEneNicks;
        private System.Windows.Forms.Label label1;
    }
}