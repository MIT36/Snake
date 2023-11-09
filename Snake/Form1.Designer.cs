namespace WinFormsSnake
{
    partial class MainForm
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
            pbArea = new PictureBox();
            lblInfo = new Label();
            lblCountLevel = new Label();
            lblScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pbArea).BeginInit();
            SuspendLayout();
            // 
            // pbArea
            // 
            pbArea.BackColor = Color.Turquoise;
            pbArea.BorderStyle = BorderStyle.FixedSingle;
            pbArea.Location = new Point(12, 12);
            pbArea.MaximumSize = new Size(1200, 1000);
            pbArea.MinimumSize = new Size(300, 300);
            pbArea.Name = "pbArea";
            pbArea.Size = new Size(600, 400);
            pbArea.TabIndex = 2;
            pbArea.TabStop = false;
            pbArea.Paint += panel_Paint;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblInfo.Location = new Point(618, 352);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(168, 60);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Enter:           Start/Stop\r\nBackspace:  Reset\r\nEsc:              Exit";
            // 
            // lblCountLevel
            // 
            lblCountLevel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCountLevel.AutoSize = true;
            lblCountLevel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCountLevel.Location = new Point(660, 12);
            lblCountLevel.Name = "lblCountLevel";
            lblCountLevel.Size = new Size(84, 28);
            lblCountLevel.TabIndex = 4;
            lblCountLevel.Text = "Level: 1";
            lblCountLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            lblScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.Location = new Point(660, 54);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(87, 28);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score: 0";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(787, 428);
            Controls.Add(lblScore);
            Controls.Add(lblCountLevel);
            Controls.Add(lblInfo);
            Controls.Add(pbArea);
            KeyPreview = true;
            Name = "MainForm";
            Text = "Snake";
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pbArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbArea;
        private Label lblInfo;
        private Label lblCountLevel;
        private Label lblScore;
    }
}