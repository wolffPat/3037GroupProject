using System.ComponentModel;

namespace MonsterDemo
{
    partial class MonsterSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HardCheckbox = new System.Windows.Forms.CheckBox();
            this.Debug = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DebugResetAll = new System.Windows.Forms.Button();
            this.Folder = new System.Windows.Forms.LinkLabel();
            this.Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // HardCheckbox
            // 
            this.HardCheckbox.AutoSize = true;
            this.HardCheckbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HardCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HardCheckbox.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.HardCheckbox.Location = new System.Drawing.Point(12, 12);
            this.HardCheckbox.Name = "HardCheckbox";
            this.HardCheckbox.Size = new System.Drawing.Size(104, 23);
            this.HardCheckbox.TabIndex = 0;
            this.HardCheckbox.Text = "Hard Mode";
            this.HardCheckbox.UseVisualStyleBackColor = true;
            this.HardCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Debug
            // 
            this.Debug.Controls.Add(this.Folder);
            this.Debug.Controls.Add(this.label1);
            this.Debug.Controls.Add(this.DebugResetAll);
            this.Debug.Location = new System.Drawing.Point(0, 224);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(169, 100);
            this.Debug.TabIndex = 1;
            this.Debug.TabStop = false;
            this.Debug.Text = "DebugBox";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ResetAll";
            // 
            // DebugResetAll
            // 
            this.DebugResetAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DebugResetAll.Location = new System.Drawing.Point(6, 19);
            this.DebugResetAll.Name = "DebugResetAll";
            this.DebugResetAll.Size = new System.Drawing.Size(20, 17);
            this.DebugResetAll.TabIndex = 3;
            this.DebugResetAll.UseVisualStyleBackColor = true;
            this.DebugResetAll.Click += new System.EventHandler(this.DebugResetAll_Click);
            // 
            // Folder
            // 
            this.Folder.AutoSize = true;
            this.Folder.Location = new System.Drawing.Point(127, 84);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(36, 13);
            this.Folder.TabIndex = 5;
            this.Folder.TabStop = true;
            this.Folder.Text = "Folder";
            this.Folder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MonsterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(333, 326);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.HardCheckbox);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonsterSettings";
            this.Opacity = 0.99D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Debug.ResumeLayout(false);
            this.Debug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox HardCheckbox;
        private System.Windows.Forms.GroupBox Debug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DebugResetAll;
        private System.Windows.Forms.LinkLabel Folder;
    }
}