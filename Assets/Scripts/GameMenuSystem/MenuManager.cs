using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField]
    private GameObject _startButton;

    [SerializeField]
    private GameObject _startAgainButton;

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

    public SOProgressManager _soProgressManager;

    private void Start() => ButtonToStartGame();

    public void StartGame()
    {
        SceneManager.LoadScene("TheRoom");
        if (GameManager.instance.CycleNumber != 0)
            GameManager.instance.StartNewCycleOrNewGame();
    }

    public void ExitGame() => Application.Quit();

    public void OpenSecret() => _secretPanel.SetActive(!_secretPanel.activeSelf);

    public void OpenOptions() => _optionsPanel.SetActive(!_optionsPanel.activeSelf);

    void ButtonToStartGame()
    {
        if (_soProgressManager.CycleGame01Check() == false)
        {
            _startButton.SetActive(true);
            _startAgainButton.SetActive(false);
        }
        else
        {
            _startButton.SetActive(false);
            _startAgainButton.SetActive(true);
        }
    }
}
