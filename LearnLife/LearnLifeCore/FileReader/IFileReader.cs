// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.IFileReader
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System.Collections.Generic;

namespace LearnLifeCore.FileReader
{
  internal interface IFileReader
  {
    string FileformatName { get; }

    IEnumerable<string> SupportedExtensions { get; }

    int Border { get; set; }

    bool ReadFile(string filename);

    Grid ReadGrid();
  }
}
