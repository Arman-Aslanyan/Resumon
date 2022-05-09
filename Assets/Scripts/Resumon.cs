using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int lvl;
    public int maxHp;
    public int curHp;
    public int atk;
    public int def;
    public int spAtk;
    public int spDef;
    public int spd;
    [SerializeField] [Range(0, 1)] public float captChance;

    public Stats(int lvl, int maxHp, int atk, int def, int spAtk, int spDef, int spd)
        : this()
    {
        SetLvl(lvl);
        SetMaxHp(maxHp);
        SetCurHp(maxHp);
        SetAtk(atk);
        SetDef(def);
        SetSpAtk(spAtk);
        SetSpDef(spDef);
        SetSpd(spd);
    }

    public Stats()
    {
        lvl = 0;
        maxHp = 10;
        curHp = maxHp;
        atk = 1;
        def = 1;
        spAtk = 1;
        spDef = 1;
        spd = 1;
        this.captChance = 1;
    }

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
    public void SetAtk(int atk) { if (atk >= 0 ) { this.atk = atk; } }
    public void SetDef(int def) { this.def = def; }
    public void SetSpAtk(int spAtk) { if (spAtk >= 0) { this.spAtk = spAtk; } }
    public void SetSpDef(int spDef) { this.spDef = spDef; }
    public void SetSpd (int spd) { if (spd >= 0) { this.spd = spd; } }
    public void SetCaptChance(int captChance) { if (captChance > 0) { this.captChance = captChance; } }
    #endregion
}

[System.Serializable]
public class Info
{
    public string name;
    public int ResuNum;
    public string gender;
    public string behaviour;
    [TextArea] public string lore;

    public Info(string name, int ResuNum, string gender, string behaviour, string lore)
        : this()
    {
        this.name = name;
        this.ResuNum = ResuNum;
        this.gender = gender;
        this.behaviour = behaviour;
        this.lore = lore;
    }

    public Info()
    {
        name = null;
        ResuNum = 5;
        gender = null;
        behaviour = null;
        lore = null;
    }

    public void SetInfoTo(Info other)
    {
        name = other.name;
        ResuNum = other.ResuNum;
        gender = other.gender;
        behaviour = other.behaviour;
        lore = other.lore;
    }
}

[CreateAssetMenu(fileName = "New Resumon", menuName = "Resumon/Create new Resumon")]
public class Resumon : ScriptableObject
{
    public Stats stats = new Stats();
    public Info info = new Info();
    public Sprite sprite;
    [SerializeField] ResumonType type1;
    [SerializeField] ResumonType type2;
    [SerializeField] List<Move> learnableMoves = new List<Move>();

    public void Attack(Resumon other)
    {
        //To-Do:
    }

    public void SetResuTo(Resumon other)
    {
        stats.SetStatsTo(other.stats);
        info.SetInfoTo(other.info);
        sprite = other.sprite;
        type1 = other.type1;
        type2 = other.type2;
    }

    public new string ToString()
    {
        return "No. " + info.ResuNum + " | Name: " + info.name + " |";
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