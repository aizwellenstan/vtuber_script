using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionController : MonoBehaviour {
    public MousePointerTest mouse;
    public Transform handTarget;
    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;
    public float offseX;
    public float offsetY;
    public float screenWidth;
    public float screenHeight;

    void Start() {

    }

    void Update() {
        SetHand();
    }
    private void SetHand() {
        float x = xMin + (mouse.posXcs-offsetX) / (screenWidth * (xMax - xMin));
        float y = yMin - (mouse.posYcs-offsetY) / (screenHeight * (yMin - yMax));
    }
}