using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * To do 
         * 1 - Make enemy move left and right 
         * 2 When an enemy Hits a wall, it turns around
         */

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
