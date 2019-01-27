using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if(pc != null){
           GameManager.i.RespawnPlayer(pc);
        }
    }
}
