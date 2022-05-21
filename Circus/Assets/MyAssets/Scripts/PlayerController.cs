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
        float vel = rb.velocity.y;
        if (Mathf.Abs(vel) <= 0.01)
        {
            if (onGround)
            {
                vel = 0;
            }
            else
            {
                vel = 1;
            }
        }
        animator.SetFloat("MovementY", vel);
    }

    void FixedUpdate()
    {
        movement = moveAction.ReadValue<Vector2>();
        ability = abilityAction.IsPressed();
        if (onGround)
        {
            if (movement.y == 1)
            {
                rb.AddForce(jumpForce * transform.up);
            }
        }
        transform.Translate(new Vector2(movement.x * runForce, 0));
    }
}
