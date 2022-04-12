using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerController player;
    public GameObject[] array = new GameObject[3];
    float time;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        foreach (GameObject resu in array)
            resu.AddComponent<Resumon>();
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
        
    }
}
