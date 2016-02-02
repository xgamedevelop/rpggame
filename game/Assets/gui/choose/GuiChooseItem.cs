using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuiChooseItem : MonoBehaviour
{
    public bool Active = true;
    public string Scene = "home";
    public Sprite Icon;

    private float bounce = 0;
    private float go = -1;
    private float angle = 0;

    private Transform pointer;
    private SpriteRenderer pointerRenderer;

    void Start ()
    {
        pointer = transform.Find ("pointer") as Transform;
        pointerRenderer = pointer.GetComponent<SpriteRenderer> () as SpriteRenderer;

        var icon = transform.Find ("icon") as Transform;
        var iconRenderer = icon.GetComponent<SpriteRenderer> () as SpriteRenderer;
        iconRenderer.sprite = Icon;
    }

    void Update ()
    {
        if (Active) {
            bounce += 0.15f;
            pointerRenderer.enabled = true;
            pointer.transform.localPosition = new Vector2 (0f, 1.1f + Mathf.Sin (bounce) * 0.1f);
        } else {
            pointerRenderer.enabled = false;
        }

        if (IsClicked ()) {
            SceneManager.LoadScene (Scene);
        }
    }

    void ReviewCollider (Vector2 position)
    {
        var point = Camera.main.ScreenToWorldPoint (position);
        var hit = Physics2D.Raycast (point, Vector2.zero);
        if (hit.collider != null && hit.collider == GetComponent<CircleCollider2D> ()) {
            go = 0;
            angle = 0;
        }
    }

    void ReviewEvent ()
    {
        if (Input.GetMouseButtonDown (0)) {
            ReviewCollider (Input.mousePosition);
        }
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
            ReviewCollider (Input.GetTouch (0).position);
        }
    }

    bool IsClicked ()
    {
        ReviewEvent ();

        if (go >= 0) {
            go += 0.2f;
            angle += go;
            if (angle < 3 * 360) {
                transform.Rotate (new Vector3 (0f, 0f, -go));
            } else {
                transform.rotation = Quaternion.identity;
            }
        }

        if (angle > 4 * 360) {
            go = -1;
            angle = 0;
            return true;
        } else {
            return false;
        }
    }
}
