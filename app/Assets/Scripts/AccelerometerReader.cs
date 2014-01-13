using UnityEngine;
using System.Collections;

public class AccelerometerReader : MonoBehaviour {
    public float Filter = 5.0f;
    public GUIText Label;
    private Vector3 accel;

    void Start() {
        accel = Input.acceleration;
    }

    void Update() {
        // filter the jerky acceleration in the variable accel:
        accel = Vector3.Lerp(accel, Input.acceleration, Filter * Time.deltaTime);

        var dir = new Vector3(accel.x, accel.y, 0);
        // limit dir vector to magnitude 1:
        if (dir.sqrMagnitude > 1) dir.Normalize();

        // sync to framerate
        Label.text = (dir * Time.deltaTime * 100).ToString();
    }
}
