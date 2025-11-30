using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //collision detection
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) 
                continue;

            OnCollide(hits[i]);

            //the array is reused, so we need to clear the hit
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log("OnCollid was not implemented in " + this.name);
    }
}

