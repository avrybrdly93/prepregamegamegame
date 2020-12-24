using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public LayerMask boundaryLayers;
    public float waitTime = 0.03f;
    public float timeUntilBoundary;
    Vector2 movement = new Vector2(3f,0);

    bool isFacingRight = true; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(0, -1);
        rb.velocity = movement;
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (!reachedBoundary())
        {
            //Keeps the enemy moving at a constant speed based on which way facing
            facingRightFrustration();
        }
        else
        {
            isFacingRight = !isFacingRight;
            facingRightFrustration();
        }

        Debug.Log(rb.velocity);

        
    }

    public bool reachedBoundary()
    {
        Collider2D boundaryCheck = Physics2D.OverlapCircle(rb.position, 1f, boundaryLayers);
        Debug.Log(boundaryCheck);
        return boundaryCheck != null;
    }

    public void facingRightFrustration()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}


