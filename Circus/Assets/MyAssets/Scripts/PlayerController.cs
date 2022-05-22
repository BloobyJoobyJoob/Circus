using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Animator animator;
    public RuntimeAnimatorController elephantController;
    public RuntimeAnimatorController angryElephantController;
    public RuntimeAnimatorController lionController;
    public Rigidbody2D rb;
    public GameObject[] bustables;
    public ParticleSystem ps;

    public Transform ground;
    public Transform angry;

    public float jumpForce;
    public float runForce;

    private float yVel;
    private bool onGround;

    private InputAction moveAction;
    private InputAction morphAction;
    private InputAction abilityAction;
    private Vector2 movement = new Vector2(0, 0);
    private bool ability = false;
    private bool morphing = false;

    private int morph = 0;
    // 0 = Lion
    // 1 = Elephant

    void Awake()
    {
        moveAction = playerInput.actions["Movement"];
        abilityAction = playerInput.actions["Ability"];
        morphAction = playerInput.actions["Morph"];

        animator.runtimeAnimatorController = lionController;
    }
    private void Update()
    {
        morphing = morphAction.WasPressedThisFrame();

        animator.SetFloat("MovementX", movement.x);

        if (morph == 0)
        {
            if (movement == Vector2.zero)
            {
                animator.SetBool("Roar", ability);
            }
            else
            {
                animator.SetBool("Roar", false);
            }
        }
        else
        {
            if (movement.x != 0 && movement.y == 0)
            {
                if (ability)
                {
                    animator.runtimeAnimatorController = angryElephantController;
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(angry.position, 0);
                    foreach (Collider2D col in colliders)
                    {
                       GameObject bust = Array.Find(bustables, b => b = col.gameObject);
                       bust.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    }

                }
                else
                {
                    animator.runtimeAnimatorController = elephantController;
                }
            }
            else
            {
                animator.runtimeAnimatorController = elephantController;
            }
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(ground.position, 0f);
        onGround = false;
        foreach (Collider2D col in cols)
        {
            if (!col.isTrigger)
            {
                onGround = true;
            }
        }
        yVel = rb.velocity.y;
        if (Mathf.Abs(yVel) <= 0.01)
        {
            if (onGround)
            {
                yVel = 0;
            }
            else
            {
                yVel = 1;
            }
        }
        animator.SetFloat("MovementY", yVel);

        if (morphing)
        {
            if (morph == 0)
            {
                morph = 1;
                animator.runtimeAnimatorController = elephantController;
                AudioManager.instance.PlaySound("Morph", true, true);
                ps.Play();
            }
            else
            {
                morph = 0;
                animator.runtimeAnimatorController = lionController;
            }
            morphing = false;
        }
    }

    void FixedUpdate()
    {
        if (onGround)
        {
            ability = abilityAction.IsPressed();
            movement = moveAction.ReadValue<Vector2>();
            if (movement.y >= 0.5 && movement.x != 0)
            {
                rb.AddForce(jumpForce * transform.up);
            }
        }
        transform.Translate(new Vector2(movement.x * runForce, 0));
    }
}
