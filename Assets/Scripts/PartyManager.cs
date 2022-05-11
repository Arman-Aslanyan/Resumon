using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [Range(0, 999)] public int ResuBalls = 10;
    public Resumon[] party = new Resumon[6];
    public List<Resumon> stored = new List<Resumon>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Resumon resu = FindObjectOfType<GameManager>().enemyObj.GetComponent<Resumon>();
            if (resu != null)
            {
                SetPartyMemberTo(resu);
            }
        }
    }

    public void SetPartyMemberTo(Resumon resu)
    {
        print("test" + ResuBalls);
        int index = FindOpenPartyIndex();
        if (index >= 0)
        {
            Resumon caught = new Resumon(resu.template);
            gameObject.transform.GetChild(0).GetComponent<Resumon>().SetResuTo(caught);
            party[index] = gameObject.transform.GetChild(index).GetComponent<Resumon>();
            print(party[index] + "      |      " + gameObject.transform.GetChild(0).GetComponent<Resumon>());
        }
        else
            stored.Add(resu);
        ResuBalls--;
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
