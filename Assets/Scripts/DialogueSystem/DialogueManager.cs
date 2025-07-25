using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    //Dialoghi programmatore
    //
    public void DialoguesCylce01()
    {
        Dialogue.DialoguesMetod(0, 0);
    }
}
