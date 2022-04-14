using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController player;
    public Resumon[] resumon = new Resumon[3];
    float time;

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
            Encounter();
            time = 0;
        }
        else
            time += Time.fixedDeltaTime;
    }

    public void Encounter()
    {
        SceneManager.LoadScene("Combat");
        int randResuNum = Random.Range(0, resumon.Length);
        SpriteRenderer spr = GetComponentInChildren<SpriteRenderer>();
        spr.sprite = resumon[randResuNum].sprite;
        print(resumon[randResuNum]);
    }
}
