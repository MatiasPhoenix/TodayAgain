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
    private DaySceneManager _daySceneManager;

    //Controllo day-scene per la gestione delle interazioni
    public void ChangeDayScene(DaySceneManager newDaySceneManager)
    {
        _daySceneManager = newDaySceneManager;
        switch (newDaySceneManager)
        {
            case DaySceneManager.day01:
                DayScene = 1;
                break;
            case DaySceneManager.day02:
                DayScene = 2;
                break;
            case DaySceneManager.day03:
                DayScene = 3;
                break;
            case DaySceneManager.day04:
                DayScene = 4;
                break;
            case DaySceneManager.day05:
                DayScene = 5;
                break;
            case DaySceneManager.day06:
                DayScene = 6;
                break;
            case DaySceneManager.day07:
                DayScene = 7;
                break;
            case DaySceneManager.day08:
                DayScene = 8;
                break;
            case DaySceneManager.day09:
                DayScene = 9;
                break;
            case DaySceneManager.day10:
                DayScene = 10;
                break;

            default:
                Debug.Log($"Nessuna scena {newDaySceneManager} trovata");
                break;
        }
    }
    
    public DaySceneManager GetDayScene() => _daySceneManager;
    

    

}

public enum DaySceneManager
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
