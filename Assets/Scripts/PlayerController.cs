using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class grassDetector
{
    public LayerMask mask;

    public grassDetector(LayerMask mask)
        : this()
    {
        this.mask = mask;
    }

    public grassDetector()
    {
        mask = 4160;
    }
}

public class PlayerVals : MonoBehaviour
{
    public GameObject obj;
    public PlayerController comp;
    public Transform trans;
    public Rigidbody2D rb;
    public Collider2D coll;

    public PlayerVals()
    {
        obj = comp.gameObject;
        trans = obj.transform;
        rb = obj.GetComponent<Rigidbody2D>();
        coll = obj.GetComponent<Collider2D>();
    }
}

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D coll;
    [HideInInspector] public bool isGrassed;

    public grassDetector gCheck = new grassDetector();
    public float moveSpeed = 5f;
    private Animator animator;
    Vector2 movement;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        //animator = GetComponent<Animator>();
    }

    // Update called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grass"))
        {
            isGrassed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrassed = false;
    }
}
