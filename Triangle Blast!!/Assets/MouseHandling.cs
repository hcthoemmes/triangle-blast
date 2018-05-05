using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandling : MonoBehaviour {
    
    void DebugRaycast(Vector3 v) {
        GameObject player = GameObject.Find("Player");
        Ray ray = new Ray(player.transform.position, v);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit)) {
            Debug.Log("Hit at " + v + " " + hit.collider);
            Debug.DrawRay(ray.origin, ray.direction, Color.yellow, 5, false);
        } else {
            Debug.Log("No hit at " + v);
        }
    }

    void DebugRaycast3(Vector3 v) {
        GameObject player = GameObject.Find("Player");
        RaycastHit2D hit5 = Physics2D.Raycast(player.transform.position, v); //eventually input.mouseposition
        if (!hit5.collider) {
            Debug.Log("No hit at " + v);
        } else if (hit5.collider) {
            Debug.Log("Hit at" + v + " " + hit5.collider.name);
        }
    }

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");
        if (Input.GetMouseButtonDown(0)) {
            //Debug.Log(Input.mousePosition);
            //Debug.Log(player.transform.position);

            //DebugRaycast(Vector2.left);
            //DebugRaycast(Vector2.down);
            //DebugRaycast(Vector2.right);
            //DebugRaycast(Vector2.up);
            //DebugRaycast3(Vector3.forward);
            //DebugRaycast3(Vector3.back);
            DebugRaycast(Input.mousePosition * 100);
        }
    }
}