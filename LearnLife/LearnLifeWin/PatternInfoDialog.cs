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
	public partial class PatternInfoDialog : Form
	{
		private LearnLifeCore.Grid grid;

		public PatternInfoDialog(LearnLifeCore.Grid grid)
		{
			InitializeComponent();

			this.grid = grid;
		}

		private void PatternInfo_Load(object sender, EventArgs e)
		{
			textBoxName.Text = grid.PatternName;
			textBoxAuthor.Text = grid.PatternAuthor;
			textBoxRule.Text = String.Format("{0} ({1})", grid.PatternRule, grid.Rule);
			textBoxCommentExtra.Text = (String.Format("{0}{1}{1}{2}",
				grid.PatternComment == null ? string.Empty : grid.PatternComment.Trim(),
				Environment.NewLine,
				grid.PatternExtra == null ? string.Empty : grid.PatternExtra.Trim())).Trim();
			textBoxWidth.Text = grid.Width.ToString();
			textBoxHeight.Text = grid.Height.ToString();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			grid.PatternName = textBoxName.Text.Trim();
			grid.PatternAuthor = textBoxAuthor.Text.Trim();
			grid.PatternComment = textBoxCommentExtra.Text.Trim();
			grid.PatternExtra = "";
		}
	}
}
