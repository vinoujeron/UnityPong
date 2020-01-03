using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class BallBehaviour : MonoBehaviour
{
    public float ballSpeed = 0.75f;
    private float _ballDx = 0f;
    private float _ballDy = 0f;

    private Vector2 _startBallPosition;
    private GameObject _player1;
    private GameObject _player2;

    public Text player1ScoreText;
    public Text player2ScoreText;

    private bool _player1Scored = false;
    void Start()
    {
        _player1 = GameObject.FindWithTag("Player1");
        _player2 = GameObject.FindWithTag("Player2");
        _startBallPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.GameState == "idle" && Input.GetKeyDown("return")) 
        {
            GameManager.GameState = "play";
            GameManager.mainText.text = null;
            Ball_Reset();
        }

        if (GameManager.GameState == "Victory" && Input.GetKeyDown("return"))
        {
            GameManager.player1Score = 0;
            GameManager.player2Score = 0;

            GameManager.mainText.text = "Press \"Enter\" to start a new game!";
            GameManager.GameState = "idle";
        }

        if (GameManager.GameState == "Scored" && GameManager.player1Score < 7 && GameManager.player2Score < 7)
        {
            GameManager.GameState = "idle";
            GameManager.mainText.text = _player1Scored ? "Player 1 scored! \n Press \"Enter\" to continue" : "Player 2 scored! \n Press \"Enter\" to continue";
            AudioManager.instance.Play("WinAGoal");
        }
        
        if (GameManager.GameState == "Victory")
        {
            
            GameManager.mainText.text = GameManager.player1Score > GameManager.player2Score ?
                "Player 1 has won! \n Press \"Enter\" to continue!" : "Player  2 has won! \n Press \"Enter\" to continue!";
        }

        if (GameManager.GameState == "Victory" && Input.GetKeyDown("return"))
        {
            GameManager.player1Score = 0;
            GameManager.player2Score = 0;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();         
        }
        
        CheckForGoal();
    }

    void FixedUpdate()
    {
        if (Ball_Collides(_player1))
        {
            _ballDx = -_ballDx * 1.1f;
            // Move ball from collied player for not to stuck in player
            transform.position += new Vector3(3f, 0, 0);

            if (_ballDy < 0)
                _ballDy = -Random.Range(10, 150);
            else
                _ballDy = Random.Range(10, 150);
        }
        
        if (Ball_Collides(_player2))
        {
            _ballDx = -_ballDx * 1.1f;
            // Move ball from collied player for not to stuck in player
            transform.position += new Vector3(-3f, 0, 0);
            
            if (_ballDy < 0)
                _ballDy = -Random.Range(10, 150); // Randomise rebounce from players
            else
                _ballDy = Random.Range(10, 150);  // same
        }

        if (transform.position.y >= GameManager.GAME_SCREEN_UP)
        {
            Vector3 temp = transform.position;
            temp.y = GameManager.GAME_SCREEN_UP;
            transform.position = temp;
            
            _ballDy = -_ballDy;
            AudioManager.instance.Play("BorderHit");
        }
        
        if (transform.position.y <= GameManager.GAME_SCREEN_DOWN + GameManager.BALL_RADIUS)
        {
            Vector3 temp = transform.position;
            temp.y = GameManager.GAME_SCREEN_DOWN + GameManager.BALL_RADIUS;
            transform.position = temp;
            
            _ballDy = -_ballDy;
            AudioManager.instance.Play("BorderHit");
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
        player1ScoreText.text = GameManager.player1Score.ToString();
        player2ScoreText.text = GameManager.player2Score.ToString();
        
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
        if (transform.position.x > playerPosition.x + GameManager.PLAYER_WIDTH || transform.position.x + GameManager.BALL_RADIUS < playerPosition.x)
        {
            return false;
        }

        if (transform.position.y - GameManager.BALL_RADIUS > playerPosition.y || transform.position.y < playerPosition.y - GameManager.PLAYER_HEIGHT)
        {
            return false;
        }
        
        AudioManager.instance.Play("PlayerHit");
        return true;
    }

    void CheckForGoal()
    {
        if (GameManager.player1Score < 7 && GameManager.player2Score < 7)
        {
            if (transform.position.x >= GameManager.GAME_SCREEN_RIGHT)
            {
                GameManager.player1Score++;
                player1ScoreText.text = GameManager.player1Score.ToString();
                
                // Move ball from border for not to trigger winning instruction 
                transform.position += new Vector3(-7f, 0, 0);
                
                _player1Scored = true;
                GameManager.GameState = "Scored";
            }

            if (transform.position.x <= GameManager.GAME_SCREEN_LEFT)
            {
                GameManager.player2Score++;
                player2ScoreText.text = GameManager.player2Score.ToString();
                
                // Move ball from border for not to trigger winning instruction 
                transform.position += new Vector3(3f, 0, 0);

                _player1Scored = false;
                GameManager.GameState = "Scored";
            }
        }
        else if(GameManager.GameState != "Victory")
        {
            AudioManager.instance.Play("WinAGame");
            GameManager.GameState = "Victory";
        }
    }
}
