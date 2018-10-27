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
    public partial class NewDialog : Form
    {
		public bool GenerateRandom { get { return checkBoxRandom.Checked; } }
		public int RandomPercent { get { return (int)numericUpDownRandom.Value; } }
		public int GridWidth { get { return (int)numericUpDownWidth.Value; } }
		public int GridHeight { get { return (int)numericUpDownHeight.Value; } }
		public string Rule
		{
			get
			{
				if (comboBoxRule.SelectedItem != null && comboBoxRule.SelectedItem is LearnLifeCore.Rule)
					return ((LearnLifeCore.Rule)comboBoxRule.SelectedItem).RuleString;

				return (string)comboBoxRule.Text;
			}
		}

        public NewDialog()
        {
            InitializeComponent();

			SetRuleItems();
        }

		private void checkBoxRandom_CheckedChanged(object sender, EventArgs e)
		{
			labelRandom.Enabled = checkBoxRandom.Checked;
			numericUpDownRandom.Enabled = checkBoxRandom.Checked;
		}

		private void SetRuleItems()
		{
			comboBoxRule.DisplayMember = "Name";
			comboBoxRule.ValueMember = "RuleString";
			LearnLifeCore.Rules.List.ToList().ForEach(act => comboBoxRule.Items.Add(act));
			comboBoxRule.SelectedIndex = 0;
		}

		private void NewDialog_Load(object sender, EventArgs e)
		{
			numericUpDownWidth.Value = LearnLifeWin.Properties.Settings.Default.NewSizeWidth;
			numericUpDownHeight.Value = LearnLifeWin.Properties.Settings.Default.NewSizeHeight;
			if (!string.IsNullOrEmpty(LearnLifeWin.Properties.Settings.Default.NewRule))
			{
				comboBoxRule.SelectedItem = null;
				comboBoxRule.Text = LearnLifeWin.Properties.Settings.Default.NewRule;
			}
			checkBoxRandom.Checked = LearnLifeWin.Properties.Settings.Default.NewRandom;
			numericUpDownRandom.Value = LearnLifeWin.Properties.Settings.Default.NewRandomPercent;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			LearnLifeWin.Properties.Settings.Default.NewSizeWidth = (int)numericUpDownWidth.Value;
			LearnLifeWin.Properties.Settings.Default.NewSizeHeight = (int)numericUpDownHeight.Value;
			LearnLifeWin.Properties.Settings.Default.NewRule = Rule;
			LearnLifeWin.Properties.Settings.Default.NewRandom = checkBoxRandom.Checked;
			LearnLifeWin.Properties.Settings.Default.NewRandomPercent = (int)numericUpDownRandom.Value;
			LearnLifeWin.Properties.Settings.Default.Save();
		}
    }
}
