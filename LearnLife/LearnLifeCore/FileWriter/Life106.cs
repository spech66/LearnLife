// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileWriter.Life106
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.IO;

namespace LearnLifeCore.FileWriter
{
  public class Life106 : IFileWriter
  {
    public bool WriteFile(string filename, Grid grid)
    {
      using (StreamWriter streamWriter = new StreamWriter(filename))
      {
        streamWriter.WriteLine("#Life 1.06");
        int num1 = (int) System.Math.Ceiling((double) grid.Width / 2.0);
        int num2 = (int) System.Math.Ceiling((double) grid.Height / 2.0);
        for (int y = 0; y < grid.Height; ++y)
        {
          for (int x = 0; x < grid.Width; ++x)
          {
            if (grid[x, y] == (byte) 1)
              streamWriter.WriteLine("{0} {1}", (object) (x - num1), (object) (y - num2));
          }
        }
      }
      return true;
    }
  }
}
