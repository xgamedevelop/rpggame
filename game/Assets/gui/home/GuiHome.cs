using UnityEngine;
using System.Collections;

public class GuiHome : MonoBehaviour
{
    void OnGUI ()
    {
        var W = Screen.width;
        var H = Screen.height;
        int w = 200, h = 100, space = 20;
        int y = H - h - space;

        if (GUI.Button (new Rect (space, y, w, h), "Exit")) {
            Application.Quit ();
        }
        if (GUI.Button (new Rect (W - w - space, y, w, h), "Play")) {
            Debug.Log ("Play");
        }
    }
}
