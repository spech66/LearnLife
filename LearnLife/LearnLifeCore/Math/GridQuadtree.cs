// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Math.GridQuadtree
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

namespace LearnLifeCore.Math
{
  public class GridQuadtree
  {
    private GridQuadtreeNode rootNode;
    private BoundingBox rootBox;
    private int depth;

    public GridQuadtreeNode Root => this.rootNode;

    public GridQuadtree(int minX, int minY, int maxX, int maxY, int maxDepth)
    {
      this.depth = maxDepth;
      this.rootNode = new GridQuadtreeNode(minX, minY, maxX, maxY, 0, maxDepth);
      this.rootBox = new BoundingBox(minX, minY, maxX, maxY);
    }

    internal void Update(Grid grid) => this.rootNode.Update(grid);
  }
}
