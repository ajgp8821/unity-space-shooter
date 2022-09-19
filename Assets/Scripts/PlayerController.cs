using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float speed = 10f;
    public float tilt = 4f;
    public Boundary boundary;
    private Rigidbody rig;

    [Header("Shooting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.25f;
    private AudioSource audioSource;
    private float nextFire;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        UpdateBoundary();
    }

    private void UpdateBoundary() {
        Vector2 half = Utils.GetDimensionsInWorldUnits() / 2;
        // Debug.Log("Half * 2 " + half * 2);
        // Debug.Log("Half / 2 " + half);
        boundary.xMin = -half.x + 0.87f;
        boundary.xMax = half.x - 0.87f;
        boundary.zMin = -half.y + 9;
        boundary.zMax = half.y + 2;
    }

    private void Update() {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            audioSource.Play();
        }
    }

    private void FixedUpdate() {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
