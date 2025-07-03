using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _optionsButton;

    [SerializeField]
    private GameObject _exitButton;

    [SerializeField]
    private GameObject _secretButton;

    [Header("Menu Panels/Windows")]
    [SerializeField]
    private GameObject _optionsPanel;

    [SerializeField]
    private GameObject _secretPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("TheRoom");
        if (GameManager.instance.CycleNumber != 0)
            GameManager.instance.StartNewCycleOrNewGame();
    }

    public void ExitGame() => Application.Quit();

    public void OpenSecret() => _secretPanel.SetActive(!_secretPanel.activeSelf);

    public void OpenOptions() => _optionsPanel.SetActive(!_optionsPanel.activeSelf);
}
