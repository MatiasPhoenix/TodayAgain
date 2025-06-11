using UnityEngine;

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

    //Gestione dialoghi
    public int DayScene = 0;

    //Gestione day-scene interno
    public DaySceneState DaySceneState;
    public int CycleNumber = 0;
    public bool DailyWorkDone = false;

    //Controllo day-scene per la gestione delle interazioni
    public void ChangeDayScene(DaySceneState newDaySceneState)
    {
        DaySceneState = newDaySceneState;
        switch (newDaySceneState)
        {
            case DaySceneState.day01:
                DayScene = 1;
                break;
            case DaySceneState.day02:
                DayScene = 2;
                break;
            case DaySceneState.day03:
                DayScene = 3;
                break;
            case DaySceneState.day04:
                DayScene = 4;
                break;
            case DaySceneState.day05:
                DayScene = 5;
                break;
            case DaySceneState.day06:
                DayScene = 6;
                break;
            case DaySceneState.day07:
                DayScene = 7;
                break;
            case DaySceneState.day08:
                DayScene = 8;
                break;
            case DaySceneState.day09:
                DayScene = 9;
                break;
            case DaySceneState.day10:
                DayScene = 10;
                break;

            default:
                Debug.Log($"Nessuna scena {newDaySceneState} trovata");
                break;
        }
    }
    
    public void DailyWorkDoneMethod() => DailyWorkDone = !DailyWorkDone;
    public DaySceneState GetDaySceneEnum() => DaySceneState;
    public int GetDayScene() => DayScene;
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
    day09,
    day10,
}
