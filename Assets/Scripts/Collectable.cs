using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //logic
    protected bool collected;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
