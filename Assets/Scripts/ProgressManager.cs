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

    //Gestione dialoghi - bool dei CICLI e delle FASI
    public bool EternalCycle = false,
        NewPassNeed = false,
        GameOutOfGame = false,
        Fase1 = false,
        Fase2 = false,
        Fase3 = false;

    public int FinalUnlock = 0;

    public int SetFinalUnlock(int value) => FinalUnlock = value;
}
