using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImageWizard : ScriptableWizard {
    public Image[] Images;
    public Sprite[] Sprites;

    [MenuItem("Инструменты моджахеда/Показать все Image на сцене")]
    static void SetConformity() {
        DisplayWizard<ImageWizard>("Нажми 'Найти' что бы почувствовать себя магом",
            "Натянуть", "Найти");
            //TODO сделать в два столбика что бы вообще кашерно было
    }

    void OnWizardCreate() {
        //Авто наятягивание спрайтов на Image
        if (Images.Length != Sprites.Length) {
            Debug.LogError("Размеры не совпадают" );
            return;
        }

        for (int i = 0; i < Sprites.Length; i++) {
            if (Images[i] == null || Sprites[i] == null) {
                Debug.LogWarning("<Color=Red>Найден null</Color>");
                continue;
            }

            Images[i].sprite = Sprites[i];
        }
    }

    void OnWizardOtherButton() {
        Images = Resources.FindObjectsOfTypeAll<Image>();
    }
}