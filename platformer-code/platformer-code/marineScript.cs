using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marineScript : MonoBehaviour
{
    public int enemyHealth = 50;
    public float speed = 50f;
    public float maxSpeed = 10f;
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject marine;

    public bool dead = false;

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
        if (!dead)
        {

        }
        if (enemyHealth <= 0)
        {
            dead = true;
            animator.SetBool("death", dead);
        }

    }
}
