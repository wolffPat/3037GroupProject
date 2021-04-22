namespace MonsterDemo
{
    partial class MainCustomControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            LvlLabel1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MonsterDemo.Properties.Resources.squirtle;
            this.pictureBox1.Location = new System.Drawing.Point(176, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 373);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.Tomato;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.NameBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NameBox.Location = new System.Drawing.Point(279, 10);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(249, 34);
            this.NameBox.TabIndex = 5;
            this.NameBox.Text = "Grayson";
            this.NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tomato;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(287, 429);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(249, 34);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Level: ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LvlLabel1
            // 
            LvlLabel1.BackColor = System.Drawing.Color.Tomato;
            LvlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            LvlLabel1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            LvlLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            LvlLabel1.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            LvlLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            LvlLabel1.Location = new System.Drawing.Point(455, 429);
            LvlLabel1.Name = "LvlLabel1";
            LvlLabel1.ReadOnly = true;
            LvlLabel1.Size = new System.Drawing.Size(139, 34);
            LvlLabel1.TabIndex = 1000;
            LvlLabel1.TabStop = false;
            LvlLabel1.Text = "0";
            // 
            // MainCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.Controls.Add(LvlLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainCustomControl";
            this.Size = new System.Drawing.Size(835, 528);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static System.Windows.Forms.TextBox LvlLabel1;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox NameBox;
    }
}
