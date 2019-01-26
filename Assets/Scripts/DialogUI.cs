using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : SingletonScript<DialogUI>
{
    public CanvasGroup cg;
    public TextMeshProUGUI  text;

    public void Show(string s){
        AddAnimation(0.3f, (a) => cg.alpha = a);
        text.SetText(s);

        AddAnimation(0.3f, (a) => cg.alpha = 1 - a, 2.0f);
    }
}
