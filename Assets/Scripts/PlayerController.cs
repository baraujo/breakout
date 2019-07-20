using UnityEngine;

// This script will read player actions and update the paddle state
// The player can move the paddle left and right, inside the screen limits
public class PlayerController : MonoBehaviour
{
    // Movement speed, in units/second
    public float speed;
    // How far the player can move to the left
    public float leftScreenLimit;
    // How far the player can move to the right
    public float rightScreenLimit;

    void Update()
    {
        // Verify if the left arrow is being pressed
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // Store current position
            Vector3 newPosition = transform.position;
            
            // Update X position
            newPosition.x -= speed * Time.deltaTime;
            
            // Verify if the new position is beyond the limit
            // If that's the case, limit it
            if(newPosition.x < leftScreenLimit)
            {
                newPosition.x = leftScreenLimit;
            }
            
            // Update the transform position
            transform.position = newPosition;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            // Store current position
            Vector3 newPosition = transform.position;
            
            // Update X position
            newPosition.x += speed * Time.deltaTime;

            // Verify if the new position is beyond the limit
            // If that's the case, limit it
            if(newPosition.x > rightScreenLimit)
            {
                newPosition.x = rightScreenLimit;
            }
            
            // Update the transform position
            transform.position = newPosition;
        }
    }
}
