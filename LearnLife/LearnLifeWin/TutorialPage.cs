using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LearnLifeWin
{
	public partial class TutorialPage : Form
	{
		private TutorialItem tutorial;

		public TutorialPage(TutorialItem ti)
		{
			tutorial = ti;

			InitializeComponent();

			gridControl1.GenerationChanged += new EventHandler(gridControl1_GenerationChanged);
			gridControl1.AllowDrawing = false;
		}

		private void TutorialPage_Load(object sender, EventArgs e)
		{
			LoadPattern();
			LoadHtml();
		}

		private void gridControl1_Resize(object sender, EventArgs e)
		{
			gridControl1.FitBestGridSize();
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			gridControl1.SimulationNext();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			gridControl1.SimulationStart();
		}

		private void buttonPause_Click(object sender, EventArgs e)
		{
			gridControl1.SimulationPause();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			LoadPattern();
		}

		void gridControl1_GenerationChanged(object sender, EventArgs e)
		{
			if (tutorial.GenerationMax > 0 && gridControl1.LifeGrid.Generation >= tutorial.GenerationMax)
			{
				buttonNext.Enabled = false;
				buttonPause.Enabled = false;
				buttonStart.Enabled = false;
				gridControl1.SimulationPause();
			}

			this.Text = String.Format("Tutorial - {0} - Generation: {1}", tutorial.Name, gridControl1.LifeGrid.Generation);
		}

		private void LoadPattern()
		{
			string patternFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pattern");
			if (!Directory.Exists(patternFolder))
				return;

			LearnLifeCore.FileReader.FileReader fileReader = new LearnLifeCore.FileReader.FileReader();
			if (tutorial.Border > 0)
			{
				fileReader.Border = tutorial.Border;
			}
			LearnLifeCore.Grid lifeGrid = fileReader.ReadFile(Path.Combine(patternFolder, "tutorial", tutorial.Pattern));
			if (lifeGrid != null)
			{
				gridControl1.SetLifeGrid(lifeGrid);
				gridControl1.FitBestGridSize();

				buttonNext.Enabled = true;
				buttonPause.Enabled = true;
				buttonStart.Enabled = true;
			}
		}

		private void LoadHtml()
		{
			string tutorialFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Tutorial");
			if (!Directory.Exists(tutorialFolder))
				return;

			string localizedFilename = String.Format("{0}_{1}", System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName,  tutorial.File);
			string filename = Path.Combine(tutorialFolder, localizedFilename);
			if (!File.Exists(filename))
			{
				filename = Path.Combine(tutorialFolder, tutorial.File);
				if (!File.Exists(filename))
					return;
			}

			webBrowser1.Url = new Uri(filename, UriKind.Absolute);
		}
	}
}
