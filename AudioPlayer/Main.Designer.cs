namespace AudioPlayer
{
    partial class Main
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.SongBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpeakerImage = new System.Windows.Forms.PictureBox();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.NextImage = new System.Windows.Forms.PictureBox();
            this.StopImage = new System.Windows.Forms.PictureBox();
            this.PreviousImage = new System.Windows.Forms.PictureBox();
            this.PlayPauseImage = new System.Windows.Forms.PictureBox();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SongBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayPauseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.White;
            this.ControlPanel.Controls.Add(this.SongBar);
            this.ControlPanel.Controls.Add(this.label2);
            this.ControlPanel.Controls.Add(this.label1);
            this.ControlPanel.Controls.Add(this.SpeakerImage);
            this.ControlPanel.Controls.Add(this.VolumeBar);
            this.ControlPanel.Controls.Add(this.NextImage);
            this.ControlPanel.Controls.Add(this.StopImage);
            this.ControlPanel.Controls.Add(this.PreviousImage);
            this.ControlPanel.Controls.Add(this.PlayPauseImage);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlPanel.Location = new System.Drawing.Point(0, 255);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(613, 90);
            this.ControlPanel.TabIndex = 1;
            // 
            // SongBar
            // 
            this.SongBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongBar.AutoSize = false;
            this.SongBar.Location = new System.Drawing.Point(53, 9);
            this.SongBar.Name = "SongBar";
            this.SongBar.Size = new System.Drawing.Size(498, 25);
            this.SongBar.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(557, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "00:00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "00:00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpeakerImage
            // 
            this.SpeakerImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeakerImage.Image = global::AudioPlayer.Properties.Resources.speaker_half;
            this.SpeakerImage.Location = new System.Drawing.Point(482, 52);
            this.SpeakerImage.Name = "SpeakerImage";
            this.SpeakerImage.Size = new System.Drawing.Size(25, 25);
            this.SpeakerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpeakerImage.TabIndex = 5;
            this.SpeakerImage.TabStop = false;
            this.SpeakerImage.Click += new System.EventHandler(this.SpeakerImage_Click);
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeBar.AutoSize = false;
            this.VolumeBar.Location = new System.Drawing.Point(509, 52);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(83, 25);
            this.VolumeBar.TabIndex = 4;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Value = 50;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // NextImage
            // 
            this.NextImage.Image = global::AudioPlayer.Properties.Resources.Next;
            this.NextImage.Location = new System.Drawing.Point(123, 52);
            this.NextImage.Name = "NextImage";
            this.NextImage.Size = new System.Drawing.Size(25, 25);
            this.NextImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NextImage.TabIndex = 3;
            this.NextImage.TabStop = false;
            // 
            // StopImage
            // 
            this.StopImage.Image = global::AudioPlayer.Properties.Resources.Stop;
            this.StopImage.Location = new System.Drawing.Point(92, 52);
            this.StopImage.Name = "StopImage";
            this.StopImage.Size = new System.Drawing.Size(25, 25);
            this.StopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StopImage.TabIndex = 2;
            this.StopImage.TabStop = false;
            // 
            // PreviousImage
            // 
            this.PreviousImage.Image = global::AudioPlayer.Properties.Resources.Previous;
            this.PreviousImage.Location = new System.Drawing.Point(61, 52);
            this.PreviousImage.Name = "PreviousImage";
            this.PreviousImage.Size = new System.Drawing.Size(25, 25);
            this.PreviousImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviousImage.TabIndex = 1;
            this.PreviousImage.TabStop = false;
            // 
            // PlayPauseImage
            // 
            this.PlayPauseImage.Image = global::AudioPlayer.Properties.Resources.Play;
            this.PlayPauseImage.Location = new System.Drawing.Point(7, 47);
            this.PlayPauseImage.Name = "PlayPauseImage";
            this.PlayPauseImage.Size = new System.Drawing.Size(35, 35);
            this.PlayPauseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayPauseImage.TabIndex = 0;
            this.PlayPauseImage.TabStop = false;
            this.PlayPauseImage.Click += new System.EventHandler(this.PlayPauseImage_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(613, 345);
            this.Controls.Add(this.ControlPanel);
            this.MinimumSize = new System.Drawing.Size(323, 130);
            this.Name = "Main";
            this.Text = "Music Player";
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SongBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayPauseImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PlayPauseImage;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox PreviousImage;
        private System.Windows.Forms.PictureBox NextImage;
        private System.Windows.Forms.PictureBox StopImage;
        private System.Windows.Forms.PictureBox SpeakerImage;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.TrackBar SongBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

