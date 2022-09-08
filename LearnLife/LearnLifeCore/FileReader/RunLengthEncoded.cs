// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.RunLengthEncoded
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace LearnLifeCore.FileReader
{
  internal class RunLengthEncoded : FileReaderHelper, IFileReader
  {
    public string FileformatName => "Run Length Encoded";

    public IEnumerable<string> SupportedExtensions => (IEnumerable<string>) new List<string>()
    {
      ".rle"
    };

    public bool ReadFile(string filename)
    {
      using (StreamReader streamReader = new StreamReader(filename))
      {
        int curLine = 0;
        int lineX = 0;
        string empty = string.Empty;
        bool flag = false;
        while (!streamReader.EndOfStream)
        {
          string str1 = streamReader.ReadLine();
          if (str1.StartsWith("#C"))
          {
            Grid lifeGrid = this.LifeGrid;
            lifeGrid.PatternComment = lifeGrid.PatternComment + str1.Substring(2).Trim() + Environment.NewLine;
          }
          if (str1.StartsWith("#c"))
          {
            Grid lifeGrid = this.LifeGrid;
            lifeGrid.PatternComment = lifeGrid.PatternComment + str1.Substring(2).Trim() + Environment.NewLine;
          }
          if (str1.StartsWith("#N"))
            this.LifeGrid.PatternName += str1.Substring(2).Trim();
          if (str1.StartsWith("#O"))
            this.LifeGrid.PatternAuthor += str1.Substring(2).Trim();
          if (!str1.StartsWith("#P") && !str1.StartsWith("#R"))
          {
            if (str1.StartsWith("#r"))
              this.LifeGrid.ParsePatternRule(str1.Substring(2).Trim());
            if (!str1.StartsWith("#"))
            {
              if (str1.StartsWith("x"))
              {
                string str2 = str1;
                char[] chArray1 = new char[1]{ ',' };
                foreach (string str3 in str2.Split(chArray1))
                {
                  char[] chArray2 = new char[1]{ '=' };
                  string[] strArray = str3.Split(chArray2);
                  if (strArray[0].Trim() == "rule")
                    this.LifeGrid.ParsePatternRule(strArray[1].Trim());
                }
              }
              else
              {
                foreach (char ch in str1)
                {
                  switch (ch)
                  {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                      empty += ch.ToString();
                      break;
                    default:
                      switch (ch)
                      {
                        case '!':
                          flag = true;
                          break;
                        case '$':
                          int num = string.IsNullOrEmpty(empty) ? 1 : Convert.ToInt32(empty);
                          curLine += num;
                          lineX = 0;
                          break;
                        case 'b':
                          this.SetGridNodes(ref lineX, curLine, empty, (byte) 0);
                          break;
                        case 'o':
                          this.SetGridNodes(ref lineX, curLine, empty, (byte) 1);
                          break;
                        default:
                          return false;
                      }
                      empty = string.Empty;
                      break;
                  }
                }
                if (flag)
                  break;
              }
            }
          }
        }
      }
      return true;
    }

    private void SetGridNodes(ref int lineX, int curLine, string count, byte p)
    {
      int num = string.IsNullOrEmpty(count) ? 1 : Convert.ToInt32(count);
      for (int index = 0; index < num; ++index)
      {
        this.AddPoint(lineX, curLine, p);
        ++lineX;
      }
    }

    public Grid ReadGrid() => this.CreateGridFromPoints();
  }
}
