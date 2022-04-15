using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController player;
    public Resumon[] resumon = new Resumon[3];
    public GameObject prefab;
    float time = 2.5f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Called once per physics frame
    private void FixedUpdate()
    {
        player.isGrassed = player.GetGrassed();
        if (player.isGrassed && time >= 2.5f)
        {
            time = 0;
            Encounter();
        }
        else
            time += Time.fixedDeltaTime;
    }

    public void Encounter()
    {
        SceneManager.LoadScene("Combat");
        int randResuNum;
        float rand = Random.value;
        if (rand < 0.4)
            randResuNum = 0;
        else if (rand <= 7)
            randResuNum = 1;
        else randResuNum = 2;
        RenderResumon(resumon[randResuNum], Vector3.zero);
        print(resumon[randResuNum] + " | " + randResuNum);
    }

    public void RenderResumon(Resumon toRender, Vector3 pos)
    {
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().sprite = toRender.sprite;
    }
}