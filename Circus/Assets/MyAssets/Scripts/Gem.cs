using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    public ParticleSystem ps;
    public SpriteRenderer sr;
    public Collider2D col;
    public GameObject text;
    public void Eat()
    {
        AudioManager.instance.PlaySound("bite");
        ps.Play();
        Destroy(sr);
        Destroy(col);

        Animator anm = text.GetComponent<Animator>();
        anm.enabled = true;
    }
}
