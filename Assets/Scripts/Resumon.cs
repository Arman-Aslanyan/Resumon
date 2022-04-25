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
        this.lvl = lvl;
        this.maxHp = maxHp;
        this.curHp = maxHp;
        this.atk = atk;
        this.def = def;
        this.spAtk = spAtk;
        this.spDef = spDef;
        this.spd = spd;
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
    #region Getters & Setters
    public int GetLvl() { return lvl; }
    public int GetMaxHp() { return maxHp; }
    public int GetCurHp() { return curHp; }
    public float GetCaptChance() { return captChance; }
    public void SetLvl(int lvl) { if (lvl >= 1) { this.lvl = lvl; } }
    public void SetMaxHp(int maxHp) { if (maxHp >= 1) { this.maxHp = maxHp; } }
    public void SetCurHp(int curHp) { if (curHp >= 0) { this.curHp = curHp; } }
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
}

[CreateAssetMenu(fileName = "New Resumon", menuName = "Resumon")]
public class Resumon : ScriptableObject
{
    public Stats stats = new Stats();
    public Info info = new Info();
    public Sprite sprite;
    [SerializeField] ResumonType type1;
    [SerializeField] ResumonType type2;

    public void Attack(Resumon other)
    {
        //To-Do:
        
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
    Bug,
    Rock,
    Ghost,
    Dragon
}