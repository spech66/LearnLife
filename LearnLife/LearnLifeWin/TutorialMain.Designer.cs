namespace LearnLifeWin
{
	partial class TutorialMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialMain));
			this.checkBoxTutorial = new System.Windows.Forms.CheckBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.buttonLangUs = new System.Windows.Forms.Button();
			this.buttonLangDe = new System.Windows.Forms.Button();
			this.buttonRun = new System.Windows.Forms.Button();
			this.buttonMain = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxTutorial
			// 
			resources.ApplyResources(this.checkBoxTutorial, "checkBoxTutorial");
			this.checkBoxTutorial.Name = "checkBoxTutorial";
			this.checkBoxTutorial.UseVisualStyleBackColor = true;
			this.checkBoxTutorial.CheckedChanged += new System.EventHandler(this.checkBoxTutorial_CheckedChanged);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			resources.ApplyResources(this.listBox1, "listBox1");
			this.listBox1.Name = "listBox1";
			// 
			// buttonLangUs
			// 
			this.buttonLangUs.Image = global::LearnLifeWin.Properties.Resources.us;
			resources.ApplyResources(this.buttonLangUs, "buttonLangUs");
			this.buttonLangUs.Name = "buttonLangUs";
			this.buttonLangUs.UseVisualStyleBackColor = true;
			this.buttonLangUs.Click += new System.EventHandler(this.buttonLangUs_Click);
			// 
			// buttonLangDe
			// 
			this.buttonLangDe.Image = global::LearnLifeWin.Properties.Resources.de;
			resources.ApplyResources(this.buttonLangDe, "buttonLangDe");
			this.buttonLangDe.Name = "buttonLangDe";
			this.buttonLangDe.Tag = "de-DE";
			this.buttonLangDe.UseVisualStyleBackColor = true;
			this.buttonLangDe.Click += new System.EventHandler(this.buttonLangDe_Click);
			// 
			// buttonRun
			// 
			this.buttonRun.Image = global::LearnLifeWin.Properties.Resources.tutorials;
			resources.ApplyResources(this.buttonRun, "buttonRun");
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonMain
			// 
			resources.ApplyResources(this.buttonMain, "buttonMain");
			this.buttonMain.Image = global::LearnLifeWin.Properties.Resources._1rightarrow;
			this.buttonMain.Name = "buttonMain";
			this.buttonMain.UseVisualStyleBackColor = true;
			this.buttonMain.Click += new System.EventHandler(this.buttonMain_Click);
			// 
			// TutorialMain
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonLangUs);
			this.Controls.Add(this.buttonLangDe);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.buttonRun);
			this.Controls.Add(this.checkBoxTutorial);
			this.Controls.Add(this.buttonMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "TutorialMain";
			this.Load += new System.EventHandler(this.TutorialMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonMain;
		private System.Windows.Forms.CheckBox checkBoxTutorial;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button buttonLangDe;
		private System.Windows.Forms.Button buttonLangUs;
	}
}