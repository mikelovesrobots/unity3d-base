using UnityEngine;
using System.Collections;

public class CameraFader : MonoBehaviour {
    private static CameraFader instance;
    private const float ANIMATION_TIME = 1f;

    public static CameraFader Instance {
        get {
            if (instance == null) {
                instance = GameObject.Find("/Global/CameraFader").GetComponent<CameraFader>();
            }

            return instance;
        }
    }

    private void Start () {
        iTween.CameraFadeAdd();
    }

    public void FadeOut() {
        iTween.CameraFadeTo(1, ANIMATION_TIME);
    }

    public void FadeIn() {
        iTween.CameraFadeTo(0, ANIMATION_TIME);
    }
}
