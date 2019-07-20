using System;
using UnityEngine;
using Random = UnityEngine.Random;

// This script will control the ball behaviour
// The ball will bounce on the sides and ceiling,
// and the player will lose if the ball hits the bottom
public class BallController : MonoBehaviour
{
    public float speed;
    public float topScreenLimit;
    public float leftScreenLimit;
    public float rightScreenLimit;
    public float bottomScreenLimit;

    private Vector3 m_Direction;

    void Start()
    {
        // Choose the initial ball direction
        ChooseBallDirection();
    }

    private void ChooseBallDirection()
    {
        // There are four possible directions for the ball to fly,
        // which are the four diagonals
        
        // Let's choose one using a random number
        int randomDirection = Random.Range(0, 4);
        
        // This switch block will initialize m_Direction with
        // a direction according to the randomDirection passed
        // as parameter
        switch(randomDirection)
        {
            case 0:
                m_Direction.x = 1;
                m_Direction.y = 1;
                break;
            case 1:
                m_Direction.x = 1;
                m_Direction.y = -1;
                break;
            case 2:
                m_Direction.x = -1;
                m_Direction.y = -1;
                break;
            case 3:
                m_Direction.x = -1;
                m_Direction.y = 1;
                break;
        }
        transform.position = Vector3.zero;
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
            ChooseBallDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Player") 
        {
            m_Direction.y *= -1;
        }
    }
}
