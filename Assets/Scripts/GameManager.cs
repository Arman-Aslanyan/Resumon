using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerController player;

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
        if (player.isGrassed)
        {
            Encounter();
        }
    }

    public void Encounter()
    {
        print("Creeper! AAWWWWW MMAAAANNNN!!!");
    }
}
