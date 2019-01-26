using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   public void Update(){
       if(Input.GetKeyDown(KeyCode.C)){
           foreach(NPC n in NPC.allNPCs){
               if( (n.transform.position - transform.position).sqrMagnitude < n.radius * n.radius ){
                   DialogUI.i.Show(n.dialogLine);
                   return;
               }
           }
           Debug.Log("No one in range");
       }

   }
}
