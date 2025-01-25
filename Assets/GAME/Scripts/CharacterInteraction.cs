using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteraction : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public bool overlap;
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
        material = this.gameObject.GetComponent<SpriteRenderer>().material;
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
            material.SetFloat("_Thickness", 0.023f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            overlap = false;
            material.SetFloat("_Thickness", 0f);
        }
    }
}
