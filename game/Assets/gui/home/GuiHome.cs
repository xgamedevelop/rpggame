using UnityEngine;
using System.Collections;

public class GuiHome : MonoBehaviour
{
    private GameObject bg;

    void Start ()
    {
        bg = GameObject.Find ("bg");
    }

    void Update ()
    {
        var scale = new Vector2 (Camera.main.aspect * 2f, 3.3f);
        bg.transform.localScale = scale;
    }

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
