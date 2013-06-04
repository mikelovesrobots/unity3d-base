using UnityEngine;
using System.Collections;

public class CameraBobber : MonoBehaviour {
    private const float SPEED_MULTIPLIER = 0.33f;
    private const float MOVEMENT_DAMPENING = 0.125f;
    private Vector3 intendedPosition;

    void Start() {
        intendedPosition = transform.localPosition;
    }

    void Update () {
        var vertical = Mathf.PerlinNoise(0f, Time.timeSinceLevelLoad * SPEED_MULTIPLIER);
        var horizontal = Mathf.PerlinNoise(Time.timeSinceLevelLoad * SPEED_MULTIPLIER, 0f);
        transform.localPosition = intendedPosition + new Vector3(vertical, horizontal, 0f) * MOVEMENT_DAMPENING;
    }
}
