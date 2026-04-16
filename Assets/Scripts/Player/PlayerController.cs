using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;   

public class PlayerController : Singleton<PlayerController>
{
public bool FacingLeft {get {return FacingLeft; }}

[SerializeField] private float speed = 1f;
[SerializeField] private float moveSpeed  = 1f;
[SerializeField] private Transform weaponCollider;

private PlayerControls playerControls;
private Vector2 movement;
private Rigidbody2D rb; 
private KnockBack knockBack;

private Animator myAnimator;

private SpriteRenderer mySpriteRenderer;
private float startingMoveSpeed;

private bool facingLeft = false;

    protected override void Awake(){
        base.Awake();
        //Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();

    }  
    private void Start()
    {
        startingMoveSpeed = moveSpeed;
        ActiveInventory.Instance.EquipStartingWeapon();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }
    private void OnDisable() {
        playerControls.Disable();
    }
    
    public Transform GetWeaponCollider() {
        return weaponCollider;
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y); 
    }

    private void Move()
    {
        /*
        if(knockBack.GettingKnockedBack) {return;}    
        
        Vector2 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
        */
        if (knockBack.GettingKnockedBack || PlayerHealth.Instance.isDead) { return; }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePosition.x < playerScreenPosition.x)
        {
            mySpriteRenderer.flipX = true;
            facingLeft = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
            facingLeft = false;
        }


    }
}
