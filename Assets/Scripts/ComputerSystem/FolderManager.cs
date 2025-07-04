using UnityEngine;

public class FolderManager : MonoBehaviour
{
    [Header("Files Icons")]
    [SerializeField]
    private GameObject _iconWindowFolder;

    [SerializeField]
    private GameObject _caesarCodeFileWindow;

    [SerializeField]
    private GameObject _atbashCodeFileWindow;

    [SerializeField]
    private GameObject _pigpenCodeFileWindow;

    [SerializeField]
    private GameObject _polybiusCodeFileWindow;

    [SerializeField]
    private GameObject _kvadrugCodeFileWindow;

    [SerializeField]
    private GameObject _chatCodeFileWindow;

    public void OpenFileWindow(string fileName)
    {
        if (_iconWindowFolder.activeSelf == false)
            _iconWindowFolder.SetActive(true);
        else
            _iconWindowFolder.SetActive(false);
        switch (fileName)
        {
            case "CaesarCode":
                if (_caesarCodeFileWindow.activeSelf == false)
                    _caesarCodeFileWindow.SetActive(true);
                else
                    _caesarCodeFileWindow.SetActive(false);
                break;

            case "AtbashCode":
                if (_atbashCodeFileWindow.activeSelf == false)
                    _atbashCodeFileWindow.SetActive(true);
                else
                    _atbashCodeFileWindow.SetActive(false);
                break;

            case "PigpenCode":
                if (_pigpenCodeFileWindow.activeSelf == false)
                    _pigpenCodeFileWindow.SetActive(true);
                else
                    _pigpenCodeFileWindow.SetActive(false);
                break;

            case "PolybiusCode":
                if (_polybiusCodeFileWindow.activeSelf == false)
                    _polybiusCodeFileWindow.SetActive(true);
                else
                    _polybiusCodeFileWindow.SetActive(false);
                break;

            case "KvadrugCode":
                if (_kvadrugCodeFileWindow.activeSelf == false)
                    _kvadrugCodeFileWindow.SetActive(true);
                else
                    _kvadrugCodeFileWindow.SetActive(false);
                break;

            case "ChatWindow":
                if (_chatCodeFileWindow.activeSelf == false)
                    _chatCodeFileWindow.SetActive(true);
                else
                    _chatCodeFileWindow.SetActive(false);
                break;

            default:
                Debug.Log("File not found---");
                break;
        }
    }

    public void CloseWindowAndReturnToFolder()
    {
        _iconWindowFolder.SetActive(true);
        _caesarCodeFileWindow.SetActive(false);
        _atbashCodeFileWindow.SetActive(false);
        _pigpenCodeFileWindow.SetActive(false);
        _polybiusCodeFileWindow.SetActive(false);
        _kvadrugCodeFileWindow.SetActive(false);
        _chatCodeFileWindow.SetActive(false);
    }
}
