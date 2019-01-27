using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : SingletonScript<DialogUI>
{
    public Sprite squareBG, sphereBG, playerBG;

    public Image bgImage;

    public Button choiceA;
    public Button choiceB;

    public CanvasGroup cg;
    public TextMeshProUGUI  text;
    public NPC talkingTo;

    public void Show(NPC n, string s, bool player, NPCType type){

        if(player){
            bgImage.sprite = playerBG;
        }else if(type == NPCType.SpherePerson){
            bgImage.sprite = sphereBG;
        }else{
            bgImage.sprite = squareBG;
        }

        text.faceColor = player ? Color.white : Color.white;
        text.alignment = player ? TextAlignmentOptions.MidlineRight : TextAlignmentOptions.MidlineLeft;

        talkingTo = n;
        text.SetText(s);
        if(cg.alpha == 0){
            AddAnimation(0.3f, (a) => cg.alpha = a + 0.01f);
        }
    }

    public void Close(){
        Debug.Log("Closing dialog with: " + talkingTo.gameObject.name);
        talkingTo = null;
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
