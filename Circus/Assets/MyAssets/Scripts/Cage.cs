using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D[] colliders;
    public SpriteRenderer sr;

    public string secondarySortingLayerName = "default";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider);
        }
        sr.sortingLayerName = secondarySortingLayerName;
    }
}
