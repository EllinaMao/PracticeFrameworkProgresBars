namespace PracticeFramework
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.createProgressBar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.DeletePB = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DeletePB);
            this.panel1.Controls.Add(this.createProgressBar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 33);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Controls.Add(this.progressBar2);
            this.flowLayoutPanel1.Controls.Add(this.progressBar3);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 417);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Shuffle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(770, 39);
            this.progressBar1.TabIndex = 0;
            // 
            // createProgressBar
            // 
            this.createProgressBar.Location = new System.Drawing.Point(551, 7);
            this.createProgressBar.Name = "createProgressBar";
            this.createProgressBar.Size = new System.Drawing.Size(75, 23);
            this.createProgressBar.TabIndex = 1;
            this.createProgressBar.Text = "Create";
            this.createProgressBar.UseVisualStyleBackColor = true;
            this.createProgressBar.Click += new System.EventHandler(this.createProgressBar_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(3, 48);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(770, 39);
            this.progressBar2.TabIndex = 1;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(3, 93);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(770, 39);
            this.progressBar3.TabIndex = 2;
            // 
            // DeletePB
            // 
            this.DeletePB.Location = new System.Drawing.Point(632, 6);
            this.DeletePB.Name = "DeletePB";
            this.DeletePB.Size = new System.Drawing.Size(75, 23);
            this.DeletePB.TabIndex = 2;
            this.DeletePB.Text = "Delete";
            this.DeletePB.UseVisualStyleBackColor = true;
            this.DeletePB.Click += new System.EventHandler(this.DeletePB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button createProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Button DeletePB;
    }
}

