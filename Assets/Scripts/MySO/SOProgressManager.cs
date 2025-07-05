using UnityEngine;

[CreateAssetMenu(fileName = "SOProgressManager", menuName = "Data/SOProgressManager")]
public class SOProgressManager : ScriptableObject
{
    //Gestione  progresso cycle, awake, phase, etc.
    public int CycleNumber = 0,
        PhaseNumber = 0,
        AwakeNumber = 0,
        FinalUnlock = 0;

    //Gestione dialoghi - bool dei CICLI e delle FASI
    public bool EternalCycle = false,
        NewPassNeed = false,
        GameOutOfGame = false,
        Phase1 = false,
        Phase2 = false,
        Phase3 = false;

    public void SaveProgressParameters(int cycle, int phase, int awake, int finalUnlock) //Salva tutti i parametri con il progredire del gioco, usando come riferimento il GameManager
    {
        CycleNumber = cycle;
        PhaseNumber = phase;
        AwakeNumber = awake;
        FinalUnlock = finalUnlock;
        Debug.LogWarning(
            $"Cycle: {CycleNumber}, Phase: {PhaseNumber}, Awake: {AwakeNumber}, FinalUnlock: {FinalUnlock}"
        );
    }

    //Metodi per modificare e verificare i bool degli eventi chiave------------
    public void EternalCycleTrue() => EternalCycle = true;

    public void NewPassNeedTrue() => NewPassNeed = true;

    public void GameOutOfGameTrue() => GameOutOfGame = true;

    public void Phase1True() => Phase1 = true;

    public void Phase2True() => Phase2 = true;

    public void Phase3True() => Phase3 = true;

    public bool EternalCycleCheck() => EternalCycle;

    public bool NewPassNeedCheck() => NewPassNeed;

    public bool GameOutOfGameCheck() => GameOutOfGame;

    public bool Phase1Check() => Phase1;

    public bool Phase2Check() => Phase2;

    public bool Phase3Check() => Phase3;

    //-------------------------------------------------------------------------

    public void ResetAllParametersForDebugTest() //Resetta tutti i parametri, per il debug
    {
        CycleNumber = 0;
        PhaseNumber = 0;
        AwakeNumber = 0;
        FinalUnlock = 0;
        EternalCycle = false;
        NewPassNeed = false;
        GameOutOfGame = false;
        Phase1 = false;
        Phase2 = false;
        Phase3 = false;
    }
}
