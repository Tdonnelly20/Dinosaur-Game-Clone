using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _stand, _crouch;
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isJumping = false;
    public GameManager GameManager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the space button is pressed and the dinosaur isn't currently jumping the dinosaur will jump
        if (Input.GetKey("space") && _isJumping==false)
        {
            SetStanding(true);
            _isJumping = true;
            _rb.velocity = new Vector3(0, 20, 0);
        }
        if (Input.GetKey("down") && _isJumping==false)
        {
            SetStanding(false);
        }
        if (Input.GetKeyUp("down"))
        {
            SetStanding(true);
        }
    }

    public void SetStanding(bool isStanding)
    {
        _crouch.SetActive(!isStanding);
        _stand.SetActive(isStanding);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        //If the dinosaur lands on the ground, set _isJumping to false
        if (col.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
        }else
        {
            GameManager.GameOver();
            GameOver();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
            GameManager.GameOver();
        }
    }

    public void GameOver()
    {
        SetStanding(true);
        if(gameObject== _stand) _animator.SetBool("GameOver", true);
    }
    
}
