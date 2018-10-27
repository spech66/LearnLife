using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LearnLifeWin
{
    public partial class GridControl : UserControl
    {
        private Bitmap backBuffer;
        private LearnLifeCore.Grid lifeGrid;

		public int GridSize { get; set; }
		public LearnLifeCore.Grid LifeGrid { get { return lifeGrid; } }
		public int ScrollLeft { get; set; }
		public int ScrollTop { get; set; }
		public bool ShowGridLines { get; set; }
		public bool AllowDrawing { get; set; }

		public event EventHandler GenerationChanged;

        public GridControl()
        {
            InitializeComponent();

			AllowDrawing = true;
        }

        public void SetLifeGrid(LearnLifeCore.Grid lg)
        {
            this.lifeGrid = lg;
			SimulationPause();
			ScrollLeft = ScrollTop = 0;

			if (GridSize < 1) GridSize = 1;
        }

        public void SimulationStart()
        {
            timerCalculate.Enabled = true;
            timerRender.Enabled = true;
        }

        public void SimulationPause()
        {
            timerCalculate.Enabled = false;
            timerRender.Enabled = false;
        }

        public void SimulationNext()
        {
            timerCalculate_Tick(this, new EventArgs());
            timerRender_Tick(this, new EventArgs());
        }

		/// <summary>
		/// Fit the grid to view everything within control size
		/// </summary>
		public void FitBestGridSize()
		{
			int wRatio = Width / lifeGrid.Width;
			int hRatio = Height / lifeGrid.Height;

			int max = wRatio > hRatio ? hRatio : wRatio;

			GridSize = max;

			Invalidate();
		}

		public Image RenderToImage()
		{
			if (lifeGrid == null)
				return null;

			Image img = new Bitmap(lifeGrid.Width * GridSize, lifeGrid.Height * GridSize);
			using (Graphics g = Graphics.FromImage(img))
			{
				g.Clear(Color.Black);

				for (int x = 0; x < lifeGrid.Width; x++)
				{
					for (int y = 0; y < lifeGrid.Height; y++)
					{
						if (lifeGrid[x, y] == 0)
							continue;

						g.FillRectangle(Brushes.Red, x * GridSize, y * GridSize, GridSize, GridSize);
					}
				}
			}

			return img;

		}

        protected override void OnPaint(PaintEventArgs e)
        {
            if (backBuffer == null)
            {
                backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            Graphics g = Graphics.FromImage(backBuffer);
            g.Clear(Color.White);
            
            if (lifeGrid != null)
            {
                PaintGrid(g);

				if (lifeGrid.UseQuadtree)
				{
					PaintBoundingBoxes(g, lifeGrid.Quadtree.Root);
				}

				if (ShowGridLines)
				{
					PaintGridLines(g);
				}

				/*if (!string.IsNullOrEmpty(lifeGrid.PatternName))
				{
					g.DrawString(String.Format("{0} - Gen: {1} - Rule: {2}", lifeGrid.PatternName, lifeGrid.Generation, lifeGrid.Rule), SystemFonts.DefaultFont, Brushes.White, 1, 1);
				}
				else
				{
					g.DrawString(String.Format("Gen: {0} - Rule: {1}", lifeGrid.Generation, lifeGrid.Rule), SystemFonts.DefaultFont, Brushes.White, 1, 1);
				}*/
            }

			g.Dispose();
			e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

        private void PaintGrid(Graphics g)
        {
            g.FillRectangle(Brushes.Black, 0, 0, (lifeGrid.Width - ScrollLeft) * GridSize, (lifeGrid.Height - ScrollTop) * GridSize);

            for (int x = 0 + ScrollLeft; x < lifeGrid.Width; x++)
            {
                if ((x - ScrollLeft - 1) * GridSize > ClientSize.Width)
                {
                    x = lifeGrid.Width;
                    continue;
                }

				for (int y = 0 + ScrollTop; y < lifeGrid.Height; y++)
                {
                    if ((y - ScrollTop - 1) * GridSize > ClientSize.Height)
                    {
                        y = lifeGrid.Height;
                        continue;
                    }

                    if (lifeGrid[x, y] == 0)
                        continue;

                    g.FillRectangle(Brushes.Red, (x - ScrollLeft) * GridSize, (y - ScrollTop) * GridSize, GridSize, GridSize);
                }
            }
        }

		private void PaintGridLines(Graphics g)
		{
			if (GridSize < 3)
				return;

			int maxX = (lifeGrid.Width - ScrollLeft) * GridSize > ClientSize.Width ? ClientSize.Width : (lifeGrid.Width - ScrollLeft) * GridSize;
			int maxY = (lifeGrid.Height - ScrollTop) * GridSize > ClientSize.Height ? ClientSize.Height : (lifeGrid.Height - ScrollTop) * GridSize;

			for (int x = 0; x < maxX; x += GridSize)
			{
				g.DrawLine(Pens.Green, x, 0, x, maxY);
			}

			for (int y = 0; y < maxY; y += GridSize)
			{
				g.DrawLine(Pens.Green, 0, y, maxX, y); 
			}
		}

		private void PaintBoundingBoxes(Graphics g, LearnLifeCore.Math.GridQuadtreeNode gridQuadtreeNode)
		{
			if (gridQuadtreeNode == null)
				return;

			//TODO: Fix Quadtree then use Scroll and area checks!
			/*LearnLifeCore.Math.BoundingBox bb = gridQuadtreeNode.BoundingBox;
			if (gridQuadtreeNode.ContainsActiveFields) g.DrawRectangle(Pens.Green, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
			else if(gridQuadtreeNode.ContainsActiveCornerFields) g.DrawRectangle(Pens.Yellow, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
			//else g.DrawRectangle(Pens.Red, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
			
			if (gridQuadtreeNode.Children != null)
			{
				foreach (var node in gridQuadtreeNode.Children)
					PaintBoundingBoxes(g, node);
			}
			else
			{*/
				/*LearnLifeCore.Math.BoundingBox bb = gridQuadtreeNode.BoundingBox;
				if (gridQuadtreeNode.ContainsActiveFields) g.DrawRectangle(Pens.Green, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
				else if (gridQuadtreeNode.ContainsActiveCornerFields) g.DrawRectangle(Pens.Yellow, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
				//else g.DrawRectangle(Pens.Red, bb.MinX * GridSize, bb.MinY * GridSize, (bb.MaxX - bb.MinX) * GridSize, (bb.MaxY - bb.MinY) * GridSize);
			}*/
		}

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (backBuffer != null)
            {
                backBuffer.Dispose();
                backBuffer = null;
            }

            base.OnSizeChanged(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
			if (lifeGrid == null || !AllowDrawing)
            {
                base.OnMouseClick(e);
                return;
            }

            int x = (int)Math.Floor(e.X * 1.0/ GridSize) + ScrollLeft;
            int y = (int)Math.Floor(e.Y * 1.0 / GridSize) + ScrollTop;

            if (x >= lifeGrid.Width) return;
            if (y >= lifeGrid.Height) return;

            byte b = lifeGrid[x, y];
            if (b == 0) b = 1; else b = 0;
            lifeGrid[x, y] = b;

            base.OnMouseClick(e);

            Invalidate();
        }

        private void timerCalculate_Tick(object sender, EventArgs e)
        {
            lifeGrid.GenerateNext();

			if(GenerationChanged != null)
				GenerationChanged(this, new EventArgs());
        }

        private void timerRender_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
	}
}
