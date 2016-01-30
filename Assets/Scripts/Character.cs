using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

class Character : MonoBehaviour
{
    public float runSpeed = 5;

    //Character state
    private bool facingRight = true;
    private Vector3 direction;

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

        body.velocity = direction * runSpeed;
    }

    public void Move(Vector3 direction)
    {
        this.direction = direction;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }
}