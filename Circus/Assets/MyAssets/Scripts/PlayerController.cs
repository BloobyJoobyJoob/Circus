using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Animator animator;
    public Rigidbody2D rb;

    public Transform ground;

    public float jumpForce;
    public float runForce;

    private float yVel;
    private bool onGround;

    private InputAction moveAction;
    private InputAction abilityAction;
    private Vector2 movement = new Vector2(0, 0);
    private bool ability = false;

    private int morph = 0;
    // 0 = Lion
    // 0 = Bat
    // 0 = Elephant

    void Awake()
    {
        moveAction = playerInput.actions["Movement"];
        abilityAction = playerInput.actions["Ability"];
    }
    private void Update()
    {
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

        onGround = Physics2D.OverlapCircle(ground.position, 0f);
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
