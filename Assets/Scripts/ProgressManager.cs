using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

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

    //Gestione  progresso cycle, awake, phase, etc.
    public int CycleNumber = 0,
        PhaseNumber = 0,
        AwakeNumber = 0,
        FinalUnlock = 0;

    //Gestione dialoghi - bool dei CICLI e delle FASI
    public bool EternalCycle = false,
        NewPassNeed = false,
        GameOutOfGame = false,
        Fase1 = false,
        Fase2 = false,
        Fase3 = false;

    public int SetFinalUnlock(int value) => FinalUnlock = value;

    public void SaveProgressParameters(int cycle, int phase, int awake, int finalUnlock)
    {
        CycleNumber = cycle;
        PhaseNumber = phase;
        AwakeNumber = awake;
        FinalUnlock = finalUnlock;
        Debug.LogWarning(
            $"Cycle: {CycleNumber}, Phase: {PhaseNumber}, Awake: {AwakeNumber}, FinalUnlock: {FinalUnlock}"
        );
    }
}
