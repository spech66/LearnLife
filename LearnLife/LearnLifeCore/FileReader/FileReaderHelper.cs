// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.FileReaderHelper
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using LearnLifeCore.Math;
using System;
using System.Collections.Generic;

namespace LearnLifeCore.FileReader
{
  internal class FileReaderHelper
  {
    private Grid lifeGrid = new Grid();
    private List<Tuple<int, int, byte>> pointList = new List<Tuple<int, int, byte>>();
    private BoundingBox border = new BoundingBox(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);

    public Grid LifeGrid => this.lifeGrid;

    public int Border { get; set; }

    public void AddPoint(int x, int y, byte value)
    {
      if (value > (byte) 0)
        this.pointList.Add(new Tuple<int, int, byte>(x, y, value));
      if (x < this.border.MinX)
        this.border.MinX = x;
      if (y < this.border.MinY)
        this.border.MinY = y;
      if (x > this.border.MaxX)
        this.border.MaxX = x;
      if (y <= this.border.MaxY)
        return;
      this.border.MaxY = y;
    }

    public Grid CreateGridFromPoints()
    {
      int num1 = (int) System.Math.Ceiling((double) this.Border / 2.0);
      int num2 = (int) System.Math.Ceiling((double) this.Border / 2.0);
      bool flag = false;
      int num3 = this.border.MaxX + 1;
      int num4 = this.border.MaxY + 1;
      int num5 = System.Math.Abs(this.border.MinX);
      int num6 = System.Math.Abs(this.border.MinY);
      if (this.border.MinX < 0)
      {
        num3 += num5;
        flag = true;
      }
      if (this.border.MinY < 0)
      {
        num4 += num6;
        flag = true;
      }
      this.lifeGrid.NewGrid(num3 + this.Border, num4 + this.Border);
      foreach (Tuple<int, int, byte> point in this.pointList)
      {
        if (flag)
          this.lifeGrid[point.Item1 + num5 + num1, point.Item2 + num6 + num2] = point.Item3;
        else
          this.lifeGrid[point.Item1 + num1, point.Item2 + num2] = point.Item3;
      }
      return this.lifeGrid;
    }
  }
}
