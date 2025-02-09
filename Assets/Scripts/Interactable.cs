using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void baseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
