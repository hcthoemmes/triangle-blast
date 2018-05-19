using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandling : MonoBehaviour {

    void onClickRaycast(Vector2 v) {
        GameObject player = GameObject.Find("Player");
        Vector3 playerZone = new Vector3(v.x, (v.y + 5), player.transform.position.z);
        Ray ray = new Ray(player.transform.position, playerZone);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, playerZone, out hit)) {
            Debug.Log("Hit at " + playerZone + " " + hit.collider);
            Debug.DrawRay(ray.origin, playerZone, Color.yellow, 5, false);
        } else {
            Debug.Log("No hit at " + playerZone);
        }
    }

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");
        if (Input.GetMouseButtonDown(0)) {
            Camera camera;
            camera = Camera.main;

            float screenX = Input.mousePosition.x;
            float screenY = Input.mousePosition.y;

            Vector2 worldSizeVector = new Vector2(10, 10);
            Vector2 pixelVector = new Vector2(screenX, screenY);
            Vector2 screenSizeVector = new Vector2(camera.pixelHeight, camera.pixelWidth);

            Vector2 worldCoordinates = NewBehaviourScript.pixelVectorToWorldVector(
                pixelVector, worldSizeVector, screenSizeVector);

            Vector2 rayDirection = NewBehaviourScript.coordinateShift(
                worldSizeVector.x, worldSizeVector.y, worldCoordinates);
    
            onClickRaycast(rayDirection);
            Debug.Log(Input.mousePosition);
            Debug.Log(pixelVector + "," + worldCoordinates);
        }
    }
}