using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {
    private const float FADE_IN_AMOUNT = 0f;
    private const float FADE_OUT_AMOUNT = 1f;
    private const float FADE_IN_TIME = 1f;
    private const float FADE_OUT_TIME = 1f;
    public Texture2D FadeTexture;
    private Color Color;

    private string levelName;

    private static SceneTransition instance;
    public static SceneTransition Instance {
        get {
            if (instance == null) {
                instance = GameObject.Find("/Global/SceneTransition").GetComponent<SceneTransition>();
            }

            return instance;
        }
    }

    void Start() {
        FadeIn();
    }

    void OnGUI() {
       if (Color.a != 0) {
           GUI.color = Color;
           GUI.DrawTexture(ScreenRect, FadeTexture);
       }
    }

    private Rect ScreenRect {
        get { return new Rect(0, 0, Screen.width, Screen.height); }
    }

    public void TransitionTo(string levelName) {
        this.levelName = levelName;

        FadeOut();
    }

    private void FadeIn() {
        var options = new Hashtable();
        options.Add("from", FADE_OUT_AMOUNT);
        options.Add("to", FADE_IN_AMOUNT);
        options.Add("time", FADE_IN_TIME);
        options.Add("onupdate", "TweenAlpha");
        options.Add("onupdatetarget", gameObject);
        iTween.ValueTo(gameObject, options);
    }

    private void FadeOut() {
        var options = new Hashtable();
        options.Add("from", FADE_IN_AMOUNT);
        options.Add("to", FADE_OUT_AMOUNT);
        options.Add("time", FADE_IN_TIME);
        options.Add("onupdate", "TweenAlpha");
        options.Add("onupdatetarget", gameObject);
        options.Add("oncomplete", "LoadLevel");
        options.Add("oncompletetarget", gameObject);
        iTween.ValueTo(gameObject, options);
    }

    private void TweenAlpha(float alpha) {
        Color = new Color (1, 1, 1, alpha);
    }

    private void LoadLevel() {
        Application.LoadLevel(levelName);
    }
}

