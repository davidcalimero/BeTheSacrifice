using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

class Actuator : MonoBehaviour
{
    public float runSpeed = 5;
    public float fallTime = 5;

    private bool facingRight = true;
    private Rigidbody body;
    private Animator animator;
    public GameObject arm;

    private bool isOnFallState = false;
    public bool IsOnFallState { get { return isOnFallState; } }

    private Vector3 direction;
    public Vector3 Direction
    {
        get
        {
            if (direction.magnitude == 0)
                return transform.right;
            return direction.normalized;
        }
    }
    
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isOnFallState)
            direction = Vector3.zero;
        //Update animations
        animator.SetFloat("Speed", direction.magnitude);

        if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight))
        {
            Flip();
        }

        body.velocity = direction * runSpeed;
    }

    public void Move(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Push(Vector3 theForce)
    {
        animator.SetBool("fall", true);
        isOnFallState = true;
        arm.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Utils.ExecuteAfterTime(Getup, fallTime));
        body.AddForce(theForce, ForceMode.Impulse);
    }

    private void Getup()
    {
        animator.SetBool("fall", false);
        arm.GetComponent<SpriteRenderer>().enabled = true;
        isOnFallState = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }
}