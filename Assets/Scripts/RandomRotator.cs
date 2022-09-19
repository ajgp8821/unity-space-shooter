using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble = 1f;
    private Rigidbody rig;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    private void Start() {
        // Vector3 angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        // Vector3 angularVelocity = Random.insideUnitSphere;
        rig.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
