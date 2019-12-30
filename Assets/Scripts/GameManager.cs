using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static string GameState = "idle";
    
    public static float GAME_SCREEN_UP = 0f;
    public static float GAME_SCREEN_DOWN = 0f;
    public static float GAME_SCREEN_LEFT = 0F;
    public static float GAME_SCREEN_RIGHT = 0f;
    
    public const float PLAYER_WIDTH = 5.0f;
    public const float PLAYER_HEIGHT = 20.0f;

    public const float BALL_RADIUS = 4.0f;

    public static int player1Score = 0;
    public static int player2Score = 0;
    public static Text mainText;
    public Vector3 cameraCoordinates;
    
    public float playerSpeed = 200f;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        // That Vector has coordinates of the left down corner of the camera Field
        cameraCoordinates = GameObject.FindObjectOfType<Camera>().ViewportToWorldPoint(new Vector3()); 
        
        GAME_SCREEN_UP = cameraCoordinates.y * -1;
        GAME_SCREEN_DOWN = cameraCoordinates.y * 1;
        GAME_SCREEN_RIGHT = cameraCoordinates.x * -1;
        GAME_SCREEN_LEFT = cameraCoordinates.x * 1;
        
        mainText = GameObject.FindWithTag("mainText").GetComponent<Text>();
        GameState = "idle";
        mainText.text = "Press \"Enter\" to start a game";
    }
}
