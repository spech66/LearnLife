using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using System.Globalization;

namespace LearnLifeWin
{
	public partial class TutorialMain : Form
	{
		public TutorialMain()
		{
			InitializeComponent();
		}

		private void TutorialMain_Load(object sender, EventArgs e)
		{
			checkBoxTutorial.Checked = LearnLifeWin.Properties.Settings.Default.ShowTutorial;

			string tutorialXmlFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Tutorial", "tutorial.xml");
			using (XmlReader reader = XmlReader.Create(tutorialXmlFile))
			{
				while (reader.Read())
				{
					if (reader.IsStartElement())
					{
						if (reader.Name == "tutorial")
						{
							TutorialItem ti = new TutorialItem(reader["name"], reader["pattern"], reader["file"]);
							while (reader.MoveToNextAttribute())
							{
								if (reader.Name == "generationmax") ti.GenerationMax = reader.ReadContentAsInt();
								if (reader.Name == "border") ti.Border = reader.ReadContentAsInt();
							}
							listBox1.Items.Add(ti);							
						}
					}
				}

				listBox1.DisplayMember = "name";
				listBox1.ValueMember = "name";
				listBox1.SelectedIndex = 0;
			}

		}

		private void checkBoxTutorial_CheckedChanged(object sender, EventArgs e)
		{
			LearnLifeWin.Properties.Settings.Default.ShowTutorial = checkBoxTutorial.Checked;
			LearnLifeWin.Properties.Settings.Default.Save();
		}

		private void buttonMain_Click(object sender, EventArgs e)
		{
			(new MainForm()).Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TutorialPage dlg = new TutorialPage(listBox1.SelectedItem as TutorialItem);
			dlg.ShowDialog();
		}

		private void buttonLangDe_Click(object sender, EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
			LearnLifeWin.Properties.Settings.Default.Language = "de-DE";
			LearnLifeWin.Properties.Settings.Default.Save();
			
			UpdateResource();
		}

		private void buttonLangUs_Click(object sender, EventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
			LearnLifeWin.Properties.Settings.Default.Language = string.Empty;
			LearnLifeWin.Properties.Settings.Default.Save();

			UpdateResource();
		}

		private void UpdateResource()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialMain));
			
			foreach (Control ctrl in this.Controls)
			{
				resources.ApplyResources(ctrl, ctrl.Name);
			}
			resources.ApplyResources(this, "$this");
		}
	}

	public class TutorialItem
	{
		public string Name { get; set; }
		public string Pattern { get; set; }
		public string File { get; set; }

		public int GenerationMax { get; set; }
		public int Border { get; set; }

		public TutorialItem(string name, string pattern, string file)
		{
			this.Name = name;
			this.Pattern = pattern;
			this.File = file;
		}
	}
}
