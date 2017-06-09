namespace WindowsFormsScreenSnoop
{
    partial class MainForm
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
            this.PictureBoxSnoop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSnoop)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxSnoop
            // 
            this.PictureBoxSnoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSnoop.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSnoop.Name = "PictureBoxSnoop";
            this.PictureBoxSnoop.Size = new System.Drawing.Size(1898, 1025);
            this.PictureBoxSnoop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxSnoop.TabIndex = 0;
            this.PictureBoxSnoop.TabStop = false;
            this.PictureBoxSnoop.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1025);
            this.Controls.Add(this.PictureBoxSnoop);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSnoop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxSnoop;
    }
}

