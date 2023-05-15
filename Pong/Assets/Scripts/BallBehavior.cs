using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 3f;
    [SerializeField] Transform initialPos;


    private Vector2 movementDirection;    
    public float actualSpeed;
    private bool isMoving=false;
    private Rigidbody2D rb2D;


    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartStopMovement();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ResetPosition();
        }
        
    }
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();    
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("ArcheryP1"))
        {
            bool i = true;
            UpdateMarker(i);
        }
        else
        {
            bool i = false;
            UpdateMarker(i);
        }
    }

    
    public void SetRandomDirection()
    {

        movementDirection.x = Random.Range(-1, 2) == 0 ? 1 : -1;
        movementDirection.y = Random.Range(-1, 2) == 0 ? 1 : -1;
    }
    

    public void StartStopMovement()
    {
        if (isMoving)
        {
            isMoving = false;
            actualSpeed = 0;
            rb2D.velocity = Vector2.zero;
        }
        else
        {
            isMoving = true;
            actualSpeed= normalSpeed;
            Vector2 alphaSpeed = movementDirection * actualSpeed;
            rb2D.velocity = alphaSpeed;
        }
    }
    private void Move()
    {
        if (isMoving)
        {
                 
        }   
    }

    private void ResetPosition()
    {
        actualSpeed = 0;
        isMoving= false;
        transform.position = initialPos.position;
        SetRandomDirection() ;            
    }

    public void UpdateMarker(bool playerSelecct)
    {
        if (playerSelecct) 
        {
            GameController.Connector.p2Scored();         
        }
        else
        {
            GameController.Connector.p1Scored();         
        }
        StartStopMovement();
        SetRandomDirection(); 

    }




}
