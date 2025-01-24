using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI body;

    public string characterName;
    public string[] dialogue;
    public string currentLine;
    public int index; 
    public bool isTyping;
    public bool end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        nameTag.text = characterName;
        body.text = "";
        
    }

    void Update()
    {
        body.text = currentLine;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(InputSystem.actions["Move"].ReadValue<Vector2>().y == 1 && !isTyping)
        {
            StartCoroutine(TypeLine());
        }
        else if(InputSystem.actions["Move"].ReadValue<Vector2>().y == 1 && end)
        {
            index = 0;
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        currentLine = "";
        isTyping = true;
        foreach(char c in dialogue[index])
        {
            currentLine += c;
            yield return new WaitForSeconds(0.01f);
        }
        NextLine();
        isTyping = false;
        yield return null;
    }

    void NextLine()
    {   
        
        if(index < dialogue.Length - 1)
        {
            index++;
        }
        else
        {
            if(index == dialogue.Length - 1)
            end = true;
        }
    }
}
