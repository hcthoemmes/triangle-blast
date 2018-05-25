using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandling : MonoBehaviour {

    // Use this for initialization
    void Start() {
        
    }

    public LineRenderer lineRenderer;
    RaycastHit hit;
    public Transform bouncyString; /*doesn't necessarily need to be a transform,
                                    any gameObject works*/
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
            //Vector2 staticRayDirection = rayDirection;

            onClickRaycast(rayDirection);
            /*add a while loop for the duration of reflection that don't hit the
              bottomWall, and then stop it*/
            Debug.Log(pixelVector + ": pixelvector" + ", " + worldCoordinates + ": worldCoordinates");
        }

    }

    void onClickRaycast(Vector3 rayDirection) {
        //BouncyString clone = Instantiate(bouncyString);
        lineRenderer = GetComponentInParent<LineRenderer>();
        GameObject player = GameObject.Find("Player");
        Vector3 playerCoord = new Vector3(rayDirection.x, (rayDirection.y + 5), player.transform.position.z);
        //Instantiate(bouncyString, playerCoord, Quaternion.identity);
        Ray ray = new Ray(player.transform.position, playerCoord);
        if (Physics.Raycast(ray.origin, playerCoord, out hit)) { //TODO: if hit isn't bottomwall, add 1 to x, lineRendererPos[x] 
            //Debug.Log("Hit at " + playerCoord + " " + hit.collider);
            //Debug.DrawRay(ray.origin, playerCoord, Color.yellow, 5, false);
            Vector3[] lineRendererPositions = new Vector3[7];
            lineRendererPositions[0] = player.transform.position;
            lineRendererPositions[1] = hit.point;
            for (int x = 2; x < 7; x++) {
                rayDirection = Vector3.Reflect(rayDirection, hit.normal);
                if (Physics.Raycast(hit.point, rayDirection, out hit)) {
                    lineRendererPositions[x] = hit.point;
                }
                lineRenderer.positionCount = lineRendererPositions.Length;
                lineRenderer.SetPositions(lineRendererPositions);
            }

            //add bottom-wallness as a thing post reflection
            //Debug.Log(lineRendererPositions[1] + "LineRenderer hit zone");

        } else {
            Debug.Log("No hit at " + playerCoord);
        }
    }
}

//for some float is less than ray.magnitude, instantiate new lazors