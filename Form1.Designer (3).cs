namespace KolkoKrzyzyk
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKoniec = new System.Windows.Forms.Button();
            this.labelWyniki = new System.Windows.Forms.Label();
            this.buttonZerujWyniki = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(507, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem1.Text = "Nowa gra";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 33);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKoniec
            // 
            this.buttonKoniec.Location = new System.Drawing.Point(117, 231);
            this.buttonKoniec.Name = "buttonKoniec";
            this.buttonKoniec.Size = new System.Drawing.Size(75, 23);
            this.buttonKoniec.TabIndex = 2;
            this.buttonKoniec.Text = "koniec";
            this.buttonKoniec.UseVisualStyleBackColor = true;
            this.buttonKoniec.Click += new System.EventHandler(this.buttonKoniec_Click);
            // 
            // labelWyniki
            // 
            this.labelWyniki.AutoSize = true;
            this.labelWyniki.Location = new System.Drawing.Point(361, 72);
            this.labelWyniki.Name = "labelWyniki";
            this.labelWyniki.Size = new System.Drawing.Size(108, 13);
            this.labelWyniki.TabIndex = 3;
            this.labelWyniki.Text = "X: 0 | O: 0 | Remisy: 0";
            // 
            // buttonZerujWyniki
            // 
            this.buttonZerujWyniki.Location = new System.Drawing.Point(255, 231);
            this.buttonZerujWyniki.Name = "buttonZerujWyniki";
            this.buttonZerujWyniki.Size = new System.Drawing.Size(95, 23);
            this.buttonZerujWyniki.TabIndex = 4;
            this.buttonZerujWyniki.Text = "Zeruj wyniki";
            this.buttonZerujWyniki.UseVisualStyleBackColor = true;
            this.buttonZerujWyniki.Click += new System.EventHandler(this.buttonZerujWyniki_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 266);
            this.Controls.Add(this.buttonZerujWyniki);
            this.Controls.Add(this.labelWyniki);
            this.Controls.Add(this.buttonKoniec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Kolko i krzyzyk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonKoniec;
        private System.Windows.Forms.Label labelWyniki;
        private System.Windows.Forms.Button buttonZerujWyniki;
    }
}


