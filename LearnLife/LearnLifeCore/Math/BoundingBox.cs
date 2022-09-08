// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Math.BoundingBox
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

namespace LearnLifeCore.Math
{
  public class BoundingBox
  {
    public int MinX;
    public int MaxX;
    public int MinY;
    public int MaxY;

    public BoundingBox(int minX, int minY, int maxX, int maxY)
    {
      this.MinX = minX;
      this.MaxX = maxX;
      this.MinY = minY;
      this.MaxY = maxY;
    }

    public bool Collision(BoundingBox checkBox) => this.MaxX >= checkBox.MinX && this.MinX <= checkBox.MaxX && this.MaxY >= checkBox.MinY && this.MinY <= checkBox.MaxY;
  }
}
