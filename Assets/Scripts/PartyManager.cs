using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [Range(0, 999)] public int ResuBalls = 10;
    public Resumon[] party = new Resumon[6];
    //public List<Resumon> stored = new List<Resumon>();

    public void SetPartyMemberTo(Resumon resu)
    {
        int index = FindOpenPartyIndex();
        if (index >= 0 && ResuBalls > 0)
        {
            Resumon caught = new Resumon(resu._base);
            gameObject.transform.GetChild(index).GetComponent<Resumon>().SetResuTo(caught);
            party[index] = gameObject.transform.GetChild(index).GetComponent<Resumon>();
            ResuBalls--;
        }
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

    #region Getters & Setters
    public int GetResuNumInParty()
    {
        int resu = 0;
        foreach (Resumon resumon in party)
            if (resumon != null)
                resu++;
        return resu;
    }

    public int GetResuBalls() { return ResuBalls; }
    public void SetResuBalls(int amount)
    {
        this.ResuBalls = amount;
    }
    #endregion
}
