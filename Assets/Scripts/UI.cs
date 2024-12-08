using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Box(new Rect(50, 50, 1000, 50), "Score: " + Player.score + "  Lives: " + Player.playerLives);
    }
}
