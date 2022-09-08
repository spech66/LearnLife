// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Grid
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using LearnLifeCore.Math;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLifeCore
{
  public class Grid
  {
    private int width;
    private int height;
    private byte[][] grid1;
    private byte[][] grid2;
    private long generation;
    private List<int> birth;
    private List<int> survival;
    private GridQuadtree quadtree;

    public bool UseQuadtree { get; set; }

    public GridQuadtree Quadtree => this.quadtree;

    public int Width => this.width;

    public int Height => this.height;

    public long Generation => this.generation;

    public byte this[int x, int y]
    {
      get => this.grid2[x][y];
      set => this.grid2[x][y] = value;
    }

    public string PatternName { get; set; }

    public string PatternComment { get; set; }

    public string PatternAuthor { get; set; }

    public string PatternRule { get; set; }

    public string PatternExtra { get; set; }

    public string Rule { get; private set; }

    public Grid(int width, int height)
    {
      this.ParsePatternRule("23/3");
      this.NewGrid(width, height);
    }

    internal Grid()
    {
      this.ParsePatternRule("23/3");
      this.NewGrid(1, 1);
    }

    internal void NewGrid(int width, int height)
    {
      this.UseQuadtree = false;
      this.generation = 0L;
      this.width = width;
      this.height = height;
      this.grid2 = new byte[width][];
      for (int index = 0; index < width; ++index)
        this.grid2[index] = new byte[height];
      for (int index1 = 0; index1 < width; ++index1)
      {
        for (int index2 = 0; index2 < height; ++index2)
          this.grid2[index1][index2] = (byte) 0;
      }
      this.quadtree = new GridQuadtree(0, 0, width, height, 4);
    }

    public byte GetFirstGrid(int x, int y) => this.grid1[x][y];

    public void GenerateNext()
    {
      if (this.UseQuadtree)
      {
        this.GenerateNextQuadtree();
      }
      else
      {
        ++this.generation;
        this.grid1 = ((IEnumerable<byte[]>) this.grid2).Select<byte[], byte[]>((Func<byte[], byte[]>) (s => ((IEnumerable<byte>) s).ToArray<byte>())).ToArray<byte[]>();
        for (int x = 0; x < this.width; ++x)
        {
          for (int y = 0; y < this.height; ++y)
          {
            int num1 = 0;
            if (this.Alive(x - 1, y))
              ++num1;
            if (this.Alive(x, y - 1))
              ++num1;
            if (this.Alive(x, y + 1))
              ++num1;
            if (this.Alive(x + 1, y))
              ++num1;
            if (this.Alive(x - 1, y - 1))
              ++num1;
            if (this.Alive(x - 1, y + 1))
              ++num1;
            if (this.Alive(x + 1, y - 1))
              ++num1;
            if (this.Alive(x + 1, y + 1))
              ++num1;
            byte num2 = 0;
            foreach (int num3 in this.birth)
            {
              if (num3 == num1 && this.grid1[x][y] == (byte) 0)
                num2 = (byte) 1;
            }
            if (num2 == (byte) 0)
            {
              foreach (int num4 in this.survival)
              {
                if (num4 == num1 && this.grid1[x][y] == (byte) 1)
                  num2 = (byte) 1;
              }
            }
            this.grid2[x][y] = num2;
          }
        }
      }
    }

    private void GenerateNextQuadtree()
    {
      ++this.generation;
      this.grid1 = ((IEnumerable<byte[]>) this.grid2).Select<byte[], byte[]>((Func<byte[], byte[]>) (s => ((IEnumerable<byte>) s).ToArray<byte>())).ToArray<byte[]>();
      this.quadtree.Update(this);
    }

    public void RandomWorld(int percent)
    {
      Random random = new Random();
      for (int index1 = 0; index1 < this.width; ++index1)
      {
        for (int index2 = 0; index2 < this.height; ++index2)
          this.grid2[index1][index2] = random.Next(101) > percent ? (byte) 0 : (byte) 1;
      }
    }

    private bool Alive(int x, int y) => x >= 0 && y >= 0 && x <= this.width - 1 && y <= this.height - 1 && this.grid1[x][y] == (byte) 1;

    public void ParsePatternRule(string sbrule)
    {
      this.PatternRule = sbrule.ToUpper();
      bool flag = this.PatternRule.Contains<char>('B') || this.PatternRule.Contains<char>('S');
      string[] strArray = this.PatternRule.Split('/');
      string source1;
      string source2;
      if (flag)
      {
        if (strArray[0].StartsWith("S"))
        {
          string str = strArray[1];
          strArray[1] = strArray[0];
          strArray[0] = str;
        }
        source1 = strArray[0].Substring(1);
        source2 = strArray[1].Substring(1);
      }
      else
      {
        source1 = strArray[1];
        source2 = strArray[0];
      }
      this.birth = source1.ToList<char>().Select<char, int>((Func<char, int>) (sel => int.Parse(sel.ToString()))).ToList<int>();
      this.survival = source2.ToList<char>().Select<char, int>((Func<char, int>) (sel => int.Parse(sel.ToString()))).ToList<int>();
      this.Rule = string.Format("B{0}/S{1}", (object) source1, (object) source2);
    }
  }
}
