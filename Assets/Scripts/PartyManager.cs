using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public Resumon[] party = new Resumon[6];
    [SerializeField] [Range(0, 999)] private int ResuBalls = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    #region Getters
    public int GetResuNumInParty()
    {
        int resu = 0;
        foreach (Resumon resumon in party)
            if (resumon != null)
                resu++;
        return resu;
    }

    public int GetResuBalls() { return ResuBalls; }
    #endregion
}
