using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public static string GameState = "idle";

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
