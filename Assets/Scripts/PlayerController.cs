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
    private bool isMoving;

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
        if (!isMoving)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (canMove && !movement.Equals(Vector2.zero))
            {
                var targetPos = transform.position;
                targetPos.x += movement.x;
                targetPos.y += movement.y;

                StartCoroutine(Move(targetPos));
            }
        }
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        CheckForEncounter();
    }

    public void CheckForEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, gCheck.mask) != null)
        {
            if (Random.Range(1, 201) <= 10)
                print("Encountered Resumon");
        }
    }
}
