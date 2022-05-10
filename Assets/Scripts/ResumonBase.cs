using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resumon", menuName = "Resumon/Create new Resumon")]
public class ResumonBase : ScriptableObject
{
    //public Stats stats = new Stats();
    //Stats
    private int lvl;
    private int maxHp;
    private int curHp;
    private int atk;
    private int def;
    private int spAtk;
    private int spDef;
    private int spd;
    [SerializeField] [Range(0, 1)] public float captChance;

    public void SetStatsTo(Stats other)
    {
        SetLvl(other.GetLvl());
        SetMaxHp(other.GetMaxHp());
        SetCurHp(other.GetCurHp());
        SetAtk(other.GetAtk());
        SetDef(other.GetDef());
        SetSpAtk(other.GetSpAtk());
        SetSpDef(other.GetSpDef());
        SetSpd(other.GetSpd());
    }

    #region Getters & Setters
    public int GetLvl() { return lvl; }
    public int GetMaxHp() { return maxHp; }
    public int GetCurHp() { return curHp; }
    public int GetAtk() { return atk; }
    public int GetDef() { return def; }
    public int GetSpAtk() { return spAtk; }
    public int GetSpDef() { return spDef; }
    public int GetSpd() { return spd; }
    public float GetCaptChance() { return captChance; }
    public void SetLvl(int lvl) { if (lvl >= 1) { this.lvl = lvl; } }
    public void SetMaxHp(int maxHp) { if (maxHp >= 1) { this.maxHp = maxHp; } }
    public void SetCurHp(int curHp) { if (curHp >= 0) { this.curHp = curHp; } }
    public void SetAtk(int atk) { if (atk >= 0) { this.atk = atk; } }
    public void SetDef(int def) { this.def = def; }
    public void SetSpAtk(int spAtk) { if (spAtk >= 0) { this.spAtk = spAtk; } }
    public void SetSpDef(int spDef) { this.spDef = spDef; }
    public void SetSpd(int spd) { if (spd >= 0) { this.spd = spd; } }
    public void SetCaptChance(int captChance) { if (captChance > 0) { this.captChance = captChance; } }
    #endregion

    //public Info info = new Info();
    //Info
    public new string name;
    public int ResuNum;
    public string gender;
    public string behaviour;
    [TextArea] public string lore;
    public Sprite sprite;
    public ResumonType type1;
    public ResumonType type2;
    [SerializeField] List<Move> learnableMoves = new List<Move>();

    public void SetInfoTo(Info other)
    {
        name = other.name;
        ResuNum = other.ResuNum;
        gender = other.gender;
        behaviour = other.behaviour;
        lore = other.lore;
    }

    public new string ToString()
    {
        return "No. " + ResuNum + " | Name: " + name + " |";
    }
}

public enum ResumonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Dark,
    Bug,
    Rock,
    Ghost,
    Dragon
}