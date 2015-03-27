namespace Relaunch
{
    partial class RelaunchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelaunchForm));
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.imageBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pathBrowse = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Fullscreen = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.addWorker = new System.ComponentModel.BackgroundWorker();
            this.bringBackType = new System.Windows.Forms.ComboBox();
            this.wiatFor = new System.Windows.Forms.Label();
            this.currentApps = new System.Windows.Forms.ListBox();
            this.addApp = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.appListLabel = new System.Windows.Forms.Label();
            this.deleteWorker = new System.ComponentModel.BackgroundWorker();
            this.appNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.BackColor = System.Drawing.Color.Transparent;
            this.pathLabel.Location = new System.Drawing.Point(205, 136);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(30, 13);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "URL:";
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(253, 133);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(300, 22);
            this.pathBox.TabIndex = 5;
            this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.ForeColor = System.Drawing.Color.Black;
            this.save.Location = new System.Drawing.Point(124, 129);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Add";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.Save);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Transparent;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.ForeColor = System.Drawing.Color.Black;
            this.cancel.Location = new System.Drawing.Point(124, 188);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Exit";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.Cancel);
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.BackColor = System.Drawing.Color.Transparent;
            this.imageLabel.Location = new System.Drawing.Point(205, 194);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(41, 13);
            this.imageLabel.TabIndex = 4;
            this.imageLabel.Text = "Image:";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(253, 190);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(300, 22);
            this.imageBox.TabIndex = 10;
            this.imageBox.TextChanged += new System.EventHandler(this.imageBoxTextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(205, 165);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 13);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(253, 162);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(300, 22);
            this.nameBox.TabIndex = 8;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBoxTextChanged);
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(289, 76);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 2;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBoxChanged);
            // 
            // imageBrowse
            // 
            this.imageBrowse.BackColor = System.Drawing.Color.Transparent;
            this.imageBrowse.ForeColor = System.Drawing.Color.Black;
            this.imageBrowse.Location = new System.Drawing.Point(562, 189);
            this.imageBrowse.Name = "imageBrowse";
            this.imageBrowse.Size = new System.Drawing.Size(75, 23);
            this.imageBrowse.TabIndex = 11;
            this.imageBrowse.Text = "Browse";
            this.imageBrowse.UseVisualStyleBackColor = false;
            this.imageBrowse.Click += new System.EventHandler(this.imageClick);
            // 
            // pathBrowse
            // 
            this.pathBrowse.BackColor = System.Drawing.Color.Transparent;
            this.pathBrowse.ForeColor = System.Drawing.Color.Black;
            this.pathBrowse.Location = new System.Drawing.Point(562, 132);
            this.pathBrowse.Name = "pathBrowse";
            this.pathBrowse.Size = new System.Drawing.Size(75, 23);
            this.pathBrowse.TabIndex = 6;
            this.pathBrowse.Text = "Browse";
            this.pathBrowse.UseVisualStyleBackColor = false;
            this.pathBrowse.Visible = false;
            this.pathBrowse.Click += new System.EventHandler(this.pathClick);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Location = new System.Drawing.Point(248, 79);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(35, 13);
            this.typeLabel.TabIndex = 11;
            this.typeLabel.Text = "With:";
            // 
            // previewBox
            // 
            this.previewBox.InitialImage = global::Relaunch.Properties.Resources.relaunch;
            this.previewBox.Location = new System.Drawing.Point(669, 80);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(101, 101);
            this.previewBox.TabIndex = 12;
            this.previewBox.TabStop = false;
            // 
            // previewLabel
            // 
            this.previewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewLabel.AutoSize = true;
            this.previewLabel.BackColor = System.Drawing.Color.Transparent;
            this.previewLabel.Location = new System.Drawing.Point(675, 184);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(46, 13);
            this.previewLabel.TabIndex = 13;
            this.previewLabel.Text = "Preview";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(0, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 50);
            this.label6.TabIndex = 14;
            this.label6.Text = "Relaunch";
            // 
            // Fullscreen
            // 
            this.Fullscreen.AutoSize = true;
            this.Fullscreen.BackColor = System.Drawing.Color.Transparent;
            this.Fullscreen.Checked = true;
            this.Fullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Fullscreen.Location = new System.Drawing.Point(579, 80);
            this.Fullscreen.Name = "Fullscreen";
            this.Fullscreen.Size = new System.Drawing.Size(78, 17);
            this.Fullscreen.TabIndex = 3;
            this.Fullscreen.Text = "Fullscreen";
            this.Fullscreen.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 243);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(787, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 15;
            // 
            // addWorker
            // 
            this.addWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.createLauncher);
            this.addWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.create_Launcher_RunWorkerCompleted);
            // 
            // bringBackType
            // 
            this.bringBackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bringBackType.FormattingEnabled = true;
            this.bringBackType.Items.AddRange(new object[] {
            "Green Button",
            "Close  App"});
            this.bringBackType.Location = new System.Drawing.Point(472, 76);
            this.bringBackType.Name = "bringBackType";
            this.bringBackType.Size = new System.Drawing.Size(101, 21);
            this.bringBackType.TabIndex = 3;
            // 
            // wiatFor
            // 
            this.wiatFor.AutoSize = true;
            this.wiatFor.BackColor = System.Drawing.Color.Transparent;
            this.wiatFor.Location = new System.Drawing.Point(420, 80);
            this.wiatFor.Name = "wiatFor";
            this.wiatFor.Size = new System.Drawing.Size(46, 13);
            this.wiatFor.TabIndex = 16;
            this.wiatFor.Text = "Trigger:";
            // 
            // currentApps
            // 
            this.currentApps.FormattingEnabled = true;
            this.currentApps.Location = new System.Drawing.Point(12, 77);
            this.currentApps.Name = "currentApps";
            this.currentApps.Size = new System.Drawing.Size(106, 134);
            this.currentApps.TabIndex = 0;
            this.currentApps.TabStop = false;
            this.currentApps.SelectedIndexChanged += new System.EventHandler(this.currentApps_SelectedIndexChanged);
            // 
            // addApp
            // 
            this.addApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addApp.FormattingEnabled = true;
            this.addApp.Items.AddRange(new object[] {
            "Youtube TV",
            "YoutubeXL",
            "Youtube Leanback",
            "Pandora",
            "Clicker.tv",
            "Hulu Desktop",
            "Google TV Spotlight",
            "Vimeo Couch Mode",
            "Google Reader Play",
            "Steam",
            "Custom"});
            this.addApp.Location = new System.Drawing.Point(124, 77);
            this.addApp.Name = "addApp";
            this.addApp.Size = new System.Drawing.Size(110, 21);
            this.addApp.TabIndex = 1;
            this.addApp.Tag = "";
            this.addApp.SelectedIndexChanged += new System.EventHandler(this.addApp_SelectedIndexChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.ForeColor = System.Drawing.Color.Black;
            this.deleteButton.Location = new System.Drawing.Point(124, 158);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Remove";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // appListLabel
            // 
            this.appListLabel.AutoSize = true;
            this.appListLabel.BackColor = System.Drawing.Color.Transparent;
            this.appListLabel.Location = new System.Drawing.Point(27, 61);
            this.appListLabel.Name = "appListLabel";
            this.appListLabel.Size = new System.Drawing.Size(71, 13);
            this.appListLabel.TabIndex = 0;
            this.appListLabel.Text = "Current Tiles";
            // 
            // deleteWorker
            // 
            this.deleteWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.removeApplication);
            this.deleteWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.removeApplication_RunWorkerCompleted);
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.appNameLabel.Location = new System.Drawing.Point(135, 61);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(82, 13);
            this.appNameLabel.TabIndex = 21;
            this.appNameLabel.Text = "App to Launch";
            // 
            // RelaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Relaunch.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(787, 266);
            this.Controls.Add(this.appNameLabel);
            this.Controls.Add(this.appListLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addApp);
            this.Controls.Add(this.currentApps);
            this.Controls.Add(this.wiatFor);
            this.Controls.Add(this.bringBackType);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Fullscreen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.save);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.imageBrowse);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.pathBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RelaunchForm";
            this.Text = "Relaunch";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.TextBox imageBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button imageBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button pathBrowse;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Fullscreen;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker addWorker;
        private System.Windows.Forms.ComboBox bringBackType;
        private System.Windows.Forms.Label wiatFor;
        private System.Windows.Forms.ListBox currentApps;
        private System.Windows.Forms.ComboBox addApp;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label appListLabel;
        private System.ComponentModel.BackgroundWorker deleteWorker;
        private System.Windows.Forms.Label appNameLabel;
    }
}

