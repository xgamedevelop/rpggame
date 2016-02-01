using UnityEngine;
using System.Collections;

public class GuiChoose : MonoBehaviour
{
    public Texture2D ExitIcon;
    public GUISkin EmptySkin;

    void OnGUI ()
    {
        GUI.skin = EmptySkin;
        var H = Screen.height;

        int h = (int)(H * 0.15), w = h * 2, space = 10;
        int y = H - h - space;

        // exit
        if (GUI.Button (new Rect (2 * space, y, w, h), ExitIcon)) {
            Application.Quit ();
        }
    }
}
