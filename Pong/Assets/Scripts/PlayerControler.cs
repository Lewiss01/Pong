using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] bool player1;

    public float movement;
    private Vector2 playerPosition;


    void Start()
    {

    }


    void Update()
    {
        PlayersMovement();
        PlayerBoundaries();

        transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);
    }

    public void PlayersMovement()
    {
         if (player1)
         {
            movement = Input.GetAxisRaw("Vertical");
         }
         else
         {
             movement = Input.GetAxisRaw("Vertical2");
         }
    }

    public void PlayerBoundaries()
    {
        float yBoundaries = 3.83f;  //meti a ojo el valor de los limites xd
        playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + movement * speed * Time.deltaTime, -yBoundaries, yBoundaries);
        transform.position = playerPosition;

    }
}
