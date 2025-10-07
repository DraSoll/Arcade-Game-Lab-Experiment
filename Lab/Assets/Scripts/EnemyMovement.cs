using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private string WallTag = "Wall";
    public bool HitWallRight = false;
    Rigidbody2D rb;
    public float speed = 5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HitWallRight == false)
        {
             transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        
        }
        if (HitWallRight == true)
        {
             transform.Translate(Vector2.left  * speed * Time.deltaTime);
            
        }

       

        /*
         * To do 
         * 1 - Make enemy move left and right 
         * 2 When an enemy Hits a wall, it turns around
         */

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag(WallTag))
        {
            if (HitWallRight == true)
            {
            HitWallRight = false;
            Debug.Log("Hit the wall! twice");
            }
        else
            {
            HitWallRight = true;
            Debug.Log("Hit the wall! once");
            }
    
            
            

        }
    }
   



    void LateUpdate()
    {
        //NOT WORKING YET 
        //need to edit where the direction depends on the direction that the enemy is moving
        float move = 1;
        if (move > 0) spriteRenderer.flipX = false;
        if (move < 0) spriteRenderer.flipX = true;
    }

}
