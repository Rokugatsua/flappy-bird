using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    // Global Variables
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private UnityEvent OnAddPoint;
    
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0)) {
            Jump();
        }
        
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if (!isDead && OnDead != null) {
            OnDead.Invoke();
        }

        isDead = true;
    }

    void Jump()
    {
        if (rigidbody2d) {
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.AddForce(new Vector2(0, upForce));
        }

        if (OnJump != null) {
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.enabled = false;
    }
    
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        if (OnAddPoint != null) {
            OnAddPoint.Invoke();
        }
    }
}
