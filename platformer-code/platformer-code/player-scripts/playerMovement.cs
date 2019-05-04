using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int playerHealth = 1000;
    public float attackRangeMarine;
    public float attackRangeSmoker;
    public float attackRangeCrocodile;
    public float attackRangeBuggy;
    public GameObject marine;
    public marineScript marineBehaviourScript;
    public GameObject smoker;
    public smokerScript smokerBehaviorScript;
    public GameObject crocodile;
    public CrocodileScript crocodileBehaviourScript;
    public GameObject buggy;
    public BuggyScript buggyBehaviourScript;
    public GameObject wave;
    public GameObject hpText;
    public GameObject Health;
    public float timer = 0;

    public GameObject ScoreText;
    public int[] Score = new int[] {100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

    bool isJumping;
    bool isAttacking;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        marineBehaviourScript = marine.GetComponent<marineScript>();
        crocodileBehaviourScript = crocodile.GetComponent<CrocodileScript>();
        buggyBehaviourScript = buggy.GetComponent<BuggyScript>();
    }

    // Update is called once per frame
    void Update()
    {


       timer += Time.deltaTime;

       for (int score = 0; score < Score.Length; score++)
        {
            if (timer >= 10)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[0];
            }
            if (timer >= 20)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[1];
            }
            if (timer >= 30)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[2];
            }
            if (timer >= 40)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[3];
            }
            if (timer >= 50)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[4];
            }
            if (timer >= 60)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[5];
            }
            if (timer >= 80)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[6];
            }
            if (timer >= 90)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[7];
            }
            if (timer >= 100)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[8];
            }
            if (timer >= 110)
            {
                ScoreText.GetComponent<Text>().text = "Score: " + Score[9];
            }

        } 

        hpText.GetComponent<Text>().text = playerHealth + " HP";

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("level1");
        }
       // flips player
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
        //checks range between player and enemy
        attackRangeMarine = (marine.transform.position - transform.position).magnitude;
        attackRangeSmoker = (smoker.transform.position - transform.position).magnitude;
        attackRangeCrocodile = (crocodile.transform.position - transform.position).magnitude;
        attackRangeBuggy = (buggy.transform.position - transform.position).magnitude;

        // first attack
        if (Input.GetKeyDown(KeyCode.H) && !isAttacking && attackRangeMarine <= 3)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDamage1;
            animator.SetTrigger("attack");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && !isAttacking && attackRangeSmoker <= 3)
        {
            isAttacking = true;
            smokerBehaviorScript.smokerHealth -= attackDamage1;
            animator.SetTrigger("attack");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && !isAttacking && attackRangeCrocodile <= 3)
        {
            isAttacking = true;
            crocodileBehaviourScript.crocodileHealth -= attackDamage1;
            animator.SetTrigger("attack");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && !isAttacking && attackRangeBuggy <= 3)
        {
            isAttacking = true;
            buggyBehaviourScript.buggyHealth -= attackDamage1;
            animator.SetTrigger("attack");
            isAttacking = false;
        }

        // second attack
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking && attackRangeMarine <= 4)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDammage2;
            animator.SetTrigger("attack2");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.J) && !isAttacking && attackRangeSmoker <= 4)
        {
            isAttacking = true;
            smokerBehaviorScript.smokerHealth -= attackDammage2;
            animator.SetTrigger("attack2");
            isAttacking = false;
        }

       if (Input.GetKeyDown(KeyCode.J) && !isAttacking && attackRangeCrocodile <= 4)
        {
            isAttacking = true;
            crocodileBehaviourScript.crocodileHealth -= attackDammage2;
            animator.SetTrigger("attack2");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.J) && !isAttacking && attackRangeBuggy <= 4)
        {
            isAttacking = true;
            buggyBehaviourScript.buggyHealth -= attackDammage2;
            animator.SetTrigger("attack2");
            isAttacking = false;
        }


        // third attack
        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && attackRangeMarine <= 6)
        {
            isAttacking = true;
            marineBehaviourScript.enemyHealth -= attackDamage3;
            animator.SetTrigger("attack3");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && attackRangeSmoker <= 6)
        {
            isAttacking = true;
            smokerBehaviorScript.smokerHealth -= attackDamage3;
            animator.SetTrigger("attack3");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && attackRangeCrocodile <= 6)
        {
            isAttacking = true;
            crocodileBehaviourScript.crocodileHealth -= attackDamage3;
            animator.SetTrigger("attack3");
            isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !isAttacking && attackRangeBuggy <= 6)
        {
            isAttacking = true;
            buggyBehaviourScript.buggyHealth -= attackDamage3;
            animator.SetTrigger("attack3");
            isAttacking = false;
        }
    }

    // lets you jump
    void jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            isJumping = true;

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    // movement
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
        // also makes you jump
        jump();
    }

    // checks ground
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "healing")
        {
            playerHealth = 1000;
            Health.SetActive(false);
        }
    }
}