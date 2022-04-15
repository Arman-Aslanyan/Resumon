using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameManager INSTANCE;
    PlayerController player;
    public Resumon[] resumon = new Resumon[3];
    public GameObject prefab;
    float time = 1;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        INSTANCE = this;
    }

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


    }

    //Called once per physics frame
    private void FixedUpdate()
    {
        if (player.isGrassed && time >= 2.5f)
        {
            time = 0;
            Encounter();
        }
        else if (time < 100)
            time += Time.fixedDeltaTime;
    }

    public void Encounter()
    {
        SceneManager.LoadScene("Combat");
        float rand = Random.value;
        int randNum;
        if (rand <= 0.65f) randNum = 0;
        else if (rand <= 0.85f) randNum = 1;
        else randNum = 2;
        player.isGrassed = false;
        RenderResumon(resumon[randNum], Vector3.zero);
        print(resumon[randNum] + " | " + randNum);
    }

    public void RenderResumon(Resumon toRender, Vector3 pos)
    {
        GameObject obj = transform.GetChild(0).gameObject;
        obj.transform.position = pos;
        obj.GetComponent<SpriteRenderer>().sprite = toRender.sprite;
    }
}