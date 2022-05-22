using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MinVel = 0.1f;

    private AudioSource aus;
    void Start()
    {
        aus = AudioManager.instance.PlaySound("Scrape", false, false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            if (rb.velocity.magnitude >= MinVel)
            {
                if (!aus.isPlaying)
                {
                    aus.Play();
                }
            }
            else
            {
                aus.Stop();
            }
        }
        else
        {
            aus.Stop();
        }
    }
}
