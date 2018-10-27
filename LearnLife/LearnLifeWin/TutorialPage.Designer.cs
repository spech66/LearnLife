namespace LearnLifeWin
{
	partial class TutorialPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialPage));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.gridControl1 = new LearnLifeWin.GridControl();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonPause = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
			this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
			// 
			// splitContainer1.Panel2
			// 
			resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			// 
			// webBrowser1
			// 
			resources.ApplyResources(this.webBrowser1, "webBrowser1");
			this.webBrowser1.AllowNavigation = false;
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			// 
			// splitContainer2
			// 
			resources.ApplyResources(this.splitContainer2, "splitContainer2");
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
			this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
			// 
			// splitContainer2.Panel2
			// 
			resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
			this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
			// 
			// gridControl1
			// 
			resources.ApplyResources(this.gridControl1, "gridControl1");
			this.gridControl1.AllowDrawing = true;
			this.gridControl1.GridSize = 0;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.ScrollLeft = 0;
			this.gridControl1.ScrollTop = 0;
			this.gridControl1.ShowGridLines = false;
			this.gridControl1.Resize += new System.EventHandler(this.gridControl1_Resize);
			// 
			// flowLayoutPanel1
			// 
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.buttonNext);
			this.flowLayoutPanel1.Controls.Add(this.buttonStart);
			this.flowLayoutPanel1.Controls.Add(this.buttonPause);
			this.flowLayoutPanel1.Controls.Add(this.buttonReset);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			// 
			// buttonNext
			// 
			resources.ApplyResources(this.buttonNext, "buttonNext");
			this.buttonNext.Image = global::LearnLifeWin.Properties.Resources.next;
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
			// 
			// buttonStart
			// 
			resources.ApplyResources(this.buttonStart, "buttonStart");
			this.buttonStart.Image = global::LearnLifeWin.Properties.Resources.player_play;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonPause
			// 
			resources.ApplyResources(this.buttonPause, "buttonPause");
			this.buttonPause.Image = global::LearnLifeWin.Properties.Resources.player_pause;
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.UseVisualStyleBackColor = true;
			this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
			// 
			// buttonReset
			// 
			resources.ApplyResources(this.buttonReset, "buttonReset");
			this.buttonReset.Image = global::LearnLifeWin.Properties.Resources.reload;
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// TutorialPage
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.splitContainer1);
			this.Name = "TutorialPage";
			this.Load += new System.EventHandler(this.TutorialPage_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private GridControl gridControl1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonPause;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.WebBrowser webBrowser1;
	}
}