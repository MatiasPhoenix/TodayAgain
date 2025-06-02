using UnityEngine;

public class PcManager : MonoBehaviour
{
    public static PcManager instance;

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

    [Header("PC Components")]
    [SerializeField]
    private GameObject _pcObject;

    [SerializeField]
    private GameObject _cameraPcObject;

    [SerializeField]
    private GameObject _playerObject;

    [Header("PC Windows components")]
    [SerializeField]
    private GameObject _windowMyComputer;

    [SerializeField]
    private GameObject _windowNetwork;

    [SerializeField]
    private GameObject _windowReadme;

    [SerializeField]
    private GameObject _windowFolder;

    [SerializeField]
    private GameObject _windowsTerminal;

    [SerializeField]
    private GameObject _windowsStartButton;

    public void GoToWorkOnPc()
    {
        _pcObject.SetActive(true);
        _cameraPcObject.SetActive(true);
        _playerObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitFromPc()
    {
        _pcObject.SetActive(false);
        _cameraPcObject.SetActive(false);
        _playerObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        ClickToOpenAndCloseWindow("Start");
    }

    public void ClickToOpenAndCloseWindow(string nameWindow)
    {
        switch (nameWindow)
        {
            case "MyComputer":
                if (_windowMyComputer.activeSelf)
                    _windowMyComputer.SetActive(false);
                else
                    _windowMyComputer.SetActive(true);
                break;
            case "Network":
                if (_windowNetwork.activeSelf)
                    _windowNetwork.SetActive(false);
                else
                    _windowNetwork.SetActive(true);
                break;
            case "Readme":
                if (_windowReadme.activeSelf)
                    _windowReadme.SetActive(false);
                else
                    _windowReadme.SetActive(true);
                break;
            case "Folder":
                if (_windowFolder.activeSelf)
                    _windowFolder.SetActive(false);
                else
                    _windowFolder.SetActive(true);
                break;
            case "Terminal":
                if (_windowsTerminal.activeSelf)
                    _windowsTerminal.SetActive(false);
                else
                    _windowsTerminal.SetActive(true);
                break;
            case "Start":
                if (_windowsStartButton.activeSelf)
                    _windowsStartButton.SetActive(false);
                else
                    _windowsStartButton.SetActive(true);
                break;

            default:
                Debug.LogWarning($"There is no window with the name {nameWindow}");
                break;
        }
    }
}
