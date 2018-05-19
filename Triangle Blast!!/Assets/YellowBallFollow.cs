using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

//could the issue with mousePosition be related to the EventSystem? investigate further

public class YellowBallFollow : MonoBehaviour {
    
    Camera camera;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
        Debug.Log(camera.pixelRect);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        //this.transform.position = Input.mousePosition;
        float screenX = Input.mousePosition.x;
        float screenY = Input.mousePosition.y;

        Vector2 pixelVector = new Vector2(screenX, screenY);

        Vector2 screenSizeVector = new Vector2(camera.pixelHeight, camera.pixelWidth);
        Vector2 worldSizeVector = new Vector2(10, 10);

        Vector2 worldCoordinates = NewBehaviourScript.pixelVectorToWorldVector(pixelVector, worldSizeVector, screenSizeVector);

        this.transform.position = NewBehaviourScript.coordinateShift(worldSizeVector.x, worldSizeVector.y, worldCoordinates);
        //this.transform.position = new Vector2(0, 0);
        Debug.Log(screenX + "," + screenY);
    }

    private void OnMouseDown() {
        
    }
}
