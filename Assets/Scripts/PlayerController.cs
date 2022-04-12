using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class grassDetector
{
    public Vector3 pos;
    public Vector3 scale;
    public LayerMask mask;

    public grassDetector(Vector3 pos, Vector3 scale, LayerMask mask)
        : this()
    {
        this.pos = pos;
        this.scale = scale;
        this.mask = mask;
    }

    public grassDetector()
    {
        pos = Vector3.zero;
        scale = Vector3.one;
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
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public Collider2D coll;
    [HideInInspector]
    public bool isGrassed;

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

    public bool GetGrassed()
    {
        return Physics2D.OverlapBox(gCheck.pos + transform.position, gCheck.scale, 0, gCheck.mask);
    }

    private void OnDrawGizmosSelected()
    {
        if (isGrassed)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.white;
        Gizmos.DrawCube(gCheck.pos + transform.position, gCheck.scale);
    }
}
