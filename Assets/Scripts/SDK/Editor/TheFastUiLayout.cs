using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Dices.Scripts.Editor {

public class TheFastUiLayout : EditorWindow {
    public Object TMP_FontAsset_1;
    public Object TMP_FontAsset_2;

    [MenuItem("Инструменты моджахеда/Быстрая верстка")]
    public static void ShowWindow() {
        GetWindow<TheFastUiLayout>("Верстальщик");
    }

    void OnGUI() {
        GUILayout.Label("Хозяин?", EditorStyles.boldLabel);

        if (GUILayout.Button("SetObjectAnchorsOnVertices")) {
            SetObjectAnchorsOnVertices();
        }

        if (GUILayout.Button("SetObjectVerticesOnAnchors")) {
            SetObjectVerticesOnAnchors();
        }

        if (GUILayout.Button("SetNativeSize")) {
            SetNativeSize();
        }

        EditorGUILayout.LabelField("Шрифт 1");
        TMP_FontAsset_1 = EditorGUILayout.ObjectField(TMP_FontAsset_1, typeof(TMP_FontAsset), false);
        EditorGUILayout.LabelField("Шрифт 2");
        TMP_FontAsset_2 = EditorGUILayout.ObjectField(TMP_FontAsset_2, typeof(TMP_FontAsset), false);
        EditorGUILayout.LabelField("Назначить дочерним TMP шрифт %номер%", EditorStyles.helpBox);
        
        if (GUILayout.Button("1")) {
            SetFontToAllChildTMP((TMP_FontAsset)TMP_FontAsset_1);
        }
        if (GUILayout.Button("2")) {
            SetFontToAllChildTMP((TMP_FontAsset)TMP_FontAsset_2);
        }
    }
    
    void SetObjectVerticesOnAnchors() {
        foreach (GameObject gameObj in Selection.gameObjects) {
            RectTransform rectTransform = gameObj.GetComponent<RectTransform>();
            if (rectTransform != null) {
                rectTransform.sizeDelta = Vector2.zero;
                rectTransform.anchoredPosition = Vector2.zero;
            }
            else {
                Debug.LogWarning("Один из выбранных объектов не содержит RectTransform");
            }
        }
    }

    void SetObjectAnchorsOnVertices() {
        foreach (GameObject gameObj in Selection.gameObjects) {
            RectTransform rectTransform = gameObj.GetComponent<RectTransform>();
             
            if (rectTransform != null) {
                
                Rect rectTransformRect = rectTransform.rect;
                Vector2 pivot = rectTransform.pivot;
                Vector2 anchoredPosition = rectTransform.anchoredPosition;

                RectTransform parentRectTransform = rectTransform.parent.gameObject.GetComponent<RectTransform>();
                Rect parentRect = parentRectTransform.rect;

                float pivotX = rectTransformRect.width * pivot.x;
                float pivotY = rectTransformRect.height * (1 - pivot.y);
                
                Vector2 newRect = new Vector2(
                    rectTransform.anchorMin.x * parentRect.width + rectTransform.offsetMin.x + pivotX -
                    parentRect.width * anchoredPosition.x,
                    -(1 - rectTransform.anchorMax.y) * parentRect.height + rectTransform.offsetMax.y - pivotY +
                    parentRect.height * (1 - anchoredPosition.y));

                rectTransformRect.x = newRect.x;
                rectTransformRect.y = newRect.y;

                Vector3 localScale = rectTransform.localScale;

                rectTransform.anchorMin = new Vector2(0f, 1f);
                rectTransform.anchorMax = new Vector2(0f, 1f);

                rectTransform.offsetMin = new Vector2(
                    rectTransformRect.x / localScale.x,
                    rectTransformRect.y / localScale.y - rectTransformRect.height);

                rectTransform.offsetMax = new Vector2(
                    rectTransformRect.x / localScale.x + rectTransformRect.width,
                    rectTransformRect.y / localScale.y);

                rectTransform.anchorMin = new Vector2(
                    rectTransform.anchorMin.x + anchoredPosition.x +
                    (rectTransform.offsetMin.x - pivotX) / parentRect.width * localScale.x,
                    rectTransform.anchorMin.y - (1 - anchoredPosition.y) +
                    (rectTransform.offsetMin.y + pivotY) / parentRect.height * localScale.y);

                rectTransform.anchorMax = new Vector2(
                    rectTransform.anchorMax.x + anchoredPosition.x +
                    (rectTransform.offsetMax.x - pivotX) / parentRect.width * localScale.x,
                    rectTransform.anchorMax.y - (1 - anchoredPosition.y) +
                    (rectTransform.offsetMax.y + pivotY) / parentRect.height * localScale.y);

                rectTransform.offsetMin = new Vector2(
                    (0 - pivot.x) * rectTransformRect.width * (1 - localScale.x),
                    (0 - pivot.y) * rectTransformRect.height * (1 - localScale.y));

                rectTransform.offsetMax = new Vector2(
                    (1 - pivot.x) * rectTransformRect.width * (1 - localScale.x),
                    (1 - pivot.y) * rectTransformRect.height * (1 - localScale.y));     
            }
            else {
                Debug.LogWarning("Один из выбранных объектов не содержит RectTransform");
            }
        } 
    }

    void SetNativeSize() {
        foreach (GameObject gameObj in Selection.gameObjects) {
            Image image = gameObj.GetComponent<Image>();
            if (image != null) {
                image.SetNativeSize();
            }
            else {
                Debug.LogWarning("Один из выбранных объектов не содержит Image");
            }
        }
    }

    void SetFontToAllChildTMP(TMP_FontAsset fontAsset) {
        if (fontAsset != null) {
            foreach (Transform objTransform in Selection.transforms) {
                TextMeshProUGUI[] textMeshProUGUI = objTransform.GetComponentsInChildren<TextMeshProUGUI>();
                foreach (TextMeshProUGUI TMP in textMeshProUGUI) {
                    TMP.font = fontAsset;
                }
            }
        }
        else {
            Debug.LogError("Не назначен один из шрифтов!!!!!");
        }

    }
}

}