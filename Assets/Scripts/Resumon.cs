using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] private int lvl;
    [SerializeField] private int gold;
    [SerializeField] private int maxHp;
    [SerializeField] private int curHp;
    [SerializeField] private int dmg = 5;

    public Stats(int lvl, int gold, int maxHp, int dmg)
        : this()
    {
        this.lvl = lvl;
        this.gold = gold;
        this.maxHp = maxHp;
        this.curHp = maxHp;
        this.dmg = dmg;
    }

    public Stats()
    {
        lvl = 0;
        gold = 0;
        maxHp = 10;
        curHp = maxHp;
        dmg = 1;
    }

    public int GetLvl() { return lvl; }
    public int GetGold() { return gold; }
    public int GetMaxHp() { return maxHp; }
    public int GetCurHp() { return curHp; }
    public int GetDmg() { return dmg; }
    public void SetLvl(int lvl) { if (lvl >= 1) { this.lvl = lvl; } }
    public void SetGold(int gold) { if (gold >= 100) { this.gold = gold; } }
    public void SetMaxHp(int maxHp) { if (maxHp >= 1) { this.maxHp = maxHp; } }
    public void SetCurHp(int curHp) { if (curHp >= 0) { this.curHp = curHp; } }
    public void SetDmg(int dmg) { this.dmg = dmg; }
}

[System.Serializable]
public class Info
{
    public string name;
    public int ResuNum;
    public string gender;
    public string behaviour;
    public string lore;

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

    public void attack(Resumon other)
    {
        //To-Do:
        other.stats.SetCurHp(other.stats.GetCurHp() - stats.GetDmg());
    }

    public new string ToString()
    {
        return "No. " + info.ResuNum + " | Name: " + info.name + " |";
    }
}