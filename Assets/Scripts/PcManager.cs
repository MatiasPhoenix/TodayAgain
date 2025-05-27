using UnityEngine;

public class PcManager : MonoBehaviour
{
    public static PcManager instance;

    private void Awake(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    [Header("PC Components")]
    [SerializeField] private GameObject _pcObject;
    [SerializeField] private GameObject _cameraPcObject;
    [SerializeField] private GameObject _playerObject;

    [Header("PC Windows components")]
    [SerializeField] private GameObject _iconMyComputer;
    [SerializeField] private GameObject _iconNetwork;
    [SerializeField] private GameObject _iconReadme;
    [SerializeField] private GameObject _iconFolder;
    [SerializeField] private GameObject _programWindows;

    public void GoToWorkOnPc()
    {
        _pcObject.SetActive(true);
        _cameraPcObject.SetActive(true);
        _playerObject.SetActive(false);
    }
    public void ExitFromPc()
    {
        _pcObject.SetActive(false);
        _cameraPcObject.SetActive(false);
        _playerObject.SetActive(true);
    }
    public void ClickOnIcon()
        _programWindows.SetActive(true);

    public void CloseWindow()
        _programWindows.SetActive(false);
}
