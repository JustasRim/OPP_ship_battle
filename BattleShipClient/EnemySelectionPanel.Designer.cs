namespace BattleShipClient
{
    partial class EnemySelectionPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnemySelectionPanel));
            this.LNick = new System.Windows.Forms.Label();
            this.BConnect = new System.Windows.Forms.Button();
            this.DGVAvailableEnemies = new System.Windows.Forms.DataGridView();
            this.IPAndPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnemyNick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvailableEnemies)).BeginInit();
            this.SuspendLayout();
            // 
            // LNick
            // 
            this.LNick.AutoSize = true;
            this.LNick.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
            this.LNick.Location = new System.Drawing.Point(94, 10);
            this.LNick.Name = "LNick";
            this.LNick.Size = new System.Drawing.Size(98, 21);
            this.LNick.TabIndex = 2;
            this.LNick.Text = "Search enemy:";
            // 
            // BConnect
            // 
            this.BConnect.BackColor = System.Drawing.Color.Maroon;
            this.BConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BConnect.ForeColor = System.Drawing.Color.White;
            this.BConnect.Location = new System.Drawing.Point(95, 270);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(266, 23);
            this.BConnect.TabIndex = 6;
            this.BConnect.Text = "Select enemy and play!";
            this.BConnect.UseVisualStyleBackColor = false;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // DGVAvailableEnemies
            // 
            this.DGVAvailableEnemies.AllowUserToAddRows = false;
            this.DGVAvailableEnemies.AllowUserToDeleteRows = false;
            this.DGVAvailableEnemies.AllowUserToResizeRows = false;
            this.DGVAvailableEnemies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVAvailableEnemies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAvailableEnemies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAvailableEnemies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAvailableEnemies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAndPort,
            this.EnemyNick});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAvailableEnemies.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVAvailableEnemies.Location = new System.Drawing.Point(95, 38);
            this.DGVAvailableEnemies.MultiSelect = false;
            this.DGVAvailableEnemies.Name = "DGVAvailableEnemies";
            this.DGVAvailableEnemies.ReadOnly = true;
            this.DGVAvailableEnemies.RowHeadersVisible = false;
            this.DGVAvailableEnemies.Size = new System.Drawing.Size(266, 226);
            this.DGVAvailableEnemies.TabIndex = 7;
            this.DGVAvailableEnemies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAvailableEnemies_CellClick);
            // 
            // IPAndPort
            // 
            this.IPAndPort.HeaderText = "IPAndPort";
            this.IPAndPort.Name = "IPAndPort";
            this.IPAndPort.ReadOnly = true;
            this.IPAndPort.Visible = false;
            // 
            // EnemyNick
            // 
            this.EnemyNick.HeaderText = "Enemy nick";
            this.EnemyNick.Name = "EnemyNick";
            this.EnemyNick.ReadOnly = true;
            this.EnemyNick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EnemyNick.Width = 249;
            // 
            // TBSearch
            // 
            this.TBSearch.BackColor = System.Drawing.Color.White;
            this.TBSearch.Location = new System.Drawing.Point(195, 12);
            this.TBSearch.MaxLength = 16;
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(165, 20);
            this.TBSearch.TabIndex = 8;
            this.TBSearch.TextChanged += new System.EventHandler(this.SearchEnemy);
            // 
            // EnemySelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 300);
            this.Controls.Add(this.TBSearch);
            this.Controls.Add(this.DGVAvailableEnemies);
            this.Controls.Add(this.BConnect);
            this.Controls.Add(this.LNick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnemySelectionPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battleship - enemy selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseApp);
            this.Load += new System.EventHandler(this.EnemySelectionPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvailableEnemies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LNick;
        private System.Windows.Forms.Button BConnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAndPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnemyNick;
        private System.Windows.Forms.TextBox TBSearch;
        public System.Windows.Forms.DataGridView DGVAvailableEnemies;
    }
}