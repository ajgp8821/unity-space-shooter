using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    private Rigidbody rig;

    public float speed = 20f;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start() {
        rig.velocity = transform.forward * speed;
    }
}
