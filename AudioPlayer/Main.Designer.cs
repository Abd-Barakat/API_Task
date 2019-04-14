namespace AudioPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.SongBar = new System.Windows.Forms.TrackBar();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.SpeakerImage = new System.Windows.Forms.PictureBox();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.NextImage = new System.Windows.Forms.PictureBox();
            this.StopImage = new System.Windows.Forms.PictureBox();
            this.PreviousImage = new System.Windows.Forms.PictureBox();
            this.PlayPauseImage = new System.Windows.Forms.PictureBox();
            this.musicTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayList = new System.Windows.Forms.ListBox();
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
            this.ControlPanel.Controls.Add(this.EndLabel);
            this.ControlPanel.Controls.Add(this.StartLabel);
            this.ControlPanel.Controls.Add(this.SpeakerImage);
            this.ControlPanel.Controls.Add(this.VolumeBar);
            this.ControlPanel.Controls.Add(this.NextImage);
            this.ControlPanel.Controls.Add(this.StopImage);
            this.ControlPanel.Controls.Add(this.PreviousImage);
            this.ControlPanel.Controls.Add(this.PlayPauseImage);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlPanel.Location = new System.Drawing.Point(0, 255);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(613, 90);
            this.ControlPanel.TabIndex = 1;
            // 
            // SongBar
            // 
            this.SongBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongBar.AutoSize = false;
            this.SongBar.LargeChange = 2000;
            this.SongBar.Location = new System.Drawing.Point(53, 9);
            this.SongBar.Maximum = 20000;
            this.SongBar.Name = "SongBar";
            this.SongBar.Size = new System.Drawing.Size(498, 25);
            this.SongBar.TabIndex = 8;
            this.SongBar.TickFrequency = 0;
            this.SongBar.Scroll += new System.EventHandler(this.SongBar_Scroll);
            this.SongBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SongBar_MouseDown);
            this.SongBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SongBar_MouseUp);
            // 
            // EndLabel
            // 
            this.EndLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndLabel.Location = new System.Drawing.Point(557, 9);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(35, 25);
            this.EndLabel.TabIndex = 7;
            this.EndLabel.Text = "00:00";
            this.EndLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartLabel
            // 
            this.StartLabel.Location = new System.Drawing.Point(12, 9);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(35, 25);
            this.StartLabel.TabIndex = 6;
            this.StartLabel.Text = "00:00";
            this.StartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpeakerImage
            // 
            this.SpeakerImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeakerImage.Image = ((System.Drawing.Image)(resources.GetObject("SpeakerImage.Image")));
            this.SpeakerImage.Location = new System.Drawing.Point(482, 52);
            this.SpeakerImage.Name = "SpeakerImage";
            this.SpeakerImage.Size = new System.Drawing.Size(25, 25);
            this.SpeakerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.NextImage.Click += new System.EventHandler(this.NextImage_Click);
            // 
            // StopImage
            // 
            this.StopImage.Image = global::AudioPlayer.Properties.Resources.Stop1;
            this.StopImage.Location = new System.Drawing.Point(92, 52);
            this.StopImage.Name = "StopImage";
            this.StopImage.Size = new System.Drawing.Size(25, 25);
            this.StopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StopImage.TabIndex = 2;
            this.StopImage.TabStop = false;
            this.StopImage.Click += new System.EventHandler(this.StopImage_Click);
            // 
            // PreviousImage
            // 
            this.PreviousImage.Image = global::AudioPlayer.Properties.Resources.Previous;
            this.PreviousImage.Location = new System.Drawing.Point(61, 52);
            this.PreviousImage.Name = "PreviousImage";
            this.PreviousImage.Size = new System.Drawing.Size(25, 25);
            this.PreviousImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousImage.TabIndex = 1;
            this.PreviousImage.TabStop = false;
            this.PreviousImage.Click += new System.EventHandler(this.PreviousImage_Click);
            // 
            // PlayPauseImage
            // 
            this.PlayPauseImage.Image = global::AudioPlayer.Properties.Resources.Play;
            this.PlayPauseImage.Location = new System.Drawing.Point(12, 47);
            this.PlayPauseImage.Name = "PlayPauseImage";
            this.PlayPauseImage.Size = new System.Drawing.Size(35, 35);
            this.PlayPauseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayPauseImage.TabIndex = 0;
            this.PlayPauseImage.TabStop = false;
            this.PlayPauseImage.Click += new System.EventHandler(this.PlayPauseImage_Click);
            // 
            // musicTimer
            // 
            this.musicTimer.Interval = 1;
            this.musicTimer.Tick += new System.EventHandler(this.musicTimer_Tick);
            // 
            // PlayList
            // 
            this.PlayList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayList.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlayList.FormattingEnabled = true;
            this.PlayList.Location = new System.Drawing.Point(450, 0);
            this.PlayList.Margin = new System.Windows.Forms.Padding(0);
            this.PlayList.Name = "PlayList";
            this.PlayList.Size = new System.Drawing.Size(163, 255);
            this.PlayList.TabIndex = 9;
            this.PlayList.SelectedIndexChanged += new System.EventHandler(this.PlayList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(613, 345);
            this.Controls.Add(this.PlayList);
            this.Controls.Add(this.ControlPanel);
            this.MinimumSize = new System.Drawing.Size(323, 130);
            this.Name = "MainForm";
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
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Timer musicTimer;
        private System.Windows.Forms.ListBox PlayList;
    }
}

