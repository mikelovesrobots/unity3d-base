using UnityEngine;
using System.Collections;

public class ViewportToWorldPositioner : MonoBehaviour {
    private const float DISTANCE_FROM_CAMERA = 10f;
    public Vector2 Viewport;

    void Start () {
        Vector3 viewport3 = Viewport;
        viewport3.z = DISTANCE_FROM_CAMERA;
        var worldPoint = Camera.main.ViewportToWorldPoint(viewport3);
        transform.position = worldPoint;
    }
}
