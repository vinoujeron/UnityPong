using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameBehaviour;

public class BallBehaviour : MonoBehaviour
{
    public float ballSpeed = 0.15f;
    private float _ballDx = 0f;
    private float _ballDy = 0f;

    private Vector2 _startBallPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameBehaviour gameBehaviour = GetComponent<GameBehaviour>();
        _startBallPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return") && GameBehaviour.GameState == "idle")
        {
            GameBehaviour.GameState = "play";
            Ball_Reset();
        } 

        if (Input.GetKey("escape"))
        {
            Application.Quit();         // Don`t sure that it works, don`t know how to test, ONLY after building
        }
        
    }

    void FixedUpdate()
    {
        if (GameBehaviour.GameState == "play")
        {
            Ball_Update();
        }
    }

    void Ball_Reset()
    {
        transform.position = _startBallPosition;
        _ballDx = Random.Range(1, 3) == 1 ? -100 : 100; // Generate randomly -100 or 100; Range from 1 to 3 generates 1 or 2 Why is it that way IDK 
        _ballDy = Random.Range(-50f, 50f);
    }

    void Ball_Update()
    {
        Vector2 newBallPosition = transform.position;
        
        newBallPosition.x += (_ballDx * Time.fixedDeltaTime) * ballSpeed;
        newBallPosition.y += (_ballDy * Time.fixedDeltaTime) * ballSpeed;

        transform.position = newBallPosition;
    }
}
