using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum NPCType{
    SpherePerson, SquarePerson
}

public class NPC : MonoBehaviour
{

    public NPCType type = NPCType.SpherePerson;

    public Vector2 startPos;

    public int currentLine = 0;

    public static List<NPC> allNPCs = new List<NPC>();
    private Rigidbody rb;
    public Vector3 moveDirection;
    
    public void OnEnable(){
        rb = GetComponent<Rigidbody>();
        startPos = new Vector2(transform.position.x, transform.position.z);
        allNPCs.Add(this);
    }

    public void OnDisable(){
        allNPCs.Remove(this);
    }

    public float radius = 2.5f;
    public List<string> dialogLines;

    public void Update(){
        // drive towards start point:

        moveDirection = -(transform.position - new Vector3(startPos.x, transform.position.y, startPos.y));
        rb.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x));
    }

    public void ShowNextLine(){
        if(currentLine < 0){
            // don't show more lines until ConverstaionEnd  is called
            return;
        }

        if(currentLine >= dialogLines.Count){
            currentLine = -1;
            DialogUI.i.Close();
            return;
        }

        string line = dialogLines[currentLine];
        Debug.Log("Show line: " + currentLine + ": " + line);
        DialogUI.i.Show(this, line, currentLine % 2 == 1, type);
        currentLine += 1;

    }

    public void ConversationEnd(){
        Debug.Log("Conversation end with " + this.name);
        currentLine = 0;
    }




}
