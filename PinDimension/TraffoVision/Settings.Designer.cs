namespace TraffoVision
{
    partial class Settings
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.debugLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnSubRight = new System.Windows.Forms.Button();
            this.btnSubLeft = new System.Windows.Forms.Button();
            this.btnTestProcess = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.Name = new System.Windows.Forms.Label();
            this.lbMainLineRight = new System.Windows.Forms.Label();
            this.lbMainLineLeft = new System.Windows.Forms.Label();
            this.tbNamePN = new System.Windows.Forms.TextBox();
            this.btnProcessRight = new System.Windows.Forms.Button();
            this.btnProcessLeft = new System.Windows.Forms.Button();
            this.tbLine2 = new System.Windows.Forms.TrackBar();
            this.tbLine1 = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnAddRight = new System.Windows.Forms.Button();
            this.btnAddLeft = new System.Windows.Forms.Button();
            this.midPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pbPinCropRight = new System.Windows.Forms.PictureBox();
            this.pbPinCropLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 798);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1830, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // debugLabel
            // 
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.btnSubRight);
            this.topPanel.Controls.Add(this.btnSubLeft);
            this.topPanel.Controls.Add(this.btnTestProcess);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.cbModel);
            this.topPanel.Controls.Add(this.Name);
            this.topPanel.Controls.Add(this.lbMainLineRight);
            this.topPanel.Controls.Add(this.lbMainLineLeft);
            this.topPanel.Controls.Add(this.tbNamePN);
            this.topPanel.Controls.Add(this.btnProcessRight);
            this.topPanel.Controls.Add(this.btnProcessLeft);
            this.topPanel.Controls.Add(this.tbLine2);
            this.topPanel.Controls.Add(this.tbLine1);
            this.topPanel.Controls.Add(this.btnSave);
            this.topPanel.Controls.Add(this.btnTrigger);
            this.topPanel.Controls.Add(this.btnAddRight);
            this.topPanel.Controls.Add(this.btnAddLeft);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1830, 76);
            this.topPanel.TabIndex = 3;
            // 
            // btnSubRight
            // 
            this.btnSubRight.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubRight.FlatAppearance.BorderSize = 0;
            this.btnSubRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubRight.Image = global::MultiDisplay.Properties.Resources.minus_circle;
            this.btnSubRight.Location = new System.Drawing.Point(1612, 17);
            this.btnSubRight.Name = "btnSubRight";
            this.btnSubRight.Size = new System.Drawing.Size(42, 42);
            this.btnSubRight.TabIndex = 23;
            this.btnSubRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubRight.UseVisualStyleBackColor = false;
            this.btnSubRight.Click += new System.EventHandler(this.btnSubRight_Click);
            // 
            // btnSubLeft
            // 
            this.btnSubLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnSubLeft.FlatAppearance.BorderSize = 0;
            this.btnSubLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubLeft.Image = global::MultiDisplay.Properties.Resources.minus_circle;
            this.btnSubLeft.Location = new System.Drawing.Point(60, 16);
            this.btnSubLeft.Name = "btnSubLeft";
            this.btnSubLeft.Size = new System.Drawing.Size(42, 42);
            this.btnSubLeft.TabIndex = 22;
            this.btnSubLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubLeft.UseVisualStyleBackColor = false;
            this.btnSubLeft.Click += new System.EventHandler(this.btnSubLeft_Click);
            // 
            // btnTestProcess
            // 
            this.btnTestProcess.Image = global::MultiDisplay.Properties.Resources.web_test;
            this.btnTestProcess.Location = new System.Drawing.Point(752, 12);
            this.btnTestProcess.Name = "btnTestProcess";
            this.btnTestProcess.Size = new System.Drawing.Size(42, 42);
            this.btnTestProcess.TabIndex = 21;
            this.btnTestProcess.UseVisualStyleBackColor = true;
            this.btnTestProcess.Click += new System.EventHandler(this.btnTestProcess_Click);
            // 
            // button1
            // 
            this.button1.Image = global::MultiDisplay.Properties.Resources.download;
            this.button1.Location = new System.Drawing.Point(948, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 42);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(898, 28);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(44, 21);
            this.cbModel.TabIndex = 9;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(848, 12);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(35, 13);
            this.Name.TabIndex = 19;
            this.Name.Text = "Name";
            // 
            // lbMainLineRight
            // 
            this.lbMainLineRight.AutoSize = true;
            this.lbMainLineRight.Location = new System.Drawing.Point(1799, 32);
            this.lbMainLineRight.Name = "lbMainLineRight";
            this.lbMainLineRight.Size = new System.Drawing.Size(13, 13);
            this.lbMainLineRight.TabIndex = 18;
            this.lbMainLineRight.Text = "0";
            // 
            // lbMainLineLeft
            // 
            this.lbMainLineLeft.AutoSize = true;
            this.lbMainLineLeft.Location = new System.Drawing.Point(258, 31);
            this.lbMainLineLeft.Name = "lbMainLineLeft";
            this.lbMainLineLeft.Size = new System.Drawing.Size(13, 13);
            this.lbMainLineLeft.TabIndex = 17;
            this.lbMainLineLeft.Text = "0";
            // 
            // tbNamePN
            // 
            this.tbNamePN.Location = new System.Drawing.Point(848, 28);
            this.tbNamePN.Name = "tbNamePN";
            this.tbNamePN.Size = new System.Drawing.Size(44, 20);
            this.tbNamePN.TabIndex = 7;
            // 
            // btnProcessRight
            // 
            this.btnProcessRight.Image = global::MultiDisplay.Properties.Resources.process;
            this.btnProcessRight.Location = new System.Drawing.Point(1660, 17);
            this.btnProcessRight.Name = "btnProcessRight";
            this.btnProcessRight.Size = new System.Drawing.Size(42, 42);
            this.btnProcessRight.TabIndex = 16;
            this.btnProcessRight.UseVisualStyleBackColor = true;
            this.btnProcessRight.Click += new System.EventHandler(this.btnProcessRight_Click);
            // 
            // btnProcessLeft
            // 
            this.btnProcessLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnProcessLeft.FlatAppearance.BorderSize = 0;
            this.btnProcessLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcessLeft.Image = global::MultiDisplay.Properties.Resources.process;
            this.btnProcessLeft.Location = new System.Drawing.Point(108, 16);
            this.btnProcessLeft.Name = "btnProcessLeft";
            this.btnProcessLeft.Size = new System.Drawing.Size(42, 42);
            this.btnProcessLeft.TabIndex = 15;
            this.btnProcessLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcessLeft.UseVisualStyleBackColor = false;
            this.btnProcessLeft.Click += new System.EventHandler(this.btnProcessLeft_Click);
            // 
            // tbLine2
            // 
            this.tbLine2.Location = new System.Drawing.Point(1708, 17);
            this.tbLine2.Maximum = 2000;
            this.tbLine2.Name = "tbLine2";
            this.tbLine2.Size = new System.Drawing.Size(104, 45);
            this.tbLine2.TabIndex = 14;
            this.tbLine2.Value = 1017;
            this.tbLine2.Scroll += new System.EventHandler(this.tbLine2_Scroll);
            // 
            // tbLine1
            // 
            this.tbLine1.Location = new System.Drawing.Point(167, 16);
            this.tbLine1.Maximum = 2000;
            this.tbLine1.Name = "tbLine1";
            this.tbLine1.Size = new System.Drawing.Size(104, 45);
            this.tbLine1.TabIndex = 13;
            this.tbLine1.Value = 706;
            this.tbLine1.Scroll += new System.EventHandler(this.tbLine1_Scroll);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::MultiDisplay.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(996, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(42, 42);
            this.btnSave.TabIndex = 10;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Image = global::MultiDisplay.Properties.Resources.camera__circle;
            this.btnTrigger.Location = new System.Drawing.Point(800, 12);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(42, 42);
            this.btnTrigger.TabIndex = 9;
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // btnAddRight
            // 
            this.btnAddRight.Image = global::MultiDisplay.Properties.Resources.add;
            this.btnAddRight.Location = new System.Drawing.Point(1564, 17);
            this.btnAddRight.Name = "btnAddRight";
            this.btnAddRight.Size = new System.Drawing.Size(42, 42);
            this.btnAddRight.TabIndex = 8;
            this.btnAddRight.UseVisualStyleBackColor = true;
            this.btnAddRight.Click += new System.EventHandler(this.btnAddRight_Click);
            // 
            // btnAddLeft
            // 
            this.btnAddLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnAddLeft.FlatAppearance.BorderSize = 0;
            this.btnAddLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddLeft.Image = global::MultiDisplay.Properties.Resources.add;
            this.btnAddLeft.Location = new System.Drawing.Point(12, 16);
            this.btnAddLeft.Name = "btnAddLeft";
            this.btnAddLeft.Size = new System.Drawing.Size(42, 42);
            this.btnAddLeft.TabIndex = 7;
            this.btnAddLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddLeft.UseVisualStyleBackColor = false;
            this.btnAddLeft.Click += new System.EventHandler(this.btnAddLeft_Click);
            // 
            // midPanel
            // 
            this.midPanel.Location = new System.Drawing.Point(97, 8);
            this.midPanel.Name = "midPanel";
            this.midPanel.Size = new System.Drawing.Size(1, 1);
            this.midPanel.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(669, 511);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(183, 148);
            this.listView1.TabIndex = 24;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1573, 511);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(183, 148);
            this.listView2.TabIndex = 25;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Image = global::MultiDisplay.Properties.Resources.process;
            this.button3.Location = new System.Drawing.Point(873, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 42);
            this.button3.TabIndex = 26;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = global::MultiDisplay.Properties.Resources.process;
            this.button2.Location = new System.Drawing.Point(873, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 42);
            this.button2.TabIndex = 24;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbPinCropRight
            // 
            this.pbPinCropRight.Location = new System.Drawing.Point(940, 511);
            this.pbPinCropRight.Name = "pbPinCropRight";
            this.pbPinCropRight.Size = new System.Drawing.Size(209, 148);
            this.pbPinCropRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPinCropRight.TabIndex = 8;
            this.pbPinCropRight.TabStop = false;
            // 
            // pbPinCropLeft
            // 
            this.pbPinCropLeft.Location = new System.Drawing.Point(36, 511);
            this.pbPinCropLeft.Name = "pbPinCropLeft";
            this.pbPinCropLeft.Size = new System.Drawing.Size(213, 148);
            this.pbPinCropLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPinCropLeft.TabIndex = 7;
            this.pbPinCropLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.Image = global::MultiDisplay.Properties.Resources._2;
            this.pbRight.Location = new System.Drawing.Point(940, 82);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(816, 408);
            this.pbRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRight.TabIndex = 6;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.Image = global::MultiDisplay.Properties.Resources._1;
            this.pbLeft.Location = new System.Drawing.Point(36, 82);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(816, 408);
            this.pbLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeft.TabIndex = 5;
            this.pbLeft.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(895, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Select";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1830, 820);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pbPinCropRight);
            this.Controls.Add(this.pbPinCropLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.midPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.statusStrip);
            this.Text = "P/N Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel debugLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel midPanel;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnAddRight;
        private System.Windows.Forms.Button btnAddLeft;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnProcessRight;
        private System.Windows.Forms.Button btnProcessLeft;
        private System.Windows.Forms.TrackBar tbLine2;
        private System.Windows.Forms.TrackBar tbLine1;
        private System.Windows.Forms.Label lbMainLineRight;
        private System.Windows.Forms.Label lbMainLineLeft;
        private System.Windows.Forms.TextBox tbNamePN;
        private System.Windows.Forms.PictureBox pbPinCropLeft;
        private System.Windows.Forms.PictureBox pbPinCropRight;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTestProcess;
        private System.Windows.Forms.Button btnSubRight;
        private System.Windows.Forms.Button btnSubLeft;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}