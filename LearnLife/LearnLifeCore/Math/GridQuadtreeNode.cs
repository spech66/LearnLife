// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Math.GridQuadtreeNode
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System.Collections.Generic;

namespace LearnLifeCore.Math
{
  public class GridQuadtreeNode
  {
    private List<GridQuadtreeNode> childNodes;
    private BoundingBox nodeBox;
    private int depth;
    private int maxDepth;
    private bool containsActiveFields;
    private bool cornerActiveTop;
    private bool cornerActiveBottom;
    private bool cornerActiveLeft;
    private bool cornerActiveRight;

    public IEnumerable<GridQuadtreeNode> Children => (IEnumerable<GridQuadtreeNode>) this.childNodes;

    public BoundingBox BoundingBox => this.nodeBox;

    public bool ContainsActiveFields => this.containsActiveFields;

    public bool ContainsActiveCornerFields => this.cornerActiveTop || this.cornerActiveBottom || this.cornerActiveLeft || this.cornerActiveRight;

    public GridQuadtreeNode(int minX, int minY, int maxX, int maxY, int depth, int maxDepth)
    {
      this.containsActiveFields = true;
      this.nodeBox = new BoundingBox(minX, minY, maxX, maxY);
      this.depth = depth;
      this.maxDepth = maxDepth;
      ++depth;
      if (depth == maxDepth)
        return;
      this.childNodes = new List<GridQuadtreeNode>();
      int num1 = (this.nodeBox.MaxX - this.nodeBox.MinX) / 2 + this.nodeBox.MinX;
      int num2 = (this.nodeBox.MaxY - this.nodeBox.MinY) / 2 + this.nodeBox.MinY;
      this.childNodes.Add(new GridQuadtreeNode(minX, minY, num1, num2, depth, maxDepth));
      this.childNodes.Add(new GridQuadtreeNode(minX, num2, num1, maxY, depth, maxDepth));
      this.childNodes.Add(new GridQuadtreeNode(num1, minY, maxX, num2, depth, maxDepth));
      this.childNodes.Add(new GridQuadtreeNode(num1, num2, maxX, maxY, depth, maxDepth));
    }

    internal void Update(Grid grid)
    {
      if (!this.containsActiveFields && !this.ContainsActiveCornerFields)
        return;
      this.containsActiveFields = false;
      this.cornerActiveTop = this.cornerActiveBottom = this.cornerActiveLeft = this.cornerActiveRight = false;
      if (this.childNodes != null && this.childNodes.Count > 0)
      {
        foreach (GridQuadtreeNode childNode in this.childNodes)
        {
          childNode.Update(grid);
          if (childNode.ContainsActiveFields)
            this.containsActiveFields = true;
          if (childNode.ContainsActiveCornerFields)
          {
            if ((childNode == this.childNodes[2] || childNode == this.childNodes[3]) && childNode.cornerActiveBottom)
              this.cornerActiveBottom = true;
            if (childNode != this.childNodes[2] && childNode != this.childNodes[3] && childNode.cornerActiveBottom)
            {
              this.SetActiveCornerFieldsToChildren(this.childNodes[0]);
              this.SetActiveCornerFieldsToChildren(this.childNodes[1]);
            }
          }
        }
      }
      else
      {
        for (int minX = this.nodeBox.MinX; minX < this.nodeBox.MaxX; ++minX)
        {
          for (int minY = this.nodeBox.MinY; minY < this.nodeBox.MaxY; ++minY)
          {
            if (this.CheckNeighbours(grid, minX, minY))
            {
              grid[minX, minY] = (byte) 1;
              this.containsActiveFields = true;
              if (minY >= this.nodeBox.MaxY - 1)
                this.cornerActiveBottom = true;
            }
            else
              grid[minX, minY] = (byte) 0;
          }
        }
      }
    }

    private void SetActiveCornerFieldsToChildren(GridQuadtreeNode node)
    {
      if (node.childNodes == null)
        return;
      this.cornerActiveBottom = true;
    }

    private bool CheckNeighbours(Grid grid, int x, int y)
    {
      int num = 0;
      if (this.Alive(grid, x - 1, y))
        ++num;
      if (this.Alive(grid, x, y - 1))
        ++num;
      if (this.Alive(grid, x, y + 1))
        ++num;
      if (this.Alive(grid, x + 1, y))
        ++num;
      if (this.Alive(grid, x - 1, y - 1))
        ++num;
      if (this.Alive(grid, x - 1, y + 1))
        ++num;
      if (this.Alive(grid, x + 1, y - 1))
        ++num;
      if (this.Alive(grid, x + 1, y + 1))
        ++num;
      switch (num)
      {
        case 2:
          if (grid.GetFirstGrid(x, y) != (byte) 0)
            goto case 3;
          else
            break;
        case 3:
          return true;
      }
      return false;
    }

    private bool Alive(Grid grid, int x, int y) => x >= 0 && y >= 0 && x <= grid.Width - 1 && y <= grid.Height - 1 && grid.GetFirstGrid(x, y) == (byte) 1;
  }
}
