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
    [HideInInspector] public Resumon enemyResu;

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
        player = FindObjectOfType<PlayerController>();
        enemyObj = transform.GetChild(0).gameObject;
        enemyResu = enemyObj.GetComponent<Resumon>();
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
        if (rand <= 0.65f) randNum = 0;
        else if (rand <= 0.9f) randNum = 1;
        else randNum = 2;
        player.isGrassed = false;
        RenderResumon(WildResumon[randNum], new Vector3(2.5f, 2.8f));
        print(WildResumon[randNum] + " | " + randNum);
    }

    public void Caught(Resumon caught)
    {

    }

    public void AttemptToCatch(Resumon resumon)
    {
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
    
    public bool TryCatch(Resumon tryCatch)
    {
        return Random.value <= tryCatch.stats.GetCaptChance();
    }

    public void RenderResumon(ResumonBase toRender, Vector3 pos)
    {
        GameObject obj = transform.GetChild(0).gameObject;
        obj.transform.position = pos;
        obj.GetComponent<SpriteRenderer>().sprite = toRender.sprite;
        string resuName = toRender.name;
        foreach (ResumonBase wildResu in WildResumon)
        {
            if (wildResu.name.Equals(resuName))
            {
                enemyResu = new Resumon(wildResu);
            }
        }
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