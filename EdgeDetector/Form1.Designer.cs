namespace EdgeDetector
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
          this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.sobellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.zoomToFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.originalSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStrip1 = new System.Windows.Forms.ToolStrip();
          this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
          this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
          this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
          this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
          this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
          this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.panel1 = new EdgeDetector.DoubleBufferPanel();
          this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.menuStrip1.SuspendLayout();
          this.toolStrip1.SuspendLayout();
          this.statusStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.zoomToolStripMenuItem});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(533, 24);
          this.menuStrip1.TabIndex = 0;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
          this.fileToolStripMenuItem.Text = "&File";
          // 
          // newToolStripMenuItem
          // 
          this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
          this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.newToolStripMenuItem.Name = "newToolStripMenuItem";
          this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
          this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
          this.newToolStripMenuItem.Text = "&New";
          this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
          // 
          // openToolStripMenuItem
          // 
          this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
          this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.openToolStripMenuItem.Name = "openToolStripMenuItem";
          this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
          this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
          this.openToolStripMenuItem.Text = "&Open";
          this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
          // 
          // toolStripSeparator
          // 
          this.toolStripSeparator.Name = "toolStripSeparator";
          this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
          // 
          // saveToolStripMenuItem
          // 
          this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
          this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
          this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
          this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
          this.saveToolStripMenuItem.Text = "&Save As";
          this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
          // 
          // exitToolStripMenuItem
          // 
          this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
          this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
          this.exitToolStripMenuItem.Text = "E&xit";
          this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
          // 
          // editToolStripMenuItem
          // 
          this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
          this.editToolStripMenuItem.Name = "editToolStripMenuItem";
          this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
          this.editToolStripMenuItem.Text = "&Edit";
          // 
          // undoToolStripMenuItem
          // 
          this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
          this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
          this.undoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
          this.undoToolStripMenuItem.Text = "&Undo";
          this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
          // 
          // edgeDetectionToolStripMenuItem
          // 
          this.edgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobellToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.cannyToolStripMenuItem});
          this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
          this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
          this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
          // 
          // sobellToolStripMenuItem
          // 
          this.sobellToolStripMenuItem.Name = "sobellToolStripMenuItem";
          this.sobellToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
          this.sobellToolStripMenuItem.Text = "Sobell";
          this.sobellToolStripMenuItem.Click += new System.EventHandler(this.sobellToolStripMenuItem_Click);
          // 
          // prewittToolStripMenuItem
          // 
          this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
          this.prewittToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
          this.prewittToolStripMenuItem.Text = "Prewitt";
          this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
          // 
          // cannyToolStripMenuItem
          // 
          this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
          this.cannyToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
          this.cannyToolStripMenuItem.Text = "Canny";
          this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
          // 
          // filtersToolStripMenuItem
          // 
          this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.invertToolStripMenuItem});
          this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
          this.filtersToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
          this.filtersToolStripMenuItem.Text = "Filters";
          // 
          // grayscaleToolStripMenuItem
          // 
          this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
          this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.grayscaleToolStripMenuItem.Text = "Grayscale";
          this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
          // 
          // blurToolStripMenuItem
          // 
          this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
          this.blurToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.blurToolStripMenuItem.Text = "Blur";
          this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
          // 
          // sharpenToolStripMenuItem
          // 
          this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
          this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.sharpenToolStripMenuItem.Text = "Sharpen";
          this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
          // 
          // zoomToolStripMenuItem
          // 
          this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToFitToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.originalSizeToolStripMenuItem});
          this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
          this.zoomToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
          this.zoomToolStripMenuItem.Text = "Zoom";
          // 
          // zoomToFitToolStripMenuItem
          // 
          this.zoomToFitToolStripMenuItem.Name = "zoomToFitToolStripMenuItem";
          this.zoomToFitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
          this.zoomToFitToolStripMenuItem.Text = "Zoom to Fit";
          this.zoomToFitToolStripMenuItem.Click += new System.EventHandler(this.zoomToFitToolStripMenuItem_Click);
          // 
          // zoomInToolStripMenuItem
          // 
          this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
          this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
          this.zoomInToolStripMenuItem.Text = "Zoom In";
          this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
          // 
          // zoomOutToolStripMenuItem
          // 
          this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
          this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
          this.zoomOutToolStripMenuItem.Text = "Zoom Out";
          this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
          // 
          // originalSizeToolStripMenuItem
          // 
          this.originalSizeToolStripMenuItem.Name = "originalSizeToolStripMenuItem";
          this.originalSizeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
          this.originalSizeToolStripMenuItem.Text = "Original Size";
          this.originalSizeToolStripMenuItem.Click += new System.EventHandler(this.originalSizeToolStripMenuItem_Click);
          // 
          // toolStrip1
          // 
          this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripLabel2,
            this.toolStripTextBox2,
            this.toolStripLabel3,
            this.toolStripTextBox3});
          this.toolStrip1.Location = new System.Drawing.Point(0, 24);
          this.toolStrip1.Name = "toolStrip1";
          this.toolStrip1.Size = new System.Drawing.Size(533, 25);
          this.toolStrip1.TabIndex = 2;
          this.toolStrip1.Text = "toolStrip1";
          // 
          // newToolStripButton
          // 
          this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
          this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.newToolStripButton.Name = "newToolStripButton";
          this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
          this.newToolStripButton.Text = "&New";
          this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
          // 
          // openToolStripButton
          // 
          this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
          this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.openToolStripButton.Name = "openToolStripButton";
          this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
          this.openToolStripButton.Text = "&Open";
          this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
          // 
          // saveToolStripButton
          // 
          this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
          this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.saveToolStripButton.Name = "saveToolStripButton";
          this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
          this.saveToolStripButton.Text = "&Save";
          this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
          // 
          // toolStripSeparator5
          // 
          this.toolStripSeparator5.Name = "toolStripSeparator5";
          this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
          // 
          // toolStripLabel1
          // 
          this.toolStripLabel1.Name = "toolStripLabel1";
          this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
          this.toolStripLabel1.Text = "Threshold:";
          // 
          // toolStripTextBox1
          // 
          this.toolStripTextBox1.Name = "toolStripTextBox1";
          this.toolStripTextBox1.Size = new System.Drawing.Size(40, 25);
          this.toolStripTextBox1.Text = "100";
          this.toolStripTextBox1.ToolTipText = "Filter threshold";
          // 
          // toolStripLabel2
          // 
          this.toolStripLabel2.Name = "toolStripLabel2";
          this.toolStripLabel2.Size = new System.Drawing.Size(80, 22);
          this.toolStripLabel2.Text = "Low Threshold:";
          // 
          // toolStripTextBox2
          // 
          this.toolStripTextBox2.Name = "toolStripTextBox2";
          this.toolStripTextBox2.Size = new System.Drawing.Size(40, 25);
          this.toolStripTextBox2.Text = "20";
          // 
          // toolStripLabel3
          // 
          this.toolStripLabel3.Name = "toolStripLabel3";
          this.toolStripLabel3.Size = new System.Drawing.Size(39, 22);
          this.toolStripLabel3.Text = "Sigma:";
          // 
          // toolStripTextBox3
          // 
          this.toolStripTextBox3.Name = "toolStripTextBox3";
          this.toolStripTextBox3.Size = new System.Drawing.Size(40, 25);
          this.toolStripTextBox3.Text = "1.4";
          // 
          // statusStrip1
          // 
          this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
          this.statusStrip1.Location = new System.Drawing.Point(0, 334);
          this.statusStrip1.Name = "statusStrip1";
          this.statusStrip1.Size = new System.Drawing.Size(533, 22);
          this.statusStrip1.TabIndex = 3;
          this.statusStrip1.Text = "statusStrip1";
          // 
          // toolStripStatusLabel1
          // 
          this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
          this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
          // 
          // panel1
          // 
          this.panel1.AllowPaint = true;
          this.panel1.AutoScroll = true;
          this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Location = new System.Drawing.Point(0, 49);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(533, 285);
          this.panel1.TabIndex = 1;
          this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
          this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
          this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
          // 
          // invertToolStripMenuItem
          // 
          this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
          this.invertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.invertToolStripMenuItem.Text = "Invert";
          this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(533, 356);
          this.Controls.Add(this.panel1);
          this.Controls.Add(this.statusStrip1);
          this.Controls.Add(this.toolStrip1);
          this.Controls.Add(this.menuStrip1);
          this.DoubleBuffered = true;
          this.MainMenuStrip = this.menuStrip1;
          this.Name = "Form1";
          this.Text = "Edge Detector";
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.toolStrip1.ResumeLayout(false);
          this.toolStrip1.PerformLayout();
          this.statusStrip1.ResumeLayout(false);
          this.statusStrip1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private DoubleBufferPanel panel1;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originalSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
				private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
				private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
				private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
				private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
				private System.Windows.Forms.ToolStripLabel toolStripLabel1;
				private System.Windows.Forms.ToolStripLabel toolStripLabel2;
				private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
				private System.Windows.Forms.ToolStripLabel toolStripLabel3;
				private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
				private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
				private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
    }
}

