using System.Collections;
using UnityEngine;

public class InteractionScenario : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private GameObject _chairPcObject;
    [SerializeField] private GameObject _pcMessage;
    [SerializeField] private GameObject _mirrorObject;
    [SerializeField] private GameObject _mirrorMessage;

    private float _timerCount = 0f;

    private void Update()
    {
        if (_mirrorObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            MirrorInteractionMessage();

        if (_chairPcObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            PcInteractionMessage();
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
        _pcMessage.SetActive(false);
        _mirrorObject.SetActive(false);
        _mirrorMessage.SetActive(false);
    }

    void MirrorInteractionMessage()
    {
        _timerCount = 3f;
        _mirrorObject.SetActive(false);
        _mirrorMessage.SetActive(true);
        StartCoroutine(ActiveTimer());
    }

    void PcInteractionMessage()
    {
        _timerCount = 3f;
        _chairPcObject.SetActive(false);
        _pcMessage.SetActive(true);
        StartCoroutine(ActiveTimer());
    }

    private IEnumerator ActiveTimer()
    {
        yield return new WaitForSeconds(_timerCount);
        if (_pcMessage.activeSelf)
            PcManager.instance.GoToWorkOnPc();
            
        _mirrorMessage.SetActive(false);
        _pcMessage.SetActive(false);
    }
}
