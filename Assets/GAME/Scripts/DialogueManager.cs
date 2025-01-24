using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI body;

    public string characterName;
    public string[] dialogue;
    public string currentLine;
    private int index; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        nameTag.text = characterName;
        body.text = "";
        currentLine = dialogue[index];
    }

    // Update is called once per frame
    void Update()
    {
        body.text = currentLine;
    }

    void OnMouseDown()
    {
        if(index < dialogue.Length)
        {
            index++;
        }
        else
        {
            if(index == dialogue.Length)
            this.gameObject.SetActive(false);
        }
    }
}
