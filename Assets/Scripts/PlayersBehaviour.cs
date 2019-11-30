using UnityEngine;
using static GameManager;

public class PlayersBehaviour : MonoBehaviour
{
    private float _player1Dy;
    private float _player2Dy;

    private float _playerSpeed = 15f;
    
    

    private GameObject _player1;
    private GameObject _player2;
    
    // Start is called before the first frame update
    void Start()
    {
        _player1 = GameObject.FindWithTag("Player1");
        _player2 = GameObject.FindWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            _player1Dy = _playerSpeed;
        }
        else if (Input.GetKey("s"))
        {
            _player1Dy = -_playerSpeed;
        }
        else
            _player1Dy = 0;
        
        if (Input.GetKey("up"))
        {
            _player2Dy = _playerSpeed;
        }
        else if (Input.GetKey("down"))
        {
            _player2Dy = -_playerSpeed;
        }
        else
            _player2Dy = 0;
    }

    void FixedUpdate()
    {
        Player1_Update();
        Player2_Update();
    }

    private void Player1_Update() // +- 1F is for a little border of the screen
    {
        Vector2 newPosition = _player1.transform.position;
        if(_player1.transform.position.y <= GAME_SCREEN_DOWN + PLAYER_HEIGHT + 1f) 
            newPosition.y = Mathf.Max(GAME_SCREEN_DOWN + PLAYER_HEIGHT + 1f, newPosition.y + _player1Dy * Time.fixedDeltaTime * _playerSpeed);
        else 
            newPosition.y = Mathf.Min(GAME_SCREEN_UP - 1f, newPosition.y + _player1Dy * Time.fixedDeltaTime * _playerSpeed);

        _player1.transform.position = newPosition;
    }
    
    private void Player2_Update()
    {
        Vector2 newPosition = _player2.transform.position;
        if(_player2.transform.position.y <= GAME_SCREEN_DOWN + PLAYER_HEIGHT + 1f) 
            newPosition.y = Mathf.Max(GAME_SCREEN_DOWN + PLAYER_HEIGHT + 1f, newPosition.y + _player2Dy * Time.fixedDeltaTime * _playerSpeed);
        else 
            newPosition.y = Mathf.Min(GAME_SCREEN_UP - 1f, newPosition.y + _player2Dy * Time.fixedDeltaTime * _playerSpeed);

        _player2.transform.position = newPosition;
    }
}