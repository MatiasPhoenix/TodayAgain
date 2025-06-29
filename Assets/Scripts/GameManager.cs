using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    void Start() //Start provvisorio per "debug" cicli
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

    [Header("Cycles elements")]
    [SerializeField]
    private GameObject _playerObject;

    [SerializeField]
    private GameObject _objectForRestartPosition;
    private Vector3 _playerPosition;

    //----------------------------------------------------------------------

    //Gestione dialoghi
    public int DayScene = 0;

    //Gestione day-scene interno
    public DaySceneState DaySceneState;
    public int CycleNumber = 0;
    public bool DailyWorkDone = false;

    //----------------------------------------------------------------------


    public IEnumerator NextDayScene() //Gestione del NextDayScene, avvia un nuovo giorno
    {
        float timeToWait = 5f;
        switch (DayScene)
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
                if (DayScene != 0)
                    SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 1;
                DayHelpMethod();
                break;
            case DaySceneState.day02:
                RestartDaySceneConfiguration();
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
        DayScene++;
        DayHelpMethod();
        WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
    }

    public int GetDayScene() => DayScene; //Get per sapere il giorno

    public void ControlForNextDayScene() //Metodo utilizzato nei button delle scene per controllare s'è possibile passare al giorno successivo
    {
        if (DailyWorkDone)
        StartCoroutine(NextDayScene());
    }

    public DaySceneState GetDaySceneEnum() => DaySceneState; //Get per sapere il daySceneState

    public void DailyWorkDoneMethod() => DailyWorkDone = !DailyWorkDone; //Aiuta con la gestione del Singleton in altri script

    public void DayHelpMethod() => //Gestisce testi DayScene e Cycle per i testi di debug
        _daySceneUI.text =
            "DayScene: " + DayScene.ToString() + " -  " + "Cycle: " + CycleNumber.ToString();

    public void SafeRestartPlayerPosition() => StartCoroutine(WaitAndResetPosition()); //Resetta posizione del player per il cambio dayScene

    private IEnumerator WaitAndResetPosition() //Gestisce il reset della posizione del player con le tempistiche ed il CharaterController
    {
        CharacterController cc = _playerObject.GetComponent<CharacterController>();
        cc.enabled = false;

        yield return null; // aspetta un frame per evitare conflitti

        _playerObject.transform.position = _playerPosition;

        yield return null; // ancora un frame per sicurezza
        cc.enabled = true;

        Debug.LogWarning("Posizione player ripristinata (dopo delay)");
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
