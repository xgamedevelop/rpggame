using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuiChoose : MonoBehaviour
{
    public Texture2D ExitIcon;
    public Texture2D BackIcon;
    public GUISkin EmptySkin;
    public Sprite[] Numbers;

    public GameObject Prefab;

    void AddLevel (GameObject level, Sprite icon, string scene, int index) {
        var script = level.GetComponent<GuiChooseItem> () as GuiChooseItem;
        script.Scene = scene;
        script.Icon = icon;
        script.Active = index == 1;
    }

    void Start ()
    {
        Camera.main.transform.localPosition = new Vector3 (0f, 2f, -10f);
        var start = GameObject.Find ("start") as GameObject;
        var line = GameObject.Find ("line") as GameObject;

        start.transform.localPosition = new Vector2 (0f, -2f);
        line.transform.localPosition = new Vector2 (0f, 15.225f);

        // load levels
        int index = 0;

        // SceneManager.GetAllScenes()
        var levels = new string [] {"choose", "Level 1", "home", "home", "home"};
        foreach (var scene in levels) {
            var position = new Vector2 (index % 2 == 0 ? -1.737f : 1.707f, index * 2.5f);
            var level = Instantiate (Prefab, position, Quaternion.identity) as GameObject;
            AddLevel (level, Numbers [index], scene, index++);
        }
    }

    void OnGUI ()
    {
        GUI.skin = EmptySkin;
        var W = Screen.width;
        var H = Screen.height;

        int h = (int)(H * 0.15), w = h * 2, space = 10;
        int y = H - h - space;

        // exit
        if (GUI.Button (new Rect (2 * space, y, w, h), ExitIcon)) {
            Application.Quit ();
        }

        // back
        if (GUI.Button (new Rect (W - w - 2 * space, y, w, h), BackIcon)) {
            SceneManager.LoadScene ("home");
        }
    }
}
