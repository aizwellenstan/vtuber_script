using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookTarget : MonoBehaviour {
    public HeadLookController head ;
    void Start() {
        head.target-GetComponment<Transform>();
    }

    void Update() {

        
    }
}