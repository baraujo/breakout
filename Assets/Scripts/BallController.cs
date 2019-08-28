using System;
using UnityEngine;
using Random = UnityEngine.Random;

// This script will control the ball behaviour
// The ball will bounce on the sides and ceiling,
// and the player will lose if the ball hits the bottom
public class BallController : MonoBehaviour
{
    public float speed;
    
    // Option 1: separated variables
    public float topScreenLimit;
    public float bottomScreenLimit;
    public float leftScreenLimit;
    public float rightScreenLimit;

    public Vector3 initialPosition;
    
    // Option 2: struct
    /* [System.Serializable]
    public struct ScreenLimits 
    {
        public float top;
        public float bottom;
        public float left;
        public float right;
    }
    public ScreenLimits screenLimits; */

    private Vector3 m_Direction;

    void Start()
    {
        // Choose the initial ball direction
        Debug.Log("starting");
        ResetBallPosition();
    }

    private void ResetBallPosition()
    {
        int randomDirection = Random.Range(0, 2);
        
        if(randomDirection == 0)
        {
            m_Direction.x = 1;
            m_Direction.y = 1;
        }
        else
        {
            m_Direction.x = -1;
            m_Direction.y = 1;
        }
        transform.position = initialPosition;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += m_Direction * speed * Time.deltaTime;
        transform.position = newPosition;

        if(transform.position.y > topScreenLimit)
        {
            m_Direction.y *= -1;
        }

        if(transform.position.x < leftScreenLimit || transform.position.x > rightScreenLimit)
        {
            m_Direction.x *= -1;
        }

        if(transform.position.y < bottomScreenLimit)
        {
            ResetBallPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // One way of comparison is using the name
        // A more efficient way:
        // name.CompareTo("Player") == 0
        if(other.gameObject.name == "Player") 
        {
            m_Direction.y *= -1;
        }
        else if (other.gameObject.CompareTag("Brick")) {
            Destroy(other.gameObject);
            m_Direction.y *= -1;
        }
    }
}
