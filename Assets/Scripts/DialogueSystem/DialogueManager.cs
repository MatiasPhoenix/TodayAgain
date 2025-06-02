using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    [Header("Dialogues panel")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMesh _dialogueBox;


    //
    public Array dialogue;
}
