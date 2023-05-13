using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 3f;
    private Vector2 movementDirection;
    public float actualSpeed;

    private float positionStartX;
    private float positionStartY;

    private Rigidbody2D rb2D;
    private void Start()
    {
        actualSpeed = normalSpeed;
        rb2D = GetComponent<Rigidbody2D>();
        RandomStart();
    }

    public void RandomStart()
    {
        positionStartX = Random.Range(-1, 2); //== 0 ? 1 : -1;
        positionStartY = Random.Range(-1, 2);// == 0 ? 1 : -1;
        rb2D.velocity = new Vector2(positionStartX, positionStartY)* normalSpeed;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ArcheryP1"))
        {
            GameController.Connector.p2Scored();
            GameController.Connector.ReStart();
            RandomStart();
        }
        else
        {
            GameController.Connector.p1Scored();
            GameController.Connector.ReStart();
            RandomStart();
        }
    }


}
