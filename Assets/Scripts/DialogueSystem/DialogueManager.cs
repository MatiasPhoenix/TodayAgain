using System.Collections;
using TMPro;
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

    [Header("Soul Dialogue")]
    [SerializeField]
    private TextMeshProUGUI _soulMessage;

    [Header("SO Progress Manager")]
    [SerializeField]
    private SOProgressManager _soProgressManager;

    //Dialoghi programmatore
    //
    public string DialogueProgrammer(string topic, int index)
    {
        string dialogue;
        switch (topic)
        {
            case "Room":
                return dialogue = Dialogue.GetDialogue(Speaker.Programmer, Topic.Room, index);
            case "Computer":
                return dialogue = Dialogue.GetDialogue(Speaker.Programmer, Topic.Computer, index);
            case "Mirror":
                return dialogue = Dialogue.GetDialogue(Speaker.Programmer, Topic.Mirror, index);
            case "Chair":
                return dialogue = Dialogue.GetDialogue(Speaker.Programmer, Topic.Chair, index);
            default:
                return dialogue = $"Missing topic: {topic} for speaker {Speaker.Programmer}";
        }
    }

    public string SoulDialogue(string topic, int index)
    {
        StartCoroutine(ResetSoulMessage());
        switch (topic)
        {
            case "Room":
                return _soulMessage.text = Dialogue.GetDialogue(Speaker.Soul, Topic.Room, index);
            case "Computer":
                return _soulMessage.text = Dialogue.GetDialogue(
                    Speaker.Soul,
                    Topic.Computer,
                    index
                );
            case "Mirror":
                return _soulMessage.text = Dialogue.GetDialogue(Speaker.Soul, Topic.Mirror, index);
            case "Chair":
                return _soulMessage.text = Dialogue.GetDialogue(Speaker.Soul, Topic.Chair, index);
            case "Email":
                return _soulMessage.text = Dialogue.GetDialogue(Speaker.Soul, Topic.Email, index);
            case "MetaGame":
                return _soulMessage.text = Dialogue.GetDialogue(
                    Speaker.Soul,
                    Topic.MetaGame,
                    index
                );
            case "SoulComment":
                return _soulMessage.text = Dialogue.GetDialogue(
                    Speaker.Soul,
                    Topic.SoulComment,
                    index
                );
            default:
                return _soulMessage.text = $"Missing topic: {topic} for speaker {Speaker.Soul}";
        }
    }
    public void TestSoulDialogue()
    {
        if (_soProgressManager.GameOutOfGameCheck() == false)
        {
            SoulDialogue("Email", 0);
        }
    }

    IEnumerator ResetSoulMessage()
    {
        yield return new WaitForSeconds(3f);
        _soulMessage.text = "";
    }
}
