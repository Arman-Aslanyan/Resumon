using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        pos = Vector3.one;
        scale = Vector3.one;
        mask = 4160;
    }
}

public class PlayerController : MonoBehaviour
{
    public grassDetector gCheck = new grassDetector();
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    Vector2 movement;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
