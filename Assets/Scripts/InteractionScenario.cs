using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionScenario : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField]
    private GameObject _chairPcObject;

    // [SerializeField]
    // private TextMeshProUGUI _pcMessage;
    private bool _pcActive = false;

    [SerializeField]
    private GameObject _mirrorObject;

    // [SerializeField]
    // private TextMeshProUGUI _mirrorMessage;

    private float _timerCount = 0f;

    private void Update()
    {
        if (_mirrorObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            MirrorInteractionMessage("Mirror", GetRandomNumber(0, 2));

        if (_chairPcObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            PcInteractionMessage("Computer", GetRandomNumber(0, 4));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("PC"))
            _chairPcObject.SetActive(true);
        else if (other.CompareTag("Player") && gameObject.CompareTag("Mirror"))
            _mirrorObject.SetActive(true);
    }

    public void OnTriggerExit()
    {
        _chairPcObject.SetActive(false);
        // _pcMessage.text = "";
        _mirrorObject.SetActive(false);
        // _mirrorMessage.text = "";
    }

    void MirrorInteractionMessage(string topic, int index)
    {
        _timerCount = 3f;
        _mirrorObject.SetActive(false);
        DialogueManager.Instance.DialogueProgrammer(topic, index);
        StartCoroutine(ActiveTimer());
    }

    void PcInteractionMessage(string topic, int index)
    {
        if (SoundManager.Instance.IsPlaying(3) == false)
            SoundManager.Instance.PlayComputerSound(3, 0);
        _pcActive = true;
        _timerCount = 3f;
        _chairPcObject.SetActive(false);
        DialogueManager.Instance.DialogueProgrammer(topic, index);
        StartCoroutine(ActiveTimer());
    }

    private IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(_timerCount);
        if (_pcActive)
        {
            PcManager.instance.GoToWorkOnPc();
            GameManager.instance.CourutineBoxCollider();
        }

        // _mirrorMessage.text = "";
        // _pcMessage.text = "";
        _pcActive = false;
    }

    private int GetRandomNumber(int min, int max) => Random.Range(min, max + 1);
}
