using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public static List<NPC> allNPCs = new List<NPC>();
    
    public void OnEnable(){
        allNPCs.Add(this);
    }

    public void OnDisable(){
        allNPCs.Remove(this);
    }

    public float radius = 2.5f;
    public string dialogLine;
}
