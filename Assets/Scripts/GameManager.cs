using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

    //Gestione dialoghi
    public int DayScene = 0;

    [Header("UI Elements")]
    [SerializeField]
    private TextMeshProUGUI _daySceneUI;

    [SerializeField]
    private Image _blackOverlay;

    [SerializeField]
    private TextMeshProUGUI _workEndMessage;

    [SerializeField]
    private float _fadeDuration = 2.5f;

    [Header("Cycles elements")]
    [SerializeField]
    private GameObject _playerObject;

    [SerializeField]
    private GameObject _objectForRestartPosition;
    private Vector3 _playerPosition;

    //Gestione day-scene interno
    public DaySceneState DaySceneState;
    public int CycleNumber = 0;
    public bool DailyWorkDone = false;

    //Controllo day-scene per la gestione delle interazioni
    public void ChangeDayScene(DaySceneState newDaySceneState)
    {
        DaySceneState = newDaySceneState;
        DailyWorkDone = false;
        switch (newDaySceneState)
        {
            case DaySceneState.day01:
                if (DayScene != 0)
                    SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 1;
                DayHelpMethod();
                break;
            case DaySceneState.day02:
                SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 2;
                DayHelpMethod();
                WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
                break;
            case DaySceneState.day03:
                SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 3;
                DayHelpMethod();
                WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
                break;
            case DaySceneState.day04:
                SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 4;
                DayHelpMethod();
                WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
                break;
            case DaySceneState.day05:
                SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 5;
                DayHelpMethod();
                WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
                break;
            case DaySceneState.day06:
                SafeRestartPlayerPosition();
                FadeOut();
                DayScene = 6;
                DayHelpMethod();
                WorkSpaceManager.instance.ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
                break;

            default:
                Debug.Log($"Nessuna scena {newDaySceneState} trovata");
                break;
        }
    }

    public void DailyWorkDoneMethod() => DailyWorkDone = !DailyWorkDone;

    public DaySceneState GetDaySceneEnum() => DaySceneState;

    public IEnumerator NextDayScene()
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
                yield return new WaitForSeconds(5f);
                ChangeDayScene(DaySceneState.day01);
                break;

            default:
                break;
        }
    }

    public int GetDayScene() => DayScene;

    public void DayHelpMethod() => _daySceneUI.text = "DayScene: " + DayScene.ToString();

    public void SafeRestartPlayerPosition()
    {
        StartCoroutine(WaitAndResetPosition());
    }

    private IEnumerator WaitAndResetPosition()
    {
        CharacterController cc = _playerObject.GetComponent<CharacterController>();
        cc.enabled = false;

        yield return null; // aspetta un frame per evitare conflitti

        _playerObject.transform.position = _playerPosition;

        yield return null; // ancora un frame per sicurezza
        cc.enabled = true;

        Debug.LogWarning("Posizione player ripristinata (dopo delay)");
    }

    public void ControlForNextDay()
    {
        if (DailyWorkDone == true)
            StartCoroutine(NextDayScene());
    }

    //Gestione fade
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

    public IEnumerator MessageWorkFinished()
    {
        _workEndMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _workEndMessage.gameObject.SetActive(false);
    }

    public IEnumerator ActiveTagPlayerForInteractions()
    {
        if (_playerObject.tag == "Player")
            _playerObject.tag = "PlayerOff";
        else
        {
            yield return new WaitForSeconds(5f);
            _playerObject.tag = "Player";
        }
    }
    public void CourutineBoxCollider() => StartCoroutine(ActiveTagPlayerForInteractions());
}

public enum DaySceneState
{
    day01,
    day02,
    day03,
    day04,
    day05,
    day06,
}
