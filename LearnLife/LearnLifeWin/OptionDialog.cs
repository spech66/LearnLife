using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LearnLifeWin
{
	public partial class OptionDialog : Form
	{
		public OptionDialog()
		{
			InitializeComponent();
		}

		private void OptionDialog_Load(object sender, EventArgs e)
		{
			numericUpDownReadFileBorder.Value = LearnLifeWin.Properties.Settings.Default.ReadFileBorder;
			checkBoxShowTutorial.Checked = LearnLifeWin.Properties.Settings.Default.ShowTutorial;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			LearnLifeWin.Properties.Settings.Default.ReadFileBorder = (int)numericUpDownReadFileBorder.Value;
			LearnLifeWin.Properties.Settings.Default.ShowTutorial = checkBoxShowTutorial.Checked;
			LearnLifeWin.Properties.Settings.Default.Save();
		}
	}
}
