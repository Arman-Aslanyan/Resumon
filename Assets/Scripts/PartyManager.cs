using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public Resumon[] party = new Resumon[6];
    [SerializeField] [Range(0, 999)] private int ResuBalls = 10;
    public List<Resumon> stored = new List<Resumon>();

    public void SetPartyMemberTo(Resumon resu)
    {
        int index = FindOpenPartyIndex();
        if (index >= 0)
            party[index].SetResuTo(resu);
        else
            stored.Add(resu);
    }

    public bool CanSetPartyMember()
    {
        foreach (Resumon resumon in party)
        {
            if (resumon != null)
                return true;
        }
        return false;
    }

    public int FindOpenPartyIndex()
    {
        for (int i = 0; i < party.Length; i++)
        {
            if (party[i] == null)
            {
                return i;
            }
        }
        return -1;
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
    #region Setters
    public void SetResuBalls(int amount)
    {
        this.ResuBalls = amount;
    }
    #endregion
}
