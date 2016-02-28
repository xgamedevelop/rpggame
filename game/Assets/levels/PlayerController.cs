using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	void Start () {
	}
	
	void FixedUpdate () {
        var x = CrossPlatformInputManager.GetAxis ("Horizontal");
        var y = CrossPlatformInputManager.GetAxis ("Vertical");
        var move = new Vector2 (-x, -y) * 2;
        transform.localPosition = move;

        var a = CrossPlatformInputManager.GetButton ("A");
        var b = CrossPlatformInputManager.GetButton ("B");
        Debug.LogFormat ("{0}, {1}", a, b);
	}
}
