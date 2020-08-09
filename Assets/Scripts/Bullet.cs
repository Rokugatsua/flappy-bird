using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    // Update is called once per frame
    public void dump(Bullet bullet)
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (rigidbody2d) {
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.AddForce(new Vector2(100,0));
        }
    }
}
