using UnityEngine;


public class Interactable : MonoBehaviour {
    

    public bool useEvents;
    public string promptMessage;

    public void baseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().onInteract.Invoke();
        }
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
