using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Behaviour : MonoBehaviour
{
    private Vector2 _player1Position;
    private float _player2Dy;
    private float _playerSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        _player1Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        Player2_Update();
    }

    private void Player2_Update()
    {
        Vector2 newPlayer1Position = transform.position;
        if(transform.position.y <= -21.5f) 
            newPlayer1Position.y = Mathf.Max(-21.5f, newPlayer1Position.y + _player2Dy * Time.fixedDeltaTime * _playerSpeed);
        else 
            newPlayer1Position.y = Mathf.Min(21.5f, newPlayer1Position.y + _player2Dy * Time.fixedDeltaTime * _playerSpeed);

        transform.position = newPlayer1Position;
    }
}
