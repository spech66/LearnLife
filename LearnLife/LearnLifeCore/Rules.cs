// Decompiled with JetBrains decompiler
// Type: LearnLifeCore.Rules
// Assembly: LearnLifeCore, Version=0.6.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0C347DC0-9616-4877-A1F1-563F6C354D35
// Assembly location: D:\Downloads\LearnLifeCore.dll

using System.Collections.Generic;

namespace LearnLifeCore
{
  public class Rules
  {
    private static System.Collections.Generic.List<Rule> ruleList = new System.Collections.Generic.List<Rule>();

    public static IEnumerable<Rule> List => (IEnumerable<Rule>) Rules.ruleList;

    static Rules()
    {
      Rules.ruleList.Add(new Rule("Conways Game of Life", "B3/S23"));
      Rules.ruleList.Add(new Rule("Maze", "B3/S12345"));
      Rules.ruleList.Add(new Rule("Replicator", "B1357/S1357"));
      Rules.ruleList.Add(new Rule("High Life", "B36/S23"));
      Rules.ruleList.Add(new Rule("Day & Night", "B3678/S34678"));
      Rules.ruleList.Add(new Rule("Life without Death", "B3/S012345678"));
      Rules.ruleList.Add(new Rule("2x2", "B36/S125"));
      Rules.ruleList.Add(new Rule("34 Life", "B34/S34"));
      Rules.ruleList.Add(new Rule("Seeds", "B2/S"));
      Rules.ruleList.Add(new Rule("Diamoeba", "B35678/S5678"));
      Rules.ruleList.Add(new Rule("Morley / Move", "B368/S245"));
      Rules.ruleList.Add(new Rule("3/3", "B3/S3"));
      Rules.ruleList.Add(new Rule("13/3", "B3/S13"));
      Rules.ruleList.Add(new Rule("34/3", "B3/S34"));
      Rules.ruleList.Add(new Rule("35/3", "B3/S35"));
      Rules.ruleList.Add(new Rule("Explosion", "B3/S236"));
      Rules.ruleList.Add(new Rule("Extended 13/3", "B35/S135"));
      Rules.ruleList.Add(new Rule("24/35", "B35/S24"));
      Rules.ruleList.Add(new Rule("B25/S4", "B25/S4"));
      Rules.ruleList.Add(new Rule("Flickering", "B01234/S0123"));
      Rules.ruleList.Add(new Rule("Anti-Conway", "B0123478/S01234678"));
      Rules.ruleList.Add(new Rule("Anti-4G3", "B0123678/S01234678"));
      Rules.ruleList.Add(new Rule("Anti-Replicator", "B02468/S02468"));
    }
  }
}
