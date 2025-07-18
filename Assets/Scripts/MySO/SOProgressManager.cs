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

    //Gestione dei cicli della storia per la gestione dei progressi
    public bool CycleGame01 = false,
        CycleGame02 = false,
        CycleGame03 = false,
        CycleGame04 = false;

    //Gestione degli elementi InGame sbloccati con il progresso della storia
    //Elementi che devono essere attivi nelle run successive
    public bool EmailAfterMetaGame = false, //Cycle1-
        InstantWorkButton = false, //Cycle1-
        WebSite1Cycle1 = false, //Cycle1-
        WebSite2Cycle1 = false, //Cycle1-
        AllCluesCycle1Found = false; //Cycle1-

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

    //Metodi per i cicli della storia--------------------------
    public void CycleGame01True() => CycleGame01 = true;

    public bool CycleGame01Check() => CycleGame01;

    public void CycleGame02True() => CycleGame02 = true;

    public bool CycleGame02Check() => CycleGame02;

    public void CycleGame03True() => CycleGame03 = true;

    public bool CycleGame03Check() => CycleGame03;

    public void CycleGame04True() => CycleGame04 = true;

    public bool CycleGame04Check() => CycleGame04;

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

    public bool CheckCluesCycle1()
    {
        if (
            EmailAfterMetaGame == true
            && InstantWorkButton == true
            && WebSite1Cycle1 == true
            && WebSite2Cycle1 == true
        )
            return true;
        else
            return false;
    }
}
