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
            this.LvlLabel1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MonsterDemo.Properties.Resources.squirtle;
            this.pictureBox1.Location = new System.Drawing.Point(151, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 373);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.Tomato;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NameBox.Location = new System.Drawing.Point(260, 14);
            this.NameBox.Margin = new System.Windows.Forms.Padding(0);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(249, 43);
            this.NameBox.TabIndex = 56;
            this.NameBox.TabStop = false;
            this.NameBox.Text = "Grayson";
            this.NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tomato;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(315, 469);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(98, 41);
            this.textBox1.TabIndex = 100;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Level: ";
            // 
            // LvlLabel1
            // 
            this.LvlLabel1.BackColor = System.Drawing.Color.Tomato;
            this.LvlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LvlLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LvlLabel1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvlLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LvlLabel1.Location = new System.Drawing.Point(419, 470);
            this.LvlLabel1.Name = "LvlLabel1";
            this.LvlLabel1.ReadOnly = true;
            this.LvlLabel1.Size = new System.Drawing.Size(121, 40);
            this.LvlLabel1.TabIndex = 1000;
            this.LvlLabel1.TabStop = false;
            this.LvlLabel1.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Tomato;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox4.Location = new System.Drawing.Point(278, 16);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(249, 43);
            this.textBox4.TabIndex = 1002;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Grayson";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.LvlLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainCustomControl";
            this.Size = new System.Drawing.Size(835, 528);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.TextBox LvlLabel1;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox NameBox;
    }
}
