using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

class Character : MonoBehaviour
{
    public float runSpeed = 5;

    //Character state
    private bool facingRight = true;
    private Vector2 direction;

    private Rigidbody body;
    private Animator animator;
    
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Update animations
        animator.SetFloat("Speed", direction.magnitude);

        if ((body.velocity.x > 0 && !facingRight) || (body.velocity.x < 0 && facingRight))
        {
            Flip();
        }

        body.velocity = new Vector3(direction.x, 0, direction.y) * runSpeed;
    }

    public void Move(Vector2 direction)
    {
        this.direction = direction;
    }

    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}