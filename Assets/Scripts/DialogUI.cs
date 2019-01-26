using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : SingletonScript<DialogUI>
{
    public CanvasGroup cg;
    public TextMeshProUGUI  text;
    public NPC talkingTo;

    public void Show(NPC n, string s){
        talkingTo = n;
        AddAnimation(0.3f, (a) => cg.alpha = a);
        text.SetText(s);
    }

    public void Close(){
        AddAnimation(0.3f, (a) => cg.alpha = 1 - a);
    }

    public bool isOpen {
        get {
            return cg.alpha > 0;
        }
    }
}
