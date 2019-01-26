using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : SingletonScript<DialogUI>
{

    public Button choiceA;
    public Button choiceB;

    public CanvasGroup cg;
    public TextMeshProUGUI  text;
    public NPC talkingTo;

    public void Show(NPC n, string s, bool player){

        text.faceColor = player ? Color.red : Color.white;
        text.alignment = player ? TextAlignmentOptions.MidlineRight : TextAlignmentOptions.MidlineLeft;

        talkingTo = n;
        text.SetText(s);
        if(cg.alpha == 0){
            AddAnimation(0.3f, (a) => cg.alpha = a + 0.01f);
        }
    }

    public void Close(){
        Debug.Log("Closing dialog");
        AddAnimation(0.3f, (a) => cg.alpha = 1 - a);
    }

    public bool isOpen {
        get {
            return cg.alpha > 0;
        }
    }

    public void ChooseA(){

    }
    
    public void ChooseB(){

    }
}
