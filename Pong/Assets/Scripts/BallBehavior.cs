using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] float ballSpeed = 7f;
    private float positionStartX;
    private float positionStartY;

    private Rigidbody2D rb2D;
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
        RandomStart();
    }

    private void RandomStart()
    {
        positionStartX = Random.Range(0, 2) == 0 ? 1 : -1;
        positionStartY = Random.Range(0, 2) == 0 ? 1 : -1;
        rb2D.velocity = new Vector2(positionStartX, positionStartY)* ballSpeed;


    }


}
