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
                    n.ShowNextLine();
                    ball.PumpTheBrakes();
                    return;
                }
            }
        }else if(DialogUI.i.talkingTo != null){
            NPC n = DialogUI.i.talkingTo;
            if( (n.transform.position - transform.position).sqrMagnitude > n.radius * n.radius * 2 ){
                DialogUI.i.Close();
                n.ConversationEnd();
                DialogUI.i.talkingTo = null;
            }else{
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
                    n.ShowNextLine();
                }
            }
        }

        if(transform.position.y < -5 || Input.GetKeyDown(KeyCode.R)){
            GameManager.i.RespawnPlayer(this);
        }

   }

    public void RespawnPlayer(){
        transform.position = GameManager.i.spawnPoint.position;
        ball.PumpTheBrakes();
    }

}
