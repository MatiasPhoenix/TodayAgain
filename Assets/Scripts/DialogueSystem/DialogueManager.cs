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

    [Header("Programmer Dialogue")]
    [SerializeField]
    private TextMeshProUGUI _programmerMessage;

    [Header("SO Progress Manager")]
    [SerializeField]
    private SOProgressManager _soProgressManager;

    //Dialoghi programmatore
    //
    public void DialogueProgrammer(string topic, int index)
    {
        switch (topic)
        {
            case "Room":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Programmer, Topic.Room, index, _programmerMessage)
                );
                break;
            case "Computer":
                StartCoroutine(
                    TypeCurrentSentence(
                        Speaker.Programmer,
                        Topic.Computer,
                        index,
                        _programmerMessage
                    )
                );
                break;
            case "Mirror":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Programmer, Topic.Mirror, index, _programmerMessage)
                );
                break;
            case "Chair":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Programmer, Topic.Chair, index, _programmerMessage)
                );
                break;
            default:
                _programmerMessage.text =
                    $"Missing topic: {topic} for speaker {Speaker.Programmer}";
                break;
        }
    }

    public void SoulDialogue(string topic, int index)
    {
        switch (topic)
        {
            case "Room":
                StartCoroutine(TypeCurrentSentence(Speaker.Soul, Topic.Room, index, _soulMessage));
                break;
            case "Computer":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Soul, Topic.Computer, index, _soulMessage)
                );
                break;
            case "Mirror":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Soul, Topic.Mirror, index, _soulMessage)
                );
                break;
            case "Chair":
                StartCoroutine(TypeCurrentSentence(Speaker.Soul, Topic.Chair, index, _soulMessage));
                break;
            case "Email":
                StartCoroutine(TypeCurrentSentence(Speaker.Soul, Topic.Email, index, _soulMessage));
                break;
            case "MetaGame":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Soul, Topic.MetaGame, index, _soulMessage)
                );
                break;
            case "SoulComment":
                StartCoroutine(
                    TypeCurrentSentence(Speaker.Soul, Topic.SoulComment, index, _soulMessage)
                );
                break;
            default:
                _soulMessage.text = $"Missing topic: {topic} for speaker {Speaker.Soul}";
                break;
        }
    }

    public IEnumerator DialogueSoulAndTimer(string topic, int index, int timer)
    {
        yield return new WaitForSeconds(timer);
        SoulDialogue(topic, index);
    }

    void ResetSoulMessage() => _soulMessage.text = "";

    public IEnumerator TypeCurrentSentence(
        Speaker speaker,
        Topic topic,
        int index,
        TextMeshProUGUI targetText,
        float textSpeed = 0.08f
    )
    {
        targetText.text = "";

        string sentence = Dialogue.GetDialogue(speaker, topic, index);

        foreach (char letter in sentence)
        {
            targetText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        SoundManager.Instance.StopMusic(2);
        if (speaker == Speaker.Programmer)
            yield return new WaitForSeconds(2f);
        if (speaker == Speaker.Soul)
        {
            yield return new WaitForSeconds(3f);
            ResetSoulMessage();
        }
        targetText.text = "";
    }
}
