namespace LearnLifeWin
{
    partial class NewDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDialog));
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBoxRandom = new System.Windows.Forms.CheckBox();
			this.numericUpDownRandom = new System.Windows.Forms.NumericUpDown();
			this.labelRandom = new System.Windows.Forms.Label();
			this.comboBoxRule = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRandom)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			resources.ApplyResources(this.buttonOk, "buttonOk");
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// numericUpDownWidth
			// 
			resources.ApplyResources(this.numericUpDownWidth, "numericUpDownWidth");
			this.numericUpDownWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownWidth.Name = "numericUpDownWidth";
			this.numericUpDownWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// numericUpDownHeight
			// 
			resources.ApplyResources(this.numericUpDownHeight, "numericUpDownHeight");
			this.numericUpDownHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownHeight.Name = "numericUpDownHeight";
			this.numericUpDownHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// checkBoxRandom
			// 
			resources.ApplyResources(this.checkBoxRandom, "checkBoxRandom");
			this.checkBoxRandom.Name = "checkBoxRandom";
			this.checkBoxRandom.UseVisualStyleBackColor = true;
			this.checkBoxRandom.CheckedChanged += new System.EventHandler(this.checkBoxRandom_CheckedChanged);
			// 
			// numericUpDownRandom
			// 
			resources.ApplyResources(this.numericUpDownRandom, "numericUpDownRandom");
			this.numericUpDownRandom.Name = "numericUpDownRandom";
			// 
			// labelRandom
			// 
			resources.ApplyResources(this.labelRandom, "labelRandom");
			this.labelRandom.Name = "labelRandom";
			// 
			// comboBoxRule
			// 
			resources.ApplyResources(this.comboBoxRule, "comboBoxRule");
			this.comboBoxRule.FormattingEnabled = true;
			this.comboBoxRule.Name = "comboBoxRule";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// NewDialog
			// 
			this.AcceptButton = this.buttonOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxRule);
			this.Controls.Add(this.labelRandom);
			this.Controls.Add(this.numericUpDownRandom);
			this.Controls.Add(this.checkBoxRandom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownHeight);
			this.Controls.Add(this.numericUpDownWidth);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewDialog";
			this.Load += new System.EventHandler(this.NewDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRandom)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBoxRandom;
		private System.Windows.Forms.NumericUpDown numericUpDownRandom;
		private System.Windows.Forms.Label labelRandom;
		private System.Windows.Forms.ComboBox comboBoxRule;
		private System.Windows.Forms.Label label3;
    }
}