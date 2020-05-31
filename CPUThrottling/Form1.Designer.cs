namespace CPUThrottling
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownThrottleStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThrottleEnd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownThrottleStartMaxCPU = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownThrottleEndMaxCPU = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleStartMaxCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleEndMaxCPU)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // numericUpDownThrottleStart
            // 
            this.numericUpDownThrottleStart.Location = new System.Drawing.Point(255, 34);
            this.numericUpDownThrottleStart.Name = "numericUpDownThrottleStart";
            this.numericUpDownThrottleStart.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownThrottleStart.TabIndex = 1;
            this.numericUpDownThrottleStart.Maximum = 200;
            this.numericUpDownThrottleStart.Value = 105;

            // 
            // numericUpDownThrottleEnd
            // 
            this.numericUpDownThrottleEnd.Location = new System.Drawing.Point(255, 104);
            this.numericUpDownThrottleEnd.Name = "numericUpDownThrottleEnd";
            this.numericUpDownThrottleEnd.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownThrottleEnd.TabIndex = 1;
            this.numericUpDownThrottleEnd.Maximum = 200;
            this.numericUpDownThrottleEnd.Value = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Throttle Start Temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Throttle End Temperature";
            // 
            // numericUpDownThrottleStartMaxCPU
            // 
            this.numericUpDownThrottleStartMaxCPU.Location = new System.Drawing.Point(255, 69);
            this.numericUpDownThrottleStartMaxCPU.Name = "numericUpDownThrottleStartMaxCPU";
            this.numericUpDownThrottleStartMaxCPU.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownThrottleStartMaxCPU.TabIndex = 1;
            this.numericUpDownThrottleStartMaxCPU.Value = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Throttle Start Max CPU %";
            // 
            // numericUpDownThrottleEndMaxCPU
            // 
            this.numericUpDownThrottleEndMaxCPU.Location = new System.Drawing.Point(255, 137);
            this.numericUpDownThrottleEndMaxCPU.Name = "numericUpDownThrottleEndMaxCPU";
            this.numericUpDownThrottleEndMaxCPU.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownThrottleEndMaxCPU.TabIndex = 1;
            this.numericUpDownThrottleEndMaxCPU.Value = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Throttle End Max CPU %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownThrottleEndMaxCPU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownThrottleStartMaxCPU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownThrottleEnd);
            this.Controls.Add(this.numericUpDownThrottleStart);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleStartMaxCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThrottleEndMaxCPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownThrottleStart;
        private System.Windows.Forms.NumericUpDown numericUpDownThrottleEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownThrottleStartMaxCPU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownThrottleEndMaxCPU;
        private System.Windows.Forms.Label label5;
    }
}

