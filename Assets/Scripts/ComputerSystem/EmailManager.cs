using UnityEngine;

public class EmailManager : MonoBehaviour
{
    [Header("Emails Windows")]
    [SerializeField]
    private GameObject[] _emailsBodys;

    public SOProgressManager _soProgressManager;

    public void OpenEmail(int index)
    {
        if (index == 4 && _soProgressManager.GameOutOfGameCheck() == false)
            StartCoroutine(DialogueManager.Instance.DialogueSoulAndTimer("Email", 2, 1));

        for (int i = 0; i < _emailsBodys.Length; i++)
            _emailsBodys[i].SetActive(false);
        _emailsBodys[index].SetActive(true);
    }
}
