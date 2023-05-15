using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Build.Content;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text textScoreP1;
    private int scoreP1;
    
    [SerializeField] private TMP_Text textScoreP2;
    private int scoreP2;

    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private Transform ballTransform;



    // al usar un silgletone para facilitar
    // la comunicacion con los otros cripts del juego


    private static GameController connector;

    public static GameController Connector
    {
        get
        {
            if (connector == null)
            {
                connector = FindObjectOfType<GameController>();
            }
            return connector;
        }      
    }

   
    public void p1Scored()
    {
        scoreP1++;
        textScoreP1.text = scoreP1.ToString();
        ReStart();
    }
    public void p2Scored()
    {
        scoreP2++;
        textScoreP2.text = scoreP2.ToString();
        ReStart();
    }

    public void ReStart()
    {
        player1Transform.position = new Vector2(player1Transform.position.x, 0);
        player2Transform.position = new Vector2(player2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    } 

}

