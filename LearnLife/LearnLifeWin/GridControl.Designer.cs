using System;
namespace LearnLifeWin
{
    partial class GridControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerCalculate = new System.Windows.Forms.Timer(this.components);
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerCalculate
            // 
            this.timerCalculate.Tick += new System.EventHandler(this.timerCalculate_Tick);
            // 
            // timerRender
            // 
            this.timerRender.Tick += new System.EventHandler(this.timerRender_Tick);
            // 
            // GridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "GridControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCalculate;
        private System.Windows.Forms.Timer timerRender;
    }
}
