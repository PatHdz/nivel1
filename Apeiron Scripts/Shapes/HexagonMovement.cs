using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float moveSpeed;
    private bool isFacingRight;
    private Camera screen;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake(){
        horizontal = 0f;
        vertical = 0f;
        moveSpeed = 10f;
        isFacingRight = true;
        screen = Camera.main;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(gameObject.tag == "Player"){
            horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
            vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

            Flip();
        }
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal, vertical);

        if(Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0){
            if(gameObject.tag == "Player"){
                animator.SetBool("isRunning", true);
            }
        } else {    
            animator.SetBool("isRunning", false);
        }

        PreventPlayerGoingOffscreen();
    }

    private void Flip(){
        if(isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void PreventPlayerGoingOffscreen(){
        Vector2 screenPosition = screen.WorldToScreenPoint(transform.position);

        if((screenPosition.x < 0 && rb.velocity.x < 0) || (screenPosition.x > screen.pixelWidth && rb.velocity.x > 0)){
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if((screenPosition.y < 0 && rb.velocity.y < 0) || (screenPosition.y > screen.pixelHeight && rb.velocity.y > 0)){
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(gameObject.tag == "Player"){
            if(collision.gameObject.tag != "Hexagon"){
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            } else if(collision.gameObject.tag == "Hexagon"){
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
