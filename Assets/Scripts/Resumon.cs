using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    private int lvl;
    private int gold;
    private int maxHp;
    private int curHp;

    public Stats(int lvl, int gold)
        : this()
    {
        this.lvl = lvl;
        this.gold = gold;
    }

    public Stats()
    {
        lvl = 0;
        gold = 0;
    }

    public int GetLvl() { return lvl; }
    public int GetGold() { return gold; }
    public int GetMaxHp() { return maxHp; }
    public int GetCurHp() { return curHp; }
    public void SetLvl(int lvl) { if (lvl >= 1) { this.lvl = lvl; } }
    public void SetGold(int gold) { if (gold >= 100) { this.gold = gold; } }
    public void SetMaxHp(int maxHp) { if (maxHp >= 1) { this.maxHp = maxHp; } }
    public void SetCurHp(int curHp) { if (curHp >= 0) { this.curHp = curHp; } }
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

[System.Serializable]
public class Resumon : MonoBehaviour
{
    public Stats stats = new Stats();
    public Info info = new Info();
    public GameObject prefab;

    public Resumon()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject body = Instantiate(prefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack(Resumon other)
    {
        //To-Do:
    }
}