// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.FileReader.FileReader
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnLifeCore.FileReader
{
  public class FileReader
  {
    private List<IFileReader> reader = new List<IFileReader>();

    public IEnumerable<string> SupportedExtensions => this.reader.SelectMany<IFileReader, string>((Func<IFileReader, IEnumerable<string>>) (sel => sel.SupportedExtensions));

    public int Border { get; set; }

    public FileReader()
    {
      this.reader.Add((IFileReader) new RunLengthEncoded());
      this.reader.Add((IFileReader) new Life());
      this.reader.Add((IFileReader) new Plaintext());
    }

    public string GetFileDialogFilter()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (IFileReader fileReader in this.reader)
      {
        stringBuilder.Append(fileReader.FileformatName);
        string str1 = string.Empty;
        foreach (string supportedExtension in fileReader.SupportedExtensions)
          str1 = str1 + "*" + supportedExtension + ";";
        string str2 = str1.TrimEnd(';');
        stringBuilder.AppendFormat(" ({0})|{0}|", (object) str2);
      }
      return stringBuilder.ToString().TrimEnd('|');
    }

    public Grid ReadFile(string filename)
    {
      foreach (IFileReader fileReader in this.reader)
      {
        foreach (string supportedExtension in fileReader.SupportedExtensions)
        {
          if (filename.EndsWith(supportedExtension, StringComparison.InvariantCultureIgnoreCase))
          {
            fileReader.Border = this.Border;
            if (fileReader.ReadFile(filename))
              return fileReader.ReadGrid();
          }
        }
      }
      return (Grid) null;
    }
  }
}
