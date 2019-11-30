using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string GameState = "idle";
    
    public const float GAME_SCREEN_UP = 100f;
    public const float GAME_SCREEN_DOWN = -100f;
    
    public const float PLAYER_WIDTH = 5.0f;
    public const float PLAYER_HEIGHT = 20.0f;

    public const float BALL_RADIUS = 4.0f;

    public float playerSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        GameState = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
