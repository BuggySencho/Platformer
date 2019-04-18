using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarMovement : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float DirX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + DirX, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            Application.LoadLevel("level1");
    }
}
