using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform cameraParent;
    public float moveScale;
    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);

    void Start() {

    }

    void Update() {
        if(Input.GetMouseButtonDown(2)) {
            newAngle = cameraParent.localEulerAngles;
            lastMousePositionMousePosition = Input.mousePosition;
        }
    }

    public void CameraMove() {
        if(Input.GetMouseButton(2)) {
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * -moveScale;
            cameraParent.localEulerAngles = newAngle;
        }
    }
}