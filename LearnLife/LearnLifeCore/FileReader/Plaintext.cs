// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.Plaintext
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace LearnLifeCore.FileReader
{
  internal class Plaintext : FileReaderHelper, IFileReader
  {
    public string FileformatName => nameof (Plaintext);

    public IEnumerable<string> SupportedExtensions => (IEnumerable<string>) new List<string>()
    {
      ".txt",
      ".cells"
    };

    public bool ReadFile(string filename)
    {
      using (StreamReader streamReader = new StreamReader(filename))
      {
        string str1 = streamReader.ReadLine();
        if (!str1.StartsWith("!Name:"))
          return false;
        this.LifeGrid.PatternName = str1.Substring(6).Trim();
        int y = 0;
        while (!streamReader.EndOfStream)
        {
          string str2 = streamReader.ReadLine();
          if (str2.StartsWith("!Author:"))
          {
            this.LifeGrid.PatternAuthor = str2.Substring(8).Trim();
          }
          else
          {
            if (str2.StartsWith("!"))
            {
              Grid lifeGrid = this.LifeGrid;
              lifeGrid.PatternComment = lifeGrid.PatternComment + str2.Substring(1).Trim() + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(str2))
            {
              ++y;
            }
            else
            {
              int x = 0;
              foreach (char ch in str2)
              {
                if (ch == '.')
                  this.AddPoint(x, y, (byte) 0);
                if (ch == 'O')
                  this.AddPoint(x, y, (byte) 1);
                ++x;
              }
              ++y;
            }
          }
        }
      }
      return true;
    }

    public Grid ReadGrid() => this.CreateGridFromPoints();
  }
}
