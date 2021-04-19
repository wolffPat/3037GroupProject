namespace MonsterDemo
{
    partial class MainForm
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;
       
        
        /// 
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button statTab;
        private System.Windows.Forms.Button monsterTab;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Button fightTab;
        private System.Windows.Forms.Button CloseButton;
        private MainCustomControl mainCustomControl;
        private StatsCustomControl statsCustomControl;
        private Fight fight;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button sizeToggleButton;

        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.fightTab = new System.Windows.Forms.Button();
            this.statTab = new System.Windows.Forms.Button();
            this.monsterTab = new System.Windows.Forms.Button();
            this.sizeToggleButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.fight = new MonsterDemo.Fight();
            this.statsCustomControl = new MonsterDemo.StatsCustomControl();
            this.mainCustomControl = new MonsterDemo.MainCustomControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.fightTab);
            this.panel1.Controls.Add(this.statTab);
            this.panel1.Controls.Add(this.monsterTab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 599);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.SidePanel.Location = new System.Drawing.Point(1, 14);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 54);
            this.SidePanel.TabIndex = 4;
            // 
            // fightTab
            // 
            this.fightTab.FlatAppearance.BorderSize = 0;
            this.fightTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fightTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fightTab.ForeColor = System.Drawing.Color.White;
            this.fightTab.Image = global::MonsterDemo.Properties.Resources.Sword;
            this.fightTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fightTab.Location = new System.Drawing.Point(9, 134);
            this.fightTab.Name = "fightTab";
            this.fightTab.Size = new System.Drawing.Size(197, 54);
            this.fightTab.TabIndex = 4;
            this.fightTab.Text = "       Fight";
            this.fightTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.fightTab.UseVisualStyleBackColor = true;
            this.fightTab.Click += new System.EventHandler(this.fightTab_Click);
            // 
            // statTab
            // 
            this.statTab.FlatAppearance.BorderSize = 0;
            this.statTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statTab.ForeColor = System.Drawing.Color.White;
            this.statTab.Image = global::MonsterDemo.Properties.Resources.Stats;
            this.statTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statTab.Location = new System.Drawing.Point(9, 74);
            this.statTab.Name = "statTab";
            this.statTab.Size = new System.Drawing.Size(197, 54);
            this.statTab.TabIndex = 4;
            this.statTab.Text = "        Stats";
            this.statTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.statTab.UseVisualStyleBackColor = true;
            this.statTab.Click += new System.EventHandler(this.StatsButtonClick);
            // 
            // monsterTab
            // 
            this.monsterTab.FlatAppearance.BorderSize = 0;
            this.monsterTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monsterTab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monsterTab.ForeColor = System.Drawing.Color.White;
            this.monsterTab.Image = global::MonsterDemo.Properties.Resources.home;
            this.monsterTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.monsterTab.Location = new System.Drawing.Point(9, 14);
            this.monsterTab.Name = "monsterTab";
            this.monsterTab.Size = new System.Drawing.Size(197, 54);
            this.monsterTab.TabIndex = 4;
            this.monsterTab.Text = "       Monster";
            this.monsterTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.monsterTab.UseVisualStyleBackColor = true;
            this.monsterTab.Click += new System.EventHandler(this.HomeButtonClick);
            // 
            // sizeToggleButton
            // 
            this.sizeToggleButton.FlatAppearance.BorderSize = 0;
            this.sizeToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeToggleButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeToggleButton.ForeColor = System.Drawing.Color.White;
            this.sizeToggleButton.Image = global::MonsterDemo.Properties.Resources.Minimize3;
            this.sizeToggleButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sizeToggleButton.Location = new System.Drawing.Point(941, 15);
            this.sizeToggleButton.Name = "sizeToggleButton";
            this.sizeToggleButton.Size = new System.Drawing.Size(44, 34);
            this.sizeToggleButton.TabIndex = 8;
            this.sizeToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.sizeToggleButton.UseVisualStyleBackColor = true;
            this.sizeToggleButton.Click += new System.EventHandler(this.SizeToggleButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Image = global::MonsterDemo.Properties.Resources.Tool;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(882, 15);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(44, 34);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseButton.Location = new System.Drawing.Point(1006, 15);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(35, 34);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // fight
            // 
            this.fight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.fight.Location = new System.Drawing.Point(215, 59);
            this.fight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fight.Name = "fight";
            this.fight.Padding = new System.Windows.Forms.Padding(10);
            this.fight.Size = new System.Drawing.Size(835, 528);
            this.fight.TabIndex = 7;
            // 
            // statsCustomControl
            // 
            this.statsCustomControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.statsCustomControl.Location = new System.Drawing.Point(215, 59);
            this.statsCustomControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statsCustomControl.Name = "statsCustomControl";
            this.statsCustomControl.Padding = new System.Windows.Forms.Padding(10);
            this.statsCustomControl.Size = new System.Drawing.Size(835, 528);
            this.statsCustomControl.TabIndex = 6;
            // 
            // mainCustomControl
            // 
            this.mainCustomControl.BackColor = System.Drawing.Color.Tomato;
            this.mainCustomControl.Location = new System.Drawing.Point(215, 59);
            this.mainCustomControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainCustomControl.Name = "mainCustomControl";
            this.mainCustomControl.Padding = new System.Windows.Forms.Padding(10);
            this.mainCustomControl.Size = new System.Drawing.Size(835, 528);
            this.mainCustomControl.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1062, 599);
            this.Controls.Add(this.sizeToggleButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainCustomControl);
            this.Controls.Add(this.fight);
            this.Controls.Add(this.statsCustomControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
    }
}

