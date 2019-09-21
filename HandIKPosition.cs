using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;

public class HandPosition : MonoBehaviour {
    public int posX;
    public int posY;
    public Transform handTarget;
    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;
    public float offsetX;
    public float offsetY;
    public float screenWidth;
    public float screenHeight;
    void Start() {

    }

    void Update() {
        MousePosition();
        SetHand();
    }

    private void MousePosition() {
        posX = Control.MousePosition.x;
        posY = Control.MousePosition.y;
    }
    
    private void SetHand() {
        float x = xMin + (posX-offsetX) / (screenWidth * (xMax - xMin));
        float y = yMin - (posY-offsetY) / (screenHight * (yMin - yMax));

        x = Mathf.Clamp(x, xMin, xMax);
        y = Mathf.Clamp(y, yMax, yMin);
        handTarget.localPosition = new Vector3(x,y,0);
    }
}