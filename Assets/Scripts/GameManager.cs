using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        LoadProgressParameters();
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Start() => //Start provvisorio per "debug" cicli
        StartNewCycleOrNewGame();

    public void StartNewCycleOrNewGame()
    {
        if (_blackOverlay.gameObject.activeSelf == false)
            _blackOverlay.gameObject.SetActive(true);
        _playerPosition = _objectForRestartPosition.transform.position;
        ChangeDayScene(DaySceneState.day01);
    }

    [Header("UI Elements")]
    [SerializeField]
    private TextMeshProUGUI _daySceneUI;

    [SerializeField]
    private Image _blackOverlay;

    [SerializeField]
    private TextMeshProUGUI _workEndMessage;

    [SerializeField]
    private TextMeshProUGUI _deadGameOverMessage;

    [SerializeField]
    private float _fadeDuration = 2.5f;

    [SerializeField]
    private GameObject _restartButton;

    [Header("Cycles elements")]
    [SerializeField]
    private GameObject _playerObject;

    [SerializeField]
    private GameObject _objectForRestartPosition;

    [Header("SO Progress Manager")]
    [SerializeField]
    private SOProgressManager _soProgressManager;
    private Vector3 _playerPosition;

    //----------------------------------------------------------------------

    //Gestione awake-scene interno e dialoghi
    public DaySceneState DaySceneState;
    public int CycleNumber = 0,
        AwakeNumberScene = 0,
        PhaseManager = 0,
        FinalUnlock = 0;
    public bool DailyWorkDone = false;

    //----------------------------------------------------------------------

    public IEnumerator NextDayScene() //Gestione del NextDayScene, avvia un nuovo giorno
    {
        float timeToWait = 5f;
        switch (AwakeNumberScene)
        {
            case 0:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day01);
                break;
            case 1:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day02);
                break;
            case 2:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day03);
                break;
            case 3:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day04);
                break;
            case 4:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                if (CycleNumber == 0)
                    ChangeDayScene(DaySceneState.dead);
                else
                    ChangeDayScene(DaySceneState.day05);
                break;
            case 5:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day06);
                break;
            case 6:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day07);
                break;
            case 7:
                FadeIn();
                StartCoroutine(MessageWorkFinished());
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.day08);
                break;
            case 8:
                FadeIn();
                yield return new WaitForSeconds(timeToWait);
                ChangeDayScene(DaySceneState.dead);
                break;

            default:
                break;
        }
    }

    public void ChangeDayScene(DaySceneState newDaySceneState) //Controllo day-scene, avvia le cose dell'inizio del giorno
    {
        DaySceneState = newDaySceneState;
        DailyWorkDone = false;
        switch (newDaySceneState)
        {
            case DaySceneState.day01:
                _deadGameOverMessage.gameObject.SetActive(false);
                ScenarioProgressManager.instance.SeasonManager();
                if (AwakeNumberScene != 0)
                    SafeRestartPlayerPosition();
                FadeOut();
                AwakeNumberScene = 1;
                DayHelpMethod();
                break;
            case DaySceneState.day02:
                RestartDaySceneConfiguration();
                if (_soProgressManager.EternalCycleCheck() == true)
                    ScenarioProgressManager.instance.ActivationClueScenario(2);
                break;
            case DaySceneState.day03:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.day04:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.day05:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.day06:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.day07:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.day08:
                RestartDaySceneConfiguration();
                break;
            case DaySceneState.dead:
                //GameOver for this cycle
                Debug.LogWarning($"Game Over!");
                _deadGameOverMessage.gameObject.SetActive(true);
                _restartButton.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                AwakeNumberScene = 0;
                if (CycleNumber == 0)
                    NewCycle();
                break;

            default:
                Debug.Log($"Nessuna scena {newDaySceneState} trovata");
                break;
        }
    }

    void RestartDaySceneConfiguration()
    {
        SafeRestartPlayerPosition();
        FadeOut();
        AwakeNumberScene++;
        DayHelpMethod();
        WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
        ScenarioProgressManager.instance.SeasonManager();
        _soProgressManager.SaveProgressParameters(
            CycleNumber,
            PhaseManager,
            AwakeNumberScene,
            FinalUnlock
        );
    }

    public int GetDayScene() => AwakeNumberScene; //Get per sapere il giorno

    public void ControlForNextDayScene() //Metodo utilizzato nei button delle scene per controllare s'è possibile passare al giorno successivo
    {
        if (DailyWorkDone)
            StartCoroutine(NextDayScene());
    }

    public DaySceneState GetDaySceneEnum() => DaySceneState; //Get per sapere il daySceneState

    public void DailyWorkDoneMethod() => DailyWorkDone = !DailyWorkDone; //Aiuta con la gestione del Singleton in altri script

    public void DayHelpMethod() => //Gestisce testi DayScene e Cycle per i testi di debug
        _daySceneUI.text =
            "DayScene: "
            + AwakeNumberScene.ToString()
            + " -  "
            + "Cycle: "
            + CycleNumber.ToString()
            + " - "
            + "Phase: "
            + PhaseManager.ToString();

    public void SafeRestartPlayerPosition() => StartCoroutine(WaitAndResetPosition()); //Resetta posizione del player per il cambio dayScene

    private IEnumerator WaitAndResetPosition() //Gestisce il reset della posizione del player con le tempistiche ed il CharaterController
    {
        CharacterController cc = _playerObject.GetComponent<CharacterController>();
        cc.enabled = false;

        yield return null; // aspetta un frame per evitare conflitti

        _playerObject.transform.position = _playerPosition;

        yield return null; // ancora un frame per sicurezza
        cc.enabled = true;

        // Debug.LogWarning("Posizione player ripristinata (dopo delay)");
    }

    //Inizio Gestione fade------------
    public void FadeIn() => StartCoroutine(Fade(0f, 1f));

    public void FadeOut() => StartCoroutine(Fade(1f, 0f));

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color color = _blackOverlay.color;
        float elapsed = 0f;

        while (elapsed < _fadeDuration)
        {
            float t = elapsed / _fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            _blackOverlay.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        _blackOverlay.color = color;
    }

    //Fine Gestione fade------------

    public IEnumerator MessageWorkFinished() //Aiuta con la gestione del lavoro finito ed il passare al giorno successivo
    {
        _workEndMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _workEndMessage.gameObject.SetActive(false);
    }

    public IEnumerator ActiveTagPlayerForInteractions() //Gestisce tag player per evitare problemi con le collisioni
    {
        if (_playerObject.tag == "Player")
            _playerObject.tag = "PlayerOff";
        else
        {
            yield return new WaitForSeconds(5f);
            _playerObject.tag = "Player";
        }
    }

    public void CourutineBoxCollider() => StartCoroutine(ActiveTagPlayerForInteractions()); //Attivazione del metodo(che è un IEnumerator)

    public void NewCycle() => CycleNumber++;

    public void NewPhase() => PhaseManager++;

    public void RestartGame()
    {
        _soProgressManager.SaveProgressParameters(
            CycleNumber,
            PhaseManager,
            AwakeNumberScene,
            FinalUnlock
        );
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadProgressParameters()
    {
        CycleNumber = _soProgressManager.CycleNumber;
        PhaseManager = _soProgressManager.PhaseNumber;
        AwakeNumberScene = _soProgressManager.AwakeNumber;
        FinalUnlock = _soProgressManager.FinalUnlock;
    }

    public void ResetProgressParameters() => _soProgressManager.ResetAllParametersForDebugTest();

    //Metodi per l'attivazione di eventi in base al Cycle & Phase
}

public enum DaySceneState
{
    day01,
    day02,
    day03,
    day04,
    day05,
    day06,
    day07,
    day08,
    dead,
}
