using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDoor : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic && collision.collider.gameObject.name == "Player")
        {
            AudioManager.instance.PlaySound("Crash", true, true);
            rb.gravityScale = 1;
            rb.mass = 0.1f;
            Invoke("RemoveCollider", 1f);
        }
    }
    private void RemoveCollider()
    {
        gameObject.layer = 7;
    }
}
