namespace LearnLifeWin
{
	partial class PatternInfoDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternInfoDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxAuthor = new System.Windows.Forms.TextBox();
			this.textBoxRule = new System.Windows.Forms.TextBox();
			this.textBoxCommentExtra = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxWidth = new System.Windows.Forms.TextBox();
			this.textBoxHeight = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.buttonOK, "buttonOK");
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// textBoxName
			// 
			resources.ApplyResources(this.textBoxName, "textBoxName");
			this.textBoxName.Name = "textBoxName";
			// 
			// textBoxAuthor
			// 
			resources.ApplyResources(this.textBoxAuthor, "textBoxAuthor");
			this.textBoxAuthor.Name = "textBoxAuthor";
			// 
			// textBoxRule
			// 
			resources.ApplyResources(this.textBoxRule, "textBoxRule");
			this.textBoxRule.Name = "textBoxRule";
			this.textBoxRule.ReadOnly = true;
			// 
			// textBoxCommentExtra
			// 
			resources.ApplyResources(this.textBoxCommentExtra, "textBoxCommentExtra");
			this.textBoxCommentExtra.Name = "textBoxCommentExtra";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// textBoxWidth
			// 
			resources.ApplyResources(this.textBoxWidth, "textBoxWidth");
			this.textBoxWidth.Name = "textBoxWidth";
			this.textBoxWidth.ReadOnly = true;
			// 
			// textBoxHeight
			// 
			resources.ApplyResources(this.textBoxHeight, "textBoxHeight");
			this.textBoxHeight.Name = "textBoxHeight";
			this.textBoxHeight.ReadOnly = true;
			// 
			// PatternInfoDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxHeight);
			this.Controls.Add(this.textBoxWidth);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxCommentExtra);
			this.Controls.Add(this.textBoxRule);
			this.Controls.Add(this.textBoxAuthor);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PatternInfoDialog";
			this.Load += new System.EventHandler(this.PatternInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxAuthor;
		private System.Windows.Forms.TextBox textBoxRule;
		private System.Windows.Forms.TextBox textBoxCommentExtra;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxWidth;
		private System.Windows.Forms.TextBox textBoxHeight;
	}
}