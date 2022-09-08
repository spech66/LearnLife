// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Rule
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

namespace LearnLifeCore
{
  public class Rule
  {
    public string Name { get; set; }

    public string RuleString { get; set; }

    public Rule(string name, string rule)
    {
      this.Name = name;
      this.RuleString = rule;
    }
  }
}
