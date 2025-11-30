using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //update weapon level
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //swing 
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D collider)
    {
        if(collider.tag == "Fighter")
        {
            if(collider.name == "Player")
                return;

            // create a new damge object
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            //send damage to the fighter
            collider.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        //play swing animation ...
        Debug.Log("Swing");
    }
}

