// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.Life
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace LearnLifeCore.FileReader
{
  internal class Life : FileReaderHelper, IFileReader
  {
    public string FileformatName => "Life 1.05/1.06";

    public IEnumerable<string> SupportedExtensions => (IEnumerable<string>) new List<string>()
    {
      ".life",
      ".lif"
    };

    public bool ReadFile(string filename)
    {
      using (StreamReader reader = new StreamReader(filename))
      {
        string str = reader.ReadLine();
        if (str.Contains("1.05"))
          return this.Read105(reader);
        if (str.Contains("1.06"))
          return this.Read106(reader);
      }
      return false;
    }

    private bool Read105(StreamReader reader)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      while (!reader.EndOfStream)
      {
        string str = reader.ReadLine();
        if (!string.IsNullOrEmpty(str))
        {
          if (str.StartsWith("#D"))
          {
            Grid lifeGrid = this.LifeGrid;
            lifeGrid.PatternComment = lifeGrid.PatternComment + str.Substring(2).Trim() + Environment.NewLine;
          }
          if (str.StartsWith("#N"))
            this.LifeGrid.ParsePatternRule("23/3");
          if (str.StartsWith("#R"))
            this.LifeGrid.ParsePatternRule(str.Substring(2).Trim());
          if (str.StartsWith("#P"))
          {
            string[] strArray = str.Substring(2).Trim().Split(' ');
            num1 = Convert.ToInt32(strArray[0]);
            num2 = Convert.ToInt32(strArray[1]);
            num3 = 0;
          }
          if (!str.StartsWith("#"))
          {
            int num4 = 0;
            foreach (char ch in str)
            {
              if (ch == '.')
                this.AddPoint(num1 + num4, num2 + num3, (byte) 0);
              if (ch == '*')
                this.AddPoint(num1 + num4, num2 + num3, (byte) 1);
              ++num4;
            }
            ++num3;
          }
        }
      }
      return true;
    }

    private bool Read106(StreamReader reader)
    {
      while (!reader.EndOfStream)
      {
        string str = reader.ReadLine();
        if (!string.IsNullOrEmpty(str) && !str.StartsWith("#"))
        {
          string[] strArray = str.Trim().Split(' ');
          this.AddPoint(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]), (byte) 1);
        }
      }
      return true;
    }

    public Grid ReadGrid() => this.CreateGridFromPoints();
  }
}
