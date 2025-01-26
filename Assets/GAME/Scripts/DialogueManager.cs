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
    public bool next;

    public Canvas dialogueCanvas;

    public string voice = "";

    public GameObject sfxObj;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        nameTag.text = characterName;
        end = false;

        sfxObj = GameObject.FindWithTag("SFX");

        //StartCoroutine(TypeLine());
        AkSoundEngine.PostEvent(voice, sfxObj);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            next = true;
        }
    }

    void FixedUpdate()
    {
        
        if(InputSystem.actions["Move"].ReadValue<Vector2>().y == 1 && !isTyping && !end)
        {
            next = false;
            StartCoroutine(TypeLine());

        }
        else if(end)
        {
            StartCoroutine(WaitUntilNext());
            Debug.Log("end");
            index = 0;
            dialogueCanvas.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    IEnumerator WaitUntilNext()
    {
        yield return new WaitUntil(() => next);
    }

    IEnumerator TypeLine()
    {
        
        body.text = "";
        isTyping = true;
        foreach(char c in dialogue[index])
        {
            body.text += c;
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
