using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class FontWizard : ScriptableWizard {
    public Font NewFont;
    public Text[] Texts;

    [MenuItem("Инструменты моджахеда/Быстрая смена шрифтов")]
    static void OpenWizard() {
        DisplayWizard<FontWizard>("Нажми 'Найти' что бы почувствовать себя магом",
            "Выйти", "Найти");  
    }

    void OnWizardCreate() {
        foreach (Text text in Texts) {
            if (text == null) {
                Debug.LogWarning( "<Color=Red>Найден пустой текстовый компонент: </Color>" + text.gameObject.name);
                continue;
            }

            text.font = NewFont;
        }
    }

    void OnWizardOtherButton() {
        Texts = Resources.FindObjectsOfTypeAll<Text>();
    }

 }