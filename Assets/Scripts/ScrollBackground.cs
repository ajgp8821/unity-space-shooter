using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public float speed = 1f;

    private Renderer ren;

    private void Start() {
        ren = GetComponent<Renderer>();
    }

    private void Update() {
        ren.material.mainTextureOffset = new Vector2(0, Time.time * speed);
    }
}
