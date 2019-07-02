using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class ButtonWizard : ScriptableWizard {
    
    public Button[] Buttons;

    [MenuItem("Инструменты моджахеда/DisableColor всех Button = (1, 1, 1, 1)")]
    static void SetConformity() {
        DisplayWizard<ButtonWizard>("Нажми 'Найти' что бы почувствовать себя магом",
            "Выйти", "Найти");
    }

    void OnWizardCreate() {
        foreach (Button button in Buttons) {
            if (button == null) {
                Debug.LogWarning("<Color=Red>Найден null Button: </Color>" + button.gameObject.name);
                continue;
            }

            ColorBlock buttonColors = new ColorBlock {disabledColor = Color.white};
            button.colors = buttonColors;
        }
    }

    void OnWizardOtherButton() {
        Buttons = Resources.FindObjectsOfTypeAll<Button>();
    }
}