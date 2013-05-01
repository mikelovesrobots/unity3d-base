using UnityEngine;
using System.Collections;

public class SceneTransitionAction : ActionBase {
    public string Level;

    public override void Act() {
        SceneTransition.Instance.TransitionTo(Level);
    }
}
