using UnityEngine;
using System.Collections;

public class TransformToGuiFinder {
    public static Vector2 Find(Transform target) {
        var position = Camera.main.WorldToScreenPoint(target.position);
        position.y = Screen.height - position.y;
        return position;
    }
}
