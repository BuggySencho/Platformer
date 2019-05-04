using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileScript : MonoBehaviour
{
    public int crocodileHealth = 200;
    public float speed = 5f;
    public float maxSpeed = 10f;
    public Animator animator;
    public Rigidbody2D rb;
    public bool MovingRight = true;
    public float Distance;
    public Transform GroundDetction;
    public int Damage = 15;

    public GameObject player;
    public playerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D GroundInfo = Physics2D.Raycast(GroundDetction.position, Vector2.down, Distance);
        if (GroundInfo.collider == false)
        {
            if (MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                MovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
        }
        if (crocodileHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetBool("attack", true);
            playerScript.playerHealth -= Damage;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetBool("attack", true);
            playerScript.playerHealth -= Damage;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetBool("attack", false);
        }
    }
}
