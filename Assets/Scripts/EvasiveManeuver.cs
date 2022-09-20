using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    public float tilt = 4f;

    private float targetManeuver;
    private Rigidbody rig;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    private void Start() {
        UpdateBoundary();
        StartCoroutine(Evade());
    }

    private void FixedUpdate() {
        float newManeuver = Mathf.MoveTowards(rig.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rig.velocity = new Vector3(newManeuver, 0.0f, rig.velocity.z);
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, rig.position.z);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }

    IEnumerator Evade() {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true) {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return  new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
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
}
