using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVals : MonoBehaviour
{
    public GameObject obj;
    public PlayerController comp;
    public Transform trans;
    public Rigidbody2D rb;
    public Collider2D coll;

    public PlayerVals()
    {
        comp = FindObjectOfType<PlayerController>();
        print(comp.gameObject.name);
        obj = comp.gameObject;
        trans = obj.transform;
        rb = obj.GetComponent<Rigidbody2D>();
        coll = obj.GetComponent<Collider2D>();
    }
}

public class GameManager : MonoBehaviour
{
    private PlayerVals player = new PlayerVals();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called once per physics frame
    private void FixedUpdate()
    {
        if (player.comp.GetGrassed())
        {
            Encounter();
        }
    }

    public void Encounter()
    {
        print("Creeper! AAWWWWW MMAAAANNNN!!!");
    }
}
