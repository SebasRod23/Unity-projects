using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool doubleJump=true;
    private bool facingRight=true;
    public Animator animator;
    public UnityEvent OnLandEvent;
    public Weapon weapon;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winBanner;
    public bool isDead=false;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody=transform.GetComponent<Rigidbody2D>();
        boxCollider=transform.GetComponent<BoxCollider2D>();
        animator.SetBool("isJumping", false);
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -20) endGame();
        //if(Input.GetKeyDown(KeyCode.Space)) animator.SetBool("isJumping", true);
        if(!isGrounded()) animator.SetBool("isJumping", true);
        if(isGrounded()){
            //Debug.Log("It is grounded");
            doubleJump=true;
            OnLandEvent.Invoke();
        }
        if(isGrounded() && (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))&&!isDead){
            //Debug.Log(isGrounded() + " && (" + Input.GetKeyDown(KeyCode.Space) + " || " + Input.GetKeyDown(KeyCode.W) + ")");
            float jumpForce=42.5f;
            rigidBody.velocity=Vector2.up*jumpForce;
            animator.SetBool("isJumping", true);
    
        }
        else if(!isGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) &&doubleJump&&!isDead){
            //Debug.Log("Double jump");
            //Debug.Log(!isGrounded()+" && ("+Input.GetKeyDown(KeyCode.Space)+" || "+Input.GetKey(KeyCode.W)+") && "+doubleJump);
            float jumpForce=42.5f;
            rigidBody.velocity=Vector2.up*jumpForce;
            doubleJump=false;
            animator.SetBool("isJumping", true);
        }
        movement();
    }
    private bool isGrounded(){
        //RaycastHit2D raycasthit=Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.01f, platformsLayerMask);
        //Debug.Log("Collision:");
        //Debug.Log(raycasthit.collider);
        return (rigidBody.velocity.y==0);
    }
    private void movement(){
        float movementSpeed=17.5f;
        if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))&&!isDead){
            if(facingRight) Flip();
            rigidBody.velocity=new Vector2(-movementSpeed,rigidBody.velocity.y);
            animator.SetFloat("Speed", movementSpeed);
        }
        else if((Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))&& !isDead){
            rigidBody.velocity=new Vector2(movementSpeed,rigidBody.velocity.y);
            if(!facingRight) Flip();
            animator.SetFloat("Speed", movementSpeed);
        } else{
            rigidBody.velocity=new Vector2(0,rigidBody.velocity.y);
            animator.SetFloat("Speed", 0);
        }
    }
    private void Flip(){
        //Debug.Log("Enter");
        facingRight=!facingRight;
        transform.Rotate(0,180f,0);
        //Debug.Log(facingRight);
    }
    private void OnTriggerEnter2D(Collider2D c){
        //Debug.Log("Trigger!");
        if(c.gameObject.tag.Equals("Weapon")||c.gameObject.tag.Equals("Enemy")) {
            endGame();
            
        }
        if(c.gameObject.tag.Equals("Ammo")) {
            weapon.addBullets(10);
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag.Equals("Coin"))
        {

            isDead = true;
            weapon.isDead = true;
            winBanner.SetActive(true);
            Destroy(c.gameObject);
        }
        
    }
    public void onLanding(){
        animator.SetBool("isJumping", false);
    }

    private void endGame()
    {
        gameOverUI.SetActive(true);
        isDead=true;
        weapon.isDead=true;
    }
    
}
