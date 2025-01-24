using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteraction : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public bool overlap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(overlap && InputSystem.actions["Move"].ReadValue<Vector2>().y == 1)
            {
                dialogueCanvas.gameObject.SetActive(true);
            }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            overlap = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        overlap = false;
    }
}
