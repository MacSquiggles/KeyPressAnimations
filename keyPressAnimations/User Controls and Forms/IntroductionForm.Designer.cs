﻿namespace keyPressAnimations
{
    partial class IntroductionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionForm));
            this.playButton = new System.Windows.Forms.Button();
            this.introLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.monsterPictureBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.SlateGray;
            this.playButton.Font = new System.Drawing.Font("Segoe Script", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(39, 606);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(820, 78);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play Game";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // introLabel
            // 
            this.introLabel.BackColor = System.Drawing.Color.White;
            this.introLabel.Font = new System.Drawing.Font("Segoe Script", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(3, 118);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(894, 461);
            this.introLabel.TabIndex = 1;
            this.introLabel.Text = resources.GetString("introLabel.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::keyPressAnimations.Properties.Resources.down;
            this.pictureBox1.Location = new System.Drawing.Point(585, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // monsterPictureBox
            // 
            this.monsterPictureBox.BackgroundImage = global::keyPressAnimations.Properties.Resources.monLeft;
            this.monsterPictureBox.Location = new System.Drawing.Point(585, 207);
            this.monsterPictureBox.Name = "monsterPictureBox";
            this.monsterPictureBox.Size = new System.Drawing.Size(40, 40);
            this.monsterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.monsterPictureBox.TabIndex = 3;
            this.monsterPictureBox.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Location = new System.Drawing.Point(832, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(64, 58);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // IntroductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::keyPressAnimations.Properties.Resources.bleu1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.monsterPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.introLabel);
            this.Controls.Add(this.playButton);
            this.Name = "IntroductionForm";
            this.Size = new System.Drawing.Size(898, 698);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox monsterPictureBox;
        private System.Windows.Forms.Button exitButton;
    }
}
