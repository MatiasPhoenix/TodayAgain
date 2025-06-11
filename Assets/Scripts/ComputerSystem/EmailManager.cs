using UnityEngine;

public class EmailManager : MonoBehaviour
{
    [Header("Emails Windows")]
    [SerializeField] private GameObject[] _emailsBodys;

    public void OpenEmail(int index)
    {
        for (int i = 0; i < _emailsBodys.Length; i++)
            _emailsBodys[i].SetActive(false);
        _emailsBodys[index].SetActive(true);
    }

}
