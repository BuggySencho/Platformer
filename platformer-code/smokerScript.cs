using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokerScript : MonoBehaviour
{
    public int smokerHealth = 200;
    public float speed = 5f;
    public float maxSpeed = 10f;
    public Animator animator;
    public Rigidbody2D rb;
    public GameObject player;
    public playerMovement playerscript;
    public bool dead = false;
    public bool attack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerscript = player.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (smokerHealth <= 0)
        {
            dead = true;
            animator.SetBool("death", dead);
        }

    }
}
