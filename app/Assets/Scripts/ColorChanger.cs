using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
    public Renderer[] Renderers;
    public string ColorName = "_TintColor";

    public void ChangeColor(Color color) {
        foreach (var renderer in Renderers) {
            renderer.material.SetColor(ColorName, color);
        }
    }
}
