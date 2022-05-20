using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float runForce;
    public PlayerInput playerInput;
    public Animator animator;

    private InputAction moveAction;
    private Vector2 movement = new Vector2(0, 0);

    void Awake()
    {
        moveAction = playerInput.actions["Movement"];
    }
    private void Update()
    {
        animator.SetFloat("MovementX", movement.x);
    }

    void FixedUpdate()
    {
        movement = moveAction.ReadValue<Vector2>();

        transform.Translate(new Vector2(movement.x * runForce, 0));
    }
}
