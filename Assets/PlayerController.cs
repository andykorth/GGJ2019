using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Ball ball;

    public void Start(){
        ball = GetComponent<Ball>();
    }

   public void Update(){
      
        if(!DialogUI.i.isOpen){
            foreach(NPC n in NPC.allNPCs){
                if( (n.transform.position - transform.position).sqrMagnitude < n.radius * n.radius ){
                    DialogUI.i.Show(n, n.dialogLine);
                    ball.PumpTheBrakes();
                    return;
                }
            }
        }else if(DialogUI.i.talkingTo != null){
            NPC n = DialogUI.i.talkingTo;
            if( (n.transform.position - transform.position).sqrMagnitude > n.radius * n.radius ){
                DialogUI.i.Close();
                DialogUI.i.talkingTo = null;
            }
        }


   }
}
