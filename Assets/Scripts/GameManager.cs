using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController player;
    public Resumon[] WildResumon = new Resumon[3];
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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

    /*public void PreEncounter()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
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

    public bool AttemptToCatch(Resumon tryCatch)
    {
        float rand = Random.value;
        return rand <= tryCatch.stats.GetCaptChance();
    }

    public void RenderResumon(Resumon toRender, Vector3 pos)
    {
        GameObject obj = transform.GetChild(0).gameObject;
        obj.transform.position = pos;
        obj.GetComponent<SpriteRenderer>().sprite = toRender.sprite;
    }*/

    public IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    private void Reset()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
    }
}