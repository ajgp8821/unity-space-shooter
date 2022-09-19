using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSizeController : MonoBehaviour {

    private void Start() {
        UpdateBoundary();
    }

    private void UpdateBoundary() {
        Vector2 half = Utils.GetDimensionsInWorldUnits();
        gameObject.transform.localScale = new Vector3(half.x, half.y * 1.5f , 1);
    }
}
