using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    PlayerController player;
    public ResumonBase[] WildResumon = new ResumonBase[3];
    public GameObject prefab;
    [HideInInspector] public GameObject enemyObj;
    PartyManager partyManager;

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
        partyManager = FindObjectOfType<PartyManager>();
        player = FindObjectOfType<PlayerController>();
        enemyObj = transform.GetChild(0).gameObject;
        GameManager[] objs = FindObjectsOfType<GameManager>();
        if (objs.Length > 1)
            for (int i = 1; i < objs.Length; i++)
                Destroy(objs[i].gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
            SceneManager.LoadScene("Main");
        }
    }

    public void PreEncounter()
    {
        FindObjectOfType<LevelLoader>().StartEncounter();
    }

    public void BeginEncounter()
    {
        float rand = Random.value;
        int randNum;
        if (rand < 0.5f)
            randNum = 0;
        else if (rand < 0.9f)
            randNum = 1;
        else randNum = 2;
        if (randNum == 0) randNum = Random.Range(0, NumOfGivenRarity(ResumonRarity.Common)) + NumOfGivenRarity(ResumonRarity.Common);
        else if (randNum == 1) randNum = Random.Range(0, NumOfGivenRarity(ResumonRarity.Uncommon)) + NumOfGivenRarity(ResumonRarity.Uncommon);
        else randNum = Random.Range(0, NumOfGivenRarity(ResumonRarity.Rare)) + NumOfGivenRarity(ResumonRarity.Rare);
        player.isGrassed = false;
        RenderResumon(WildResumon[randNum], new Vector3(2.5f, 2.8f));
    }

    public void AttemptToCatch(Resumon resumon)
    {
        //Not fully implemented
        if (TryCatch(resumon))
        {
            //Play animation of catching here
            Caught(resumon);
        }
        else
        {
            //Otherwise play failed animation
        }
    }

    public void Caught(Resumon caught)
    {
        partyManager.SetPartyMemberTo(caught);
    }

    private bool TryCatch(Resumon tryCatch)
    {
        return Random.value <= tryCatch.stats.GetCaptChance();
    }

    public void RenderResumon(ResumonBase toRender, Vector3 pos)
    {
        Resumon resu = new Resumon(toRender);
        enemyObj.transform.position = pos;
        Resumon enemyResu = enemyObj.GetComponent<Resumon>();
        enemyResu.SetResuTo(resu);
        enemyResu.sprite = resu.sprite;
        enemyObj.GetComponent<SpriteRenderer>().sprite = enemyResu.sprite;
    }

    public int NumOfGivenRarity(ResumonRarity rarity)
    {
        int num = 0;
        foreach (ResumonBase resuBase in WildResumon)
        {
            if (resuBase.rarity.Equals(rarity))
                num++;
        }
        return num;
    }

    public int IndexOfRarity(ResumonRarity rarity)
    {
        int num = 0;
        for (int i = 0; i < WildResumon.Length; i++)
        {
            if (WildResumon[i].rarity.Equals(rarity))
            {
                num = i;
                i = WildResumon.Length;
            }
        }
        return num;
    }
    public IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    private void Reset()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }
}