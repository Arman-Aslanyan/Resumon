using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    private int lvl;
    private int gold;

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
}

public class Resumon : MonoBehaviour
{
    public Stats stats = new Stats();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack()
    {
        //To-Do:
    }
}
