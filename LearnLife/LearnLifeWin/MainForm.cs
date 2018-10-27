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
    public partial class MainForm : Form
    {
		private string baseTitle;
		private bool isModified = false;
		private string openFile;
		private LearnLifeCore.FileWriter.IFileWriter openFileWriter;

		private string OpenFile
		{
			get
			{
				return openFile;
			}
			set
			{
				openFile = value;
				UpdateTitle();
			}
		}

        public MainForm()
        {
			InitializeComponent();
			gridControlMain.GenerationChanged += new EventHandler(gridControlMain_GenerationChanged);

			baseTitle = Text;

            InitNewWorld(new LearnLifeCore.Grid(200, 200));
			InitTree();
        }

		#region TreeView init and handling
		private void InitTree()
		{
			string patternFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pattern");
			if (!Directory.Exists(patternFolder))
				return;

			TreeNode rootNode = treeView1.Nodes.Add("", "Pattern", 0);
			InitTreeSub(rootNode, patternFolder);
			rootNode.Expand();
		}

		private void InitTreeSub(TreeNode parent, string directory)
		{
			foreach (string dir in Directory.EnumerateDirectories(directory, "*", SearchOption.TopDirectoryOnly))
			{
				TreeNode dirNode = parent.Nodes.Add(dir, Path.GetFileName(dir), 0);
				dirNode.Tag = "DIR";
				InitTreeSub(dirNode, dir);
			}

			foreach (string file in Directory.EnumerateFiles(directory, "*.*", SearchOption.TopDirectoryOnly))
			{
				if (file.EndsWith(".zip"))
				{
					TreeNode zipNode = parent.Nodes.Add(file, Path.GetFileName(file), 3);
					zipNode.Tag = "ZIPROOT";

					// http://wiki.sharpdevelop.net/SharpZipLib-Zip-Samples.ashx
					ICSharpCode.SharpZipLib.Zip.ZipFile zf = null;
					try
					{
						FileStream fs = File.OpenRead(file);
						zf = new ICSharpCode.SharpZipLib.Zip.ZipFile(fs);
						zf = InitTreeZip(zipNode, file, zf);
					}
					finally
					{
						if (zf != null)
						{
							zf.IsStreamOwner = true; // Makes close also shut the underlying stream
							zf.Close(); // Ensure we release resources
						}
					}
					continue;
				}

				TreeNode fileNode = parent.Nodes.Add(file, Path.GetFileName(file), 1);
				fileNode.Tag = "FILE";
			}
		}

		private static ICSharpCode.SharpZipLib.Zip.ZipFile InitTreeZip(TreeNode parent, string file, ICSharpCode.SharpZipLib.Zip.ZipFile zf)
		{
			foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry zipEntry in zf)
			{
				if (zipEntry.IsFile)
				{
					string fileName = Path.GetFileName(zipEntry.Name);
					string filePath = Path.GetDirectoryName(zipEntry.Name);

					// Directories are virtual - no real file structure in zip -> create self
					TreeNode[] parents;
					TreeNode fileParent;
					if ((parents = parent.Nodes.Find(filePath, false)) == null || parents.Count() < 1)
					{
						fileParent = parent.Nodes.Add(filePath, filePath, 3);
						fileParent.Tag = "ZIPDIR";
					}
					else
					{
						fileParent = parents[0];
					}

					TreeNode node = fileParent.Nodes.Add(zipEntry.Name, fileName, 1);
					node.Tag = "ZIP";
				}
			}
			return zf;
		}
		
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag == null)
				return;

			if (e.Node.Tag.ToString() == "FILE" || e.Node.Tag.ToString() == "ZIP")
			{
				LearnLifeCore.FileReader.FileReader fileReader = new LearnLifeCore.FileReader.FileReader();
				fileReader.Border = LearnLifeWin.Properties.Settings.Default.ReadFileBorder;
				string filename = e.Node.Name;

				if (e.Node.Tag.ToString() == "ZIP" && e.Node.Parent.Parent.Tag.ToString() == "ZIPROOT")
				{
					OpenFile = string.Empty;

					filename = Path.Combine(Path.GetTempPath(), e.Node.Text);

					ICSharpCode.SharpZipLib.Zip.ZipFile zf = null;
					try
					{
						FileStream fs = File.OpenRead(e.Node.Parent.Parent.Name);
						zf = new ICSharpCode.SharpZipLib.Zip.ZipFile(fs);

						byte[] buffer = new byte[4096];
						Stream zipStream = zf.GetInputStream(zf.GetEntry(e.Node.Name));
						using (FileStream streamWriter = File.Create(filename))
						{
							ICSharpCode.SharpZipLib.Core.StreamUtils.Copy(zipStream, streamWriter, buffer);
						}
					}
					finally
					{
						if (zf != null)
						{
							zf.IsStreamOwner = true; // Makes close also shut the underlying stream
							zf.Close(); // Ensure we release resources
						}
					}
				}
				else
				{
					isModified = false;
					OpenFile = filename;					
				}

				ReadLifeFile(fileReader, filename);

				if (e.Node.Tag.ToString() == "ZIP" && e.Node.Parent.Parent.Tag.ToString() == "ZIPROOT")
				{
					File.Delete(filename);
				}
			}
		}
		#endregion

		#region Event Handler
		void gridControlMain_GenerationChanged(object sender, EventArgs e)
		{
			toolStripStatusLabelGeneration.Text = "Generation: " + gridControlMain.LifeGrid.Generation;
		}

		private void trackBarSize_ValueChanged(object sender, EventArgs e)
		{
			gridControlMain.GridSize = trackBarSize.Value;
			UpdateScrollBars();
		}

        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            gridControlMain.SimulationNext();
			isModified = true;
			UpdateTitle();
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
			gridControlMain.SimulationStart();
			if (!isModified)
			{
				isModified = true;
				UpdateTitle();
			}
        }

        private void toolStripButtonPause_Click(object sender, EventArgs e)
        {
            gridControlMain.SimulationPause();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			LearnLifeCore.FileReader.FileReader fileReader = new LearnLifeCore.FileReader.FileReader();
			fileReader.Border = LearnLifeWin.Properties.Settings.Default.ReadFileBorder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pattern");
            openFileDialog1.Filter = fileReader.GetFileDialogFilter();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
				ReadLifeFile(fileReader, openFileDialog1.FileName);
				isModified = false;
				OpenFile = openFileDialog1.FileName;
            }
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewDialog dlg = new NewDialog();
			if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			LearnLifeCore.Grid lifeGrid = new LearnLifeCore.Grid(dlg.GridWidth, dlg.GridHeight);
			lifeGrid.ParsePatternRule(dlg.Rule);
			if (dlg.GenerateRandom)
			{
				lifeGrid.RandomWorld(dlg.RandomPercent);
			}
			
			isModified = false;
			OpenFile = string.Empty;

			InitNewWorld(lifeGrid);

			//PatternInfoDialog pidlg = new PatternInfoDialog(gridControlMain.LifeGrid);
			//pidlg.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			PatternInfoDialog dlg = new PatternInfoDialog(gridControlMain.LifeGrid);
			dlg.ShowDialog();
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e)
		{
			UpdateScrollBars();
		}

		private void vScrollBarTop_Scroll(object sender, ScrollEventArgs e)
		{
			gridControlMain.ScrollTop = e.NewValue;
			gridControlMain.Invalidate();
		}

		private void hScrollBarLeft_Scroll(object sender, ScrollEventArgs e)
		{
			gridControlMain.ScrollLeft = e.NewValue;
			gridControlMain.Invalidate();
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gridControlMain.SimulationPause();
			vScrollBarTop.Value = 0;
			hScrollBarLeft.Value = 0;
            trackBarSize.Value = 4;
		}

		private void fullToolStripMenuItem_Click(object sender, EventArgs e)
		{
			vScrollBarTop.Value = 0;
			hScrollBarLeft.Value = 0;
			trackBarSize.Value = trackBarSize.Minimum;
		}

		private void bestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			vScrollBarTop.Value = 0;
			hScrollBarLeft.Value = 0;
			gridControlMain.FitBestGridSize();
			//trackBarSize.Value = gridControlMain.GridSize; // Don't set as this might be bigger than Maximum.
		}

		private void maxZoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			trackBarSize.Value = trackBarSize.Maximum;
		}

		private void zoomOutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (trackBarSize.Value > trackBarSize.Minimum)
				trackBarSize.Value--;
		}

		private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (trackBarSize.Value < trackBarSize.Maximum)
				trackBarSize.Value++;
		}

		private void gridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
			toolStripButtonGrid.Checked = gridToolStripMenuItem.Checked;
			gridControlMain.ShowGridLines = gridToolStripMenuItem.Checked;
			gridControlMain.Invalidate();
		}

		private void UrlMenuItem(object sender, EventArgs e)
		{
			if (!(sender is ToolStripDropDownItem))
				return;

			ToolStripDropDownItem item = sender as ToolStripDropDownItem;
			if (item.Tag == null || string.IsNullOrEmpty(item.Tag.ToString()))
				return;

			System.Diagnostics.Process.Start(item.Tag.ToString());
		}

		private void plaintextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFile("Plaintext (*.cells)|*.cells", "cells", new LearnLifeCore.FileWriter.Plaintext());			
		}

		private void life106ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFile("Life 1.06 (*.lif, *.life)|*.lif;*.life", "lif", new LearnLifeCore.FileWriter.Life106());
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(OpenFile) || openFileWriter == null)
			{
				plaintextToolStripMenuItem_Click(this, e);
				return;
			}

			openFileWriter.WriteFile(OpenFile, gridControlMain.LifeGrid);
			
			isModified = false;
			UpdateTitle();

			MessageBox.Show("Saved file:" + Environment.NewLine + OpenFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionDialog dlg = new OptionDialog();
			dlg.ShowDialog();
		}

		private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(new TutorialMain()).Show();
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox dlg = new AboutBox();
			dlg.ShowDialog();
		}

		private void toolStripButtonSaveImage_Click(object sender, EventArgs e)
		{
			int picWidth = gridControlMain.GridSize * gridControlMain.LifeGrid.Width;
			int picHeight = gridControlMain.GridSize * gridControlMain.LifeGrid.Height;
			if (picWidth > 1200 || picHeight > 1200)
			{
				string text = string.Format("Grid size is {0}.{1}Resulting image size will be {2}x{3}.{1}Continue?", gridControlMain.GridSize, Environment.NewLine, picWidth, picHeight);
				if (MessageBox.Show(text, "Save large image?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
					return;
			}

			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			string picFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			if (!String.IsNullOrEmpty(picFolder)) saveFileDialog1.InitialDirectory = picFolder;
			
			System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
			string sep = string.Empty;
			saveFileDialog1.Filter = string.Empty;
			foreach (var c in codecs.Reverse())
			{
				string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
				saveFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", saveFileDialog1.Filter, sep, codecName, c.FilenameExtension);
				sep = "|";
			}
			saveFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", saveFileDialog1.Filter, sep, "All Files", "*.*");
			
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Image img = gridControlMain.RenderToImage();
				if (img != null)
				{
					img.Save(saveFileDialog1.FileName);
				}
			}
		}

		private void gridControlMain_MouseClick(object sender, MouseEventArgs e)
		{
			isModified = true;
			UpdateTitle();
		}
		#endregion

		#region Helper
		private void UpdateTitle()
		{
			if (string.IsNullOrEmpty(openFile))
			{
				Text = baseTitle;
				return;
			}

			if (isModified)
			{
				Text = string.Format("{0} - {1}*", baseTitle, Path.GetFileNameWithoutExtension(openFile));
			}
			else
			{
				Text = string.Format("{0} - {1}", baseTitle, Path.GetFileNameWithoutExtension(openFile));
			}
		}

		private void InitNewWorld(LearnLifeCore.Grid lifeGrid)
		{
			gridControlMain.SimulationPause();
			gridControlMain.SetLifeGrid(lifeGrid);
			gridControlMain.GridSize = trackBarSize.Value;
			UpdateScrollBars();

			toolStripStatusLabelRule.Text = "Rule: " + lifeGrid.Rule;
		}
		
		/// <summary>
		/// Read a file and create grid
		/// </summary>
		/// <param name="fileReader"></param>
		/// <param name="filename"></param>
		private void ReadLifeFile(LearnLifeCore.FileReader.FileReader fileReader, string filename)
		{
			try
			{
				LearnLifeCore.Grid lifeGrid = fileReader.ReadFile(filename);
				if (lifeGrid != null)
				{
					InitNewWorld(lifeGrid);
				}
				else
				{
					throw new NotSupportedException("Fileformat is missformed.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not read file from disk.\nOriginal error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void UpdateScrollBars()
		{
			if (gridControlMain.GridSize * gridControlMain.LifeGrid.Width < gridControlMain.Width)
			{
				hScrollBarLeft.Maximum = 0;
			}
			else
			{
				hScrollBarLeft.Maximum = gridControlMain.LifeGrid.Width - (gridControlMain.Width / gridControlMain.GridSize) + hScrollBarLeft.LargeChange; // Must add large change as of note http://msdn.microsoft.com/en-us/library/system.windows.forms.scrollbar.maximum%28v=vs.71%29.aspx
			}
			hScrollBarLeft.Value = 0;

			if (gridControlMain.GridSize * gridControlMain.LifeGrid.Height < gridControlMain.Height)
			{
				vScrollBarTop.Maximum = 0;
			}
			else
			{
				vScrollBarTop.Maximum = gridControlMain.LifeGrid.Height - (gridControlMain.Height / gridControlMain.GridSize) + vScrollBarTop.LargeChange; // Must add large change as of note http://msdn.microsoft.com/en-us/library/system.windows.forms.scrollbar.maximum%28v=vs.71%29.aspx
			}
			vScrollBarTop.Value = 0;

			gridControlMain.Invalidate(); 
		}

		private void SaveFile(string filter, string defaultExt, LearnLifeCore.FileWriter.IFileWriter fwriter)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pattern");
			saveFileDialog1.Filter = filter;
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.DefaultExt = defaultExt;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				openFileWriter = fwriter;
				if (openFileWriter.WriteFile(saveFileDialog1.FileName, gridControlMain.LifeGrid))
				{
					isModified = false;
					OpenFile = saveFileDialog1.FileName;
				}

				MessageBox.Show("Saved file:" + Environment.NewLine + OpenFile, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		#endregion
	}
}
