using Dices.Scripts;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class ButtonWithTMP : EditorWindow {
    
    [MenuItem("GameObject/UI/ButtonWithTMP")]
    static void AddButton() {
        RectTransform targetTransform = Selection.activeTransform as RectTransform;
        
        if (targetTransform != null) {
            GameObject g = Instantiate(Resources.Load("btn_") as GameObject, targetTransform);
            g.name = "btn_";
        }
    }
}
