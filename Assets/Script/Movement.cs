﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 8f;


    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        Left();
        Right();

    }

    void Jump () {
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }

    }

    void Left () {
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0){
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
    }

    void Right () {
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0){
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
    }


}
