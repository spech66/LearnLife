namespace LearnLifeWin
{
	partial class OptionDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionDialog));
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.numericUpDownReadFileBorder = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxShowTutorial = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadFileBorder)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			resources.ApplyResources(this.buttonOk, "buttonOk");
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// numericUpDownReadFileBorder
			// 
			resources.ApplyResources(this.numericUpDownReadFileBorder, "numericUpDownReadFileBorder");
			this.numericUpDownReadFileBorder.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownReadFileBorder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownReadFileBorder.Name = "numericUpDownReadFileBorder";
			this.numericUpDownReadFileBorder.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// checkBoxShowTutorial
			// 
			resources.ApplyResources(this.checkBoxShowTutorial, "checkBoxShowTutorial");
			this.checkBoxShowTutorial.MinimumSize = new System.Drawing.Size(220, 0);
			this.checkBoxShowTutorial.Name = "checkBoxShowTutorial";
			this.checkBoxShowTutorial.UseVisualStyleBackColor = true;
			// 
			// OptionDialog
			// 
			this.AcceptButton = this.buttonOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.Controls.Add(this.checkBoxShowTutorial);
			this.Controls.Add(this.numericUpDownReadFileBorder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionDialog";
			this.Load += new System.EventHandler(this.OptionDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownReadFileBorder)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.NumericUpDown numericUpDownReadFileBorder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxShowTutorial;
	}
}