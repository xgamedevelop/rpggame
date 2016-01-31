using UnityEngine;
using System.Collections;

public class GuiHome : MonoBehaviour
{
    public Sprite[] Sprites;
    public GameObject Prefab;
    public int Count = 10;

    private GameObject bg;
    private GameObject[] snowflakes;

    void MoveToUp (GameObject snowflake)
    {
        var range = Camera.main.aspect * 5f;
        var size = Random.Range (0.5f, 2.0f);
        var position = new Vector2 (Random.Range (-range, range), Random.Range (7f, 14f));

        // transform
        snowflake.transform.localScale = new Vector2 (size, size);
        snowflake.transform.localPosition = position;

        // gravity and velocity
        var rigidbody = snowflake.GetComponent<Rigidbody2D> () as Rigidbody2D;
        rigidbody.gravityScale = 0.01f + ((size / 2f) * 0.05f);
        rigidbody.velocity = Vector3.zero;

        // sprite
        var renderer = snowflake.GetComponent<SpriteRenderer> () as SpriteRenderer;
        renderer.sprite = Sprites [Random.Range (0, Sprites.Length)];
    }

    void Start ()
    {
        bg = GameObject.Find ("bg");
        snowflakes = new GameObject[Count];
        for (int i = 0; i < snowflakes.Length; ++i) {
            snowflakes [i] = Instantiate (Prefab, new Vector2 (0, 0), Quaternion.identity) as GameObject;
            MoveToUp (snowflakes [i]);
        }
    }

    void Update ()
    {
        var scale = new Vector2 (Camera.main.aspect * 2f, 3.3f);
        bg.transform.localScale = scale;

        foreach (var snowflake in snowflakes) {
            if (snowflake.transform.localPosition.y < -6) {
                MoveToUp (snowflake);
            }
        }
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
