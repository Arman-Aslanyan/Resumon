using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resumon : MonoBehaviour
{
    public ResumonBase _base {get; set;}
    public Stats stats = new Stats();
    public Info info = new Info();
    public Sprite sprite;
    public ResumonType type1;
    public ResumonType type2;
    
    public Resumon(ResumonBase _base)
    {
        this._base = _base;
        SetResuTo(_base);
    }

    public void Attack(Resumon other)
    {
        //To-Do:
    }

    public void SetResuTo(Resumon other)
    {
        print("AAAAAAAAAAAAAAAAAAAA");
        stats.SetStatsTo(other.stats);
        info.SetInfoTo(other.info);
        sprite = other.sprite;
        type1 = other.type1;
        type2 = other.type2;
    }

    public void SetResuTo(ResumonBase other)
    {
        print("BBBBBBBBBBBBBBBBBBBB");
        stats.SetStatsTo(other.stats);
        info.SetInfoTo(other.info);
        sprite = other.sprite;
        type1 = other.type1;
        type2 = other.type2;
    }
}
