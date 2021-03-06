using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumon : MonoBehaviour
{
    public ResumonBase _base;
    public Stats stats;
    public Info info;
    public Sprite sprite;
    public ResumonType type1;
    public ResumonType type2;
    public ResumonRarity rarity;
    
    public Resumon(ResumonBase _base)
    {
        this._base = _base;
        stats = new Stats(_base);
        info = new Info(_base);
        sprite = _base.sprite;
        type1 = _base.type1;
        type2 = _base.type2;
    }

    public Resumon()
    {
        _base = null;
        stats = new Stats();
        info = new Info();
        sprite = null;
        type1 = ResumonType.None;
        type2 = ResumonType.None;
    }

    public void Attack(Resumon other)
    {
        //To-Do:
    }

    public void SetResuTo(Resumon other)
    {
        this._base = other._base;
        this.stats.SetStatsTo(other.stats);
        this.info.SetInfoTo(other.info);
        this.sprite = other.sprite;
        this.type1 = other.type1;
        this.type2 = other.type2;
    }
}
