// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileWriter.Plaintext
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.IO;

namespace LearnLifeCore.FileWriter
{
  public class Plaintext : IFileWriter
  {
    public bool WriteFile(string filename, Grid grid)
    {
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(filename))
        {
          streamWriter.WriteLine("!Name: {0}", (object) grid.PatternName);
          if (!string.IsNullOrEmpty(grid.PatternAuthor))
            streamWriter.WriteLine("!Author: {0}", (object) grid.PatternAuthor);
          if (!string.IsNullOrEmpty(grid.PatternComment))
          {
            string patternComment = grid.PatternComment;
            string[] separator = new string[1]
            {
              Environment.NewLine
            };
            foreach (string str in patternComment.Split(separator, StringSplitOptions.RemoveEmptyEntries))
              streamWriter.WriteLine("!{0}", (object) str.Trim());
          }
          bool flag = false;
          int num1 = 0;
          int num2 = 0;
          for (int y = 0; y < grid.Height; ++y)
          {
            for (int x = 0; x < grid.Width; ++x)
            {
              if (grid[x, y] == (byte) 0)
              {
                ++num1;
              }
              else
              {
                flag = true;
                for (int index = 0; index < num2; ++index)
                  streamWriter.WriteLine();
                num2 = 0;
                if (num1 > 0)
                {
                  for (int index = 0; index < num1; ++index)
                    streamWriter.Write('.');
                  num1 = 0;
                }
                streamWriter.Write("O");
              }
            }
            num1 = 0;
            if (flag)
              ++num2;
          }
          streamWriter.WriteLine();
        }
        return true;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
