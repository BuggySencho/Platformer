using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed = 50f;
    public float maxSpeed = 10f;
    public Animator animator;
    public string tag;
    public int attackDamage1 = 50;
    public int attackDammage2 = 60;
    public int attackDamage3 = 75;
    public int playerHealth = 100;
    public float attackRange;
    public GameObject marine;
    public marineScript marineBehaviourScript;

    bool isJumping;
    bool isAttacking;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        marineBehaviourScript = marine.GetComponent<marineScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        Vector3 playerScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-7f, 7f, 1f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(7f, 7f, 1f);
        }
        attackRange = (marine.transform.position - transform.position).magnitude;

        if (Input.GetKeyDown(KeyCode.H) && !isAttacking && attackRange < 3)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDamage1;
            animator.SetTrigger("attack");
            isAttacking = false;
        }

        if(Input.GetKeyDown(KeyCode.J) && !isAttacking && attackRange < 4)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDammage2;
            animator.SetTrigger("attack2");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && attackRange < 6)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDamage3;
            animator.SetTrigger("attack3");
            isAttacking = false;
        }
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            isJumping = true;

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb.AddForce((Vector2.right * speed) * h);

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        jump();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        tag = other.gameObject.tag;
       // rb.velocity = Vector2.zero;
        if(other.gameObject.tag == "Ground")
        {
            animator.SetBool("ground", !isJumping);
            isJumping = false;
        }
        else
        {
            animator.SetBool("ground" , isJumping);
        }
    }
}