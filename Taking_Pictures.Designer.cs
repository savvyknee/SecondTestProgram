namespace SecondTestProgram
{
    partial class Taking_Pictures
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.startPreviewButton = new System.Windows.Forms.Button();
            this.snapPictureButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.webcamSelectText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startPreviewButton
            // 
            this.startPreviewButton.Location = new System.Drawing.Point(12, 639);
            this.startPreviewButton.Name = "startPreviewButton";
            this.startPreviewButton.Size = new System.Drawing.Size(92, 40);
            this.startPreviewButton.TabIndex = 7;
            this.startPreviewButton.Text = "Start Preview";
            this.startPreviewButton.UseVisualStyleBackColor = true;
            this.startPreviewButton.Click += new System.EventHandler(this.startPreviewButton_Click);
            // 
            // snapPictureButton
            // 
            this.snapPictureButton.Enabled = false;
            this.snapPictureButton.Location = new System.Drawing.Point(165, 639);
            this.snapPictureButton.Name = "snapPictureButton";
            this.snapPictureButton.Size = new System.Drawing.Size(92, 40);
            this.snapPictureButton.TabIndex = 8;
            this.snapPictureButton.Text = "Snap Picture";
            this.snapPictureButton.UseVisualStyleBackColor = true;
            this.snapPictureButton.Click += new System.EventHandler(this.snapPictureButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(12, 142);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(386, 449);
            this.previewBox.TabIndex = 9;
            this.previewBox.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 612);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(387, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(306, 639);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(92, 44);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop And Quit";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // webcamSelectText
            // 
            this.webcamSelectText.AutoSize = true;
            this.webcamSelectText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webcamSelectText.Location = new System.Drawing.Point(173, 594);
            this.webcamSelectText.Name = "webcamSelectText";
            this.webcamSelectText.Size = new System.Drawing.Size(225, 15);
            this.webcamSelectText.TabIndex = 12;
            this.webcamSelectText.Text = "Begin By Selecting Your WebCam:";
            this.webcamSelectText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 124);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Taking_Pictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webcamSelectText);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.snapPictureButton);
            this.Controls.Add(this.startPreviewButton);
            this.Name = "Taking_Pictures";
            this.Text = "Take Some Pictures";
            this.Load += new System.EventHandler(this.Taking_Pictures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button startPreviewButton;
        private System.Windows.Forms.Button snapPictureButton;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label webcamSelectText;
        private System.Windows.Forms.Panel panel1;
    }
}