using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandling : MonoBehaviour {
    
    void DebugRaycast(Vector2 v) {
        GameObject player = GameObject.Find("Player");
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, v);
        if (!hit.collider) {
            Debug.Log("No hit at " + v);
        } else if (hit.collider) {
            Debug.Log("Hit at " + v + " " + hit.collider.name);
        }
    }

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(Input.mousePosition);
            //Debug.Log(player.transform.position);

            DebugRaycast(Vector2.left);
            DebugRaycast(Vector2.down);
            DebugRaycast(Vector2.right);
            DebugRaycast(Vector2.up);

            RaycastHit2D hit4 = Physics2D.Raycast(player.transform.position, Vector3.forward); //eventually input.mouseposition
            if (!hit4.collider) {
                Debug.Log("No hit forward");
            } else if (hit4.collider) {
                Debug.Log("Got hit forward" + hit4.collider.name);
            }

            RaycastHit2D hit5 = Physics2D.Raycast(player.transform.position, Vector3.back); //eventually input.mouseposition
            if (!hit5.collider) {
                Debug.Log("No hit back");
            } else if (hit5.collider) {
                Debug.Log("Got hit back" + hit5.collider.name);
            }
        }
    }
}
