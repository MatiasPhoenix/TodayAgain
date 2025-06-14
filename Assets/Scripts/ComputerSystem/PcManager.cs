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
    [SerializeField] private GameObject _pcMasterObject;
    [SerializeField] private GameObject _pcObjectCycle00;
    [SerializeField] private GameObject _pcDesktopCycle00;
    [SerializeField] private GameObject _pcObjectCycle01;
    [SerializeField] private GameObject _pcDesktopCycle01;
    [SerializeField] private GameObject _pcObjectCycle02;
    [SerializeField] private GameObject _pcDesktopCycle02;
    [SerializeField] private GameObject _pcObjectCycle03;
    [SerializeField] private GameObject _pcDesktopCycle03;
    [SerializeField] private GameObject _cameraPcObject;
    [SerializeField] private GameObject _playerObject;

    [Header("PC Components Cycle 00")]
    [SerializeField] private GameObject _windowSystemWork;
    [SerializeField] private GameObject _windowSecondaryTasks;
    [SerializeField] private GameObject _windowNetwork;
    [SerializeField] private GameObject _windowsEmail;
    [SerializeField] private GameObject _windowReadme;
    [SerializeField] private GameObject _windowFolder;
    [SerializeField] private GameObject _windowsTerminal;
    [SerializeField] private GameObject _windowsStartButton;

    public void GoToWorkOnPc()
    {
        _pcMasterObject.SetActive(true);
        switch (GameManager.instance.CycleNumber)
        {
            case 0:
                _pcObjectCycle00.SetActive(true);
                _pcDesktopCycle00.SetActive(true);
                break;
            case 1:
                _pcObjectCycle01.SetActive(true);
                _pcDesktopCycle01.SetActive(true);
                break;
            case 2:
                _pcObjectCycle02.SetActive(true);
                _pcDesktopCycle02.SetActive(true);
                break;
            case 3:
                _pcObjectCycle03.SetActive(true);
                _pcDesktopCycle03.SetActive(true);
                break;
            default:
                break;
        }
        _cameraPcObject.SetActive(true);
        _playerObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
        

    public void ExitFromPc()
    {
        GameManager.instance.CourutineBoxCollider();
        _pcObjectCycle00.SetActive(false);
        _pcObjectCycle01.SetActive(false);
        _pcObjectCycle02.SetActive(false);
        _pcObjectCycle03.SetActive(false);
        _pcDesktopCycle00.SetActive(false);
        _pcDesktopCycle01.SetActive(false);
        _pcDesktopCycle02.SetActive(false);
        _pcDesktopCycle03.SetActive(false);
        _pcMasterObject.SetActive(false);
        _cameraPcObject.SetActive(false);
        _playerObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        ClickToOpenAndCloseWindow("Start");
    }

    public void ClickToOpenAndCloseWindow(string nameWindow)
    {
        switch (nameWindow)
        {
            case "SystemWork":
                if (_windowSystemWork.activeSelf)
                    _windowSystemWork.SetActive(false);
                else
                    _windowSystemWork.SetActive(true);
                break;
            case "SecondaryTasks":
                if (_windowSecondaryTasks.activeSelf)
                    _windowSecondaryTasks.SetActive(false);
                else
                    _windowSecondaryTasks.SetActive(true);
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
            case "Email":
                if (_windowsEmail.activeSelf)
                    _windowsEmail.SetActive(false);
                else
                    _windowsEmail.SetActive(true);
                break;

            default:
                Debug.LogWarning($"There is no window with the name {nameWindow}");
                break;
        }
    }
}
