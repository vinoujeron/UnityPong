using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gameBehaviour;

public class ballBehaviour : MonoBehaviour
{
    private float ballX = 0f;
    private float ballY = 0f;
    private float ballDX = 0f;
    private float ballDY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameBehaviour gameBehaviour = GetComponent<gameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("enter"))
        {
            gameBehaviour.gameState = "start";
            Ball_Reset(ballDX, ballDY);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();         // Don`t sure that it dorks, don`t know how to test, ONLY after building
        }
    }

    void FixedUpdate()
    {
        Ball_Update(ballX, ballY, ballDX, ballDY);
    }

    void Ball_Reset(float ballDX, float ballDY)
    {
        ballDY = Random.Range(1, 2) == 1 ? -100 : 100; // Generate randomly -100 or 100
        ballDX = Random.Range(-50f, 50f);
    }

    void Ball_Update(float ballX, float ballY, float ballDX, float ballDY)
    {
        ballX += ballDX * Time.fixedDeltaTime;
        ballY += ballDY * Time.fixedDeltaTime;
    }
}
