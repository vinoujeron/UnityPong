using UnityEngine;
using static GameManager;

public class BallBehaviour : MonoBehaviour
{
    public float ballSpeed = 0.75f;
    private float _ballDx = 0f;
    private float _ballDy = 0f;

    private Vector2 _startBallPosition;
    private GameObject _player1;
    private GameObject _player2;

    void Start()
    {
        _player1 = GameObject.FindWithTag("Player1");
        _player2 = GameObject.FindWithTag("Player2");
        _startBallPosition = transform.position;

    }

    void Update()
    {
        if (Input.GetKeyDown("return") || GameManager.GameState == "idle") // || statement for testing purpose, && is the final version
        {
            GameManager.GameState = "play";
            Ball_Reset();
        } 

        if (Input.GetKey("escape"))
        {
            Application.Quit();         // Don`t sure that it works, don`t know how to test, ONLY after building
        }
        
    }

    void FixedUpdate()
    {
        if (Ball_Collides(_player1))
        {
            _ballDx = -_ballDx * 1.1f;

            if (_ballDy < 0)
                _ballDy = -Random.Range(10, 150);
            else
                _ballDy = Random.Range(10, 150);
        }
        
        if (Ball_Collides(_player2))
        {
            _ballDx = -_ballDx * 1.1f;
            
            if (_ballDy < 0)
                _ballDy = -Random.Range(10, 150); // Randomise rebounce from players
            else
                _ballDy = Random.Range(10, 150);  // same
        }

        if (transform.position.y >= GAME_SCREEN_UP)
        {
            Vector3 temp = transform.position;
            temp.y = GAME_SCREEN_UP;
            transform.position = temp;
            
            _ballDy = -_ballDy;
        }
        
        if (transform.position.y <= GAME_SCREEN_DOWN + BALL_RADIUS)
        {
            Vector3 temp = transform.position;
            temp.y = GAME_SCREEN_DOWN + BALL_RADIUS;
            transform.position = temp;
            
            _ballDy = -_ballDy;
        }
        
        if (GameManager.GameState == "play")
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

    bool Ball_Collides(GameObject player)
    {
        Vector2 playerPosition = player.transform.position;        
        if (transform.position.x > playerPosition.x + PLAYER_WIDTH || transform.position.x + BALL_RADIUS < playerPosition.x)
        {
            return false;
        }

        if (transform.position.y - BALL_RADIUS > playerPosition.y || transform.position.y < playerPosition.y - PLAYER_HEIGHT)
        {
            return false;
        }
        
        return true;
    }
}
