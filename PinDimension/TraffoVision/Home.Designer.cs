namespace TraffoVision
{
    partial class Home
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.debugStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxModel = new System.Windows.Forms.ToolStripComboBox();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImage1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImage2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnLoadLocal2 = new System.Windows.Forms.Button();
            this.tbLimit = new System.Windows.Forms.TextBox();
            this.btnLoadLocal = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pbPinCropRight = new System.Windows.Forms.PictureBox();
            this.pbPinCropLeft = new System.Windows.Forms.PictureBox();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbFail = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
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
            this.debugStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 891);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1086, 22);
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "ádffffffdsfafadsasdf";
            // 
            // debugStrip
            // 
            this.debugStrip.Name = "debugStrip";
            this.debugStrip.Size = new System.Drawing.Size(42, 17);
            this.debugStrip.Text = "Debug";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.productToolStripMenuItem,
            this.testModeToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1086, 59);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.homeToolStripMenuItem.Image = global::MultiDisplay.Properties.Resources.logonew;
            this.homeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(62, 55);
            this.homeToolStripMenuItem.Text = "        ";
            this.homeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.pLCToolStripMenuItem});
            this.toolToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(38, 55);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCameraToolStripMenuItem,
            this.closeCameraToolStripMenuItem,
            this.triggerCameraToolStripMenuItem});
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.connectToolStripMenuItem.Text = "Camera";
            // 
            // openCameraToolStripMenuItem
            // 
            this.openCameraToolStripMenuItem.Name = "openCameraToolStripMenuItem";
            this.openCameraToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openCameraToolStripMenuItem.Text = "Open Camera";
            this.openCameraToolStripMenuItem.Click += new System.EventHandler(this.openCameraToolStripMenuItem_Click);
            // 
            // closeCameraToolStripMenuItem
            // 
            this.closeCameraToolStripMenuItem.Name = "closeCameraToolStripMenuItem";
            this.closeCameraToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeCameraToolStripMenuItem.Text = "Close Camera";
            this.closeCameraToolStripMenuItem.Click += new System.EventHandler(this.closeCameraToolStripMenuItem_Click);
            // 
            // triggerCameraToolStripMenuItem
            // 
            this.triggerCameraToolStripMenuItem.Name = "triggerCameraToolStripMenuItem";
            this.triggerCameraToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.triggerCameraToolStripMenuItem.Text = "Trigger Camera";
            this.triggerCameraToolStripMenuItem.Click += new System.EventHandler(this.triggerCameraToolStripMenuItem_Click);
            // 
            // pLCToolStripMenuItem
            // 
            this.pLCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem1});
            this.pLCToolStripMenuItem.Name = "pLCToolStripMenuItem";
            this.pLCToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.pLCToolStripMenuItem.Text = "PLC";
            // 
            // connectToolStripMenuItem1
            // 
            this.connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            this.connectToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.connectToolStripMenuItem1.Text = "Connect";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxModel,
            this.loadToolStripMenuItem});
            this.productToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(97, 55);
            this.productToolStripMenuItem.Text = "Product Number";
            // 
            // toolStripComboBoxModel
            // 
            this.toolStripComboBoxModel.Name = "toolStripComboBoxModel";
            this.toolStripComboBoxModel.Size = new System.Drawing.Size(121, 23);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // testModeToolStripMenuItem
            // 
            this.testModeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.testModeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.testModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImage1ToolStripMenuItem,
            this.loadImage2ToolStripMenuItem,
            this.processToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.testModeToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testModeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.testModeToolStripMenuItem.Name = "testModeToolStripMenuItem";
            this.testModeToolStripMenuItem.Size = new System.Drawing.Size(67, 55);
            this.testModeToolStripMenuItem.Text = "Test Mode";
            // 
            // loadImage1ToolStripMenuItem
            // 
            this.loadImage1ToolStripMenuItem.Name = "loadImage1ToolStripMenuItem";
            this.loadImage1ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadImage1ToolStripMenuItem.Text = "Load Image 1";
            this.loadImage1ToolStripMenuItem.Click += new System.EventHandler(this.loadImage1ToolStripMenuItem_Click);
            // 
            // loadImage2ToolStripMenuItem
            // 
            this.loadImage2ToolStripMenuItem.Name = "loadImage2ToolStripMenuItem";
            this.loadImage2ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadImage2ToolStripMenuItem.Text = "Load Image 2";
            this.loadImage2ToolStripMenuItem.Click += new System.EventHandler(this.loadImage2ToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.processToolStripMenuItem.Text = "Process";
            this.processToolStripMenuItem.Click += new System.EventHandler(this.processToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.drawToolStripMenuItem.Text = "Draw";
            this.drawToolStripMenuItem.Click += new System.EventHandler(this.drawToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 55);
            this.toolStripMenuItem1.Text = " ";
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(894, 479);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(183, 318);
            this.listView2.TabIndex = 20;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.ForeColor = System.Drawing.SystemColors.Menu;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(895, 65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(183, 321);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelLeft.Controls.Add(this.btnLoadLocal2);
            this.panelLeft.Controls.Add(this.tbLimit);
            this.panelLeft.Controls.Add(this.btnLoadLocal);
            this.panelLeft.Controls.Add(this.btnTrigger);
            this.panelLeft.Controls.Add(this.btnOpen);
            this.panelLeft.Controls.Add(this.btnClose);
            this.panelLeft.Controls.Add(this.btnProcess);
            this.panelLeft.Controls.Add(this.btnStart);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 59);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(63, 832);
            this.panelLeft.TabIndex = 23;
            // 
            // btnLoadLocal2
            // 
            this.btnLoadLocal2.Image = global::MultiDisplay.Properties.Resources.uploading;
            this.btnLoadLocal2.Location = new System.Drawing.Point(13, 271);
            this.btnLoadLocal2.Name = "btnLoadLocal2";
            this.btnLoadLocal2.Size = new System.Drawing.Size(40, 40);
            this.btnLoadLocal2.TabIndex = 14;
            this.btnLoadLocal2.UseVisualStyleBackColor = true;
            this.btnLoadLocal2.Click += new System.EventHandler(this.btnLoadLocal2_Click);
            // 
            // tbLimit
            // 
            this.tbLimit.Location = new System.Drawing.Point(12, 375);
            this.tbLimit.Name = "tbLimit";
            this.tbLimit.Size = new System.Drawing.Size(39, 20);
            this.tbLimit.TabIndex = 29;
            this.tbLimit.Text = "10";
            // 
            // btnLoadLocal
            // 
            this.btnLoadLocal.Image = global::MultiDisplay.Properties.Resources.uploading;
            this.btnLoadLocal.Location = new System.Drawing.Point(12, 220);
            this.btnLoadLocal.Name = "btnLoadLocal";
            this.btnLoadLocal.Size = new System.Drawing.Size(40, 40);
            this.btnLoadLocal.TabIndex = 13;
            this.btnLoadLocal.UseVisualStyleBackColor = true;
            this.btnLoadLocal.Click += new System.EventHandler(this.btnLoadLocal_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Image = global::MultiDisplay.Properties.Resources.camera__circle;
            this.btnTrigger.Location = new System.Drawing.Point(12, 118);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(40, 40);
            this.btnTrigger.TabIndex = 6;
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.Trigger_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpen.Image = global::MultiDisplay.Properties.Resources.link;
            this.btnOpen.Location = new System.Drawing.Point(12, 16);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(40, 40);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::MultiDisplay.Properties.Resources.unlink;
            this.btnClose.Location = new System.Drawing.Point(12, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::MultiDisplay.Properties.Resources.process;
            this.btnProcess.Location = new System.Drawing.Point(12, 169);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(40, 40);
            this.btnProcess.TabIndex = 12;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.process_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::MultiDisplay.Properties.Resources.play_button;
            this.btnStart.Location = new System.Drawing.Point(13, 322);
            this.btnStart.Name = "btnStart";
            this.btnStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnStart.Size = new System.Drawing.Size(40, 40);
            this.btnStart.TabIndex = 22;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnLogo
            // 
            this.btnLogo.BackColor = System.Drawing.Color.White;
            this.btnLogo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogo.Location = new System.Drawing.Point(425, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLogo.Size = new System.Drawing.Size(206, 59);
            this.btnLogo.TabIndex = 27;
            this.btnLogo.Text = "Pin Dimension";
            this.btnLogo.UseVisualStyleBackColor = false;
            // 
            // pbPinCropRight
            // 
            this.pbPinCropRight.Location = new System.Drawing.Point(894, 806);
            this.pbPinCropRight.Name = "pbPinCropRight";
            this.pbPinCropRight.Size = new System.Drawing.Size(183, 81);
            this.pbPinCropRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPinCropRight.TabIndex = 28;
            this.pbPinCropRight.TabStop = false;
            // 
            // pbPinCropLeft
            // 
            this.pbPinCropLeft.Location = new System.Drawing.Point(894, 392);
            this.pbPinCropLeft.Name = "pbPinCropLeft";
            this.pbPinCropLeft.Size = new System.Drawing.Size(183, 81);
            this.pbPinCropLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPinCropLeft.TabIndex = 27;
            this.pbPinCropLeft.TabStop = false;
            // 
            // pbRight
            // 
            this.pbRight.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbRight.InitialImage = global::MultiDisplay.Properties.Resources.in2;
            this.pbRight.Location = new System.Drawing.Point(71, 479);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(816, 408);
            this.pbRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRight.TabIndex = 3;
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            this.pbLeft.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbLeft.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbLeft.Location = new System.Drawing.Point(71, 65);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(816, 408);
            this.pbLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeft.TabIndex = 0;
            this.pbLeft.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::MultiDisplay.Properties.Resources.cross_small;
            this.btnExit.Location = new System.Drawing.Point(1048, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 59);
            this.btnExit.TabIndex = 30;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMini.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Image = global::MultiDisplay.Properties.Resources.window_minimize;
            this.btnMini.Location = new System.Drawing.Point(1011, 0);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(31, 59);
            this.btnMini.TabIndex = 31;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(781, 0);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(49, 59);
            this.button1.TabIndex = 32;
            this.button1.Text = "Pass";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(836, 0);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(49, 59);
            this.button2.TabIndex = 33;
            this.button2.Text = "Fail";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.Font = new System.Drawing.Font("Bahnschrift Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFail.Location = new System.Drawing.Point(843, 31);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(12, 13);
            this.lbFail.TabIndex = 35;
            this.lbFail.Text = "0";
            this.lbFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Bahnschrift Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPass.Location = new System.Drawing.Point(787, 31);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(12, 13);
            this.lbPass.TabIndex = 36;
            this.lbPass.Text = "0";
            this.lbPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1086, 913);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbFail);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogo);
            this.Controls.Add(this.pbPinCropRight);
            this.Controls.Add(this.pbPinCropLeft);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPinCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel debugStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxModel;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCameraToolStripMenuItem;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem triggerCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnLoadLocal2;
        private System.Windows.Forms.Button btnLoadLocal;
        private System.Windows.Forms.PictureBox pbPinCropLeft;
        private System.Windows.Forms.PictureBox pbPinCropRight;
        private System.Windows.Forms.TextBox tbLimit;
        private System.Windows.Forms.ToolStripMenuItem testModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.ToolStripMenuItem loadImage1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImage2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbFail;
        private System.Windows.Forms.Label lbPass;
    }
}

