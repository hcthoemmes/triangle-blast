using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandling : MonoBehaviour {

    public LineRenderer lineRenderer;
    RaycastHit hit;
    public Transform bouncyString; /*doesn't necessarily need to be a transform,
                                    any gameObject works*/
    // Use this for initialization
    void Start() {
        lineRenderer.loop = false;
    }

    // Update is called once per frame
    void Update() {
        GameObject player = GameObject.Find("Player");
        if (Input.GetMouseButtonDown(0)) {
            Camera camera;
            camera = Camera.main;

            float screenX = Input.mousePosition.x;
            float screenY = Input.mousePosition.y;

            Vector3 worldSizeVector = new Vector3(10, 10);
            Vector3 pixelVector = new Vector3(screenX, screenY);
            Vector3 screenSizeVector = new Vector3(camera.pixelHeight, camera.pixelWidth);

            Vector3 worldCoordinates = NewBehaviourScript.pixelVectorToWorldVector(
                pixelVector, worldSizeVector, screenSizeVector);

            Vector3 yellowBallPosition = NewBehaviourScript.coordinateShift(
                worldSizeVector.x, worldSizeVector.y, worldCoordinates);
            //Vector3 staticRayDirection = rayDirection;

            onClickRaycast(yellowBallPosition);
            /*add a while loop for the duration of reflection that don't hit the
              bottomWall, and then stop it*/
            Debug.Log(pixelVector + ": pixelvector" + ", " + worldCoordinates + ": worldCoordinates");
        }

    }

    void onClickRaycast(Vector3 yellowBallPosition) {

        int lineCount = 7;

        //BouncyString clone = Instantiate(bouncyString);
        lineRenderer = GetComponentInParent<LineRenderer>();
        GameObject player = GameObject.Find("Player");
        Vector3 rayDirection = yellowBallPosition - player.transform.position;
        Vector3 playerCoord = new Vector3(rayDirection.x, rayDirection.y, player.transform.position.z);
        //Instantiate(bouncyString, playerCoord, Quaternion.identity);
        Ray ray = new Ray(player.transform.position, playerCoord);
        if (Physics.Raycast(ray.origin, playerCoord, out hit)) { //TODO: if hit isn't bottomwall, add 1 to x, lineRendererPos[x] 
            //Debug.Log("Hit at " + playerCoord + " " + hit.collider);
            //Debug.DrawRay(ray.origin, playerCoord, Color.yellow, 5, false);
            Vector3[] lineRendererPositions = new Vector3[lineCount + 1];
            lineRendererPositions[0] = player.transform.position;
            lineRendererPositions[1] = hit.point;
            RaycastHit nextHit = new RaycastHit();
            for (int x = 2; x <= lineCount; x++) {
                rayDirection = Vector3.Reflect(rayDirection, hit.normal);
                Debug.Log(hit.normal + ": Hit.normal");
                if (Physics.Raycast(hit.point, rayDirection, out nextHit)) {
                    lineRendererPositions[x] = nextHit.point; //remove add 5 later
                    
                    hit = nextHit;
                } else {
                    Debug.LogError("Danger Will Robinson");
                }
            }
            lineRenderer.positionCount = lineCount + 1;
            lineRenderer.SetPositions(lineRendererPositions);
            
            //add bottom-wallness as a thing post reflection
            //Debug.Log(lineRendererPositions[1] + "LineRenderer hit zone");

        } else {
            Debug.Log("No hit at " + playerCoord);
        }
    }
}

//for some float is less than ray.magnitude, instantiate new lazors