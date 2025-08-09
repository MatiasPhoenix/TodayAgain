using UnityEngine;

public class ScenarioProgressManager : MonoBehaviour
{
    public static ScenarioProgressManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        _seasons = new GameObject[] { _winterObject, _summerObject, _springObject, _fallObject };
    }

    [Header("Outside scenarios")]
    [SerializeField]
    private GameObject _winterObject;

    [SerializeField]
    private GameObject _summerObject;

    [SerializeField]
    private GameObject _springObject;

    [SerializeField]
    private GameObject _fallObject;

    [SerializeField]
    private GameObject _fallTreeObject;
    private GameObject[] _seasons;
    private Color _basicColor = new Color(1f, 1f, 1f, 1f);
    private Color _fallColor = new Color(1f, 0.45f, 0f, 1f);

    // [SerializeField] private GameObject _winterClueObject1;
    // [SerializeField] private GameObject _winterClueObject2;
    // [SerializeField] private GameObject _summerClueObject1;
    // [SerializeField] private GameObject _summerClueObject2;
    // [SerializeField] private GameObject _springClueObject1;
    // [SerializeField] private GameObject _springClueObject2;
    // [SerializeField] private GameObject _fallClueObject1;
    // [SerializeField] private GameObject _fallClueObject2;

    [Header("Room scenario")]
    // [SerializeField] private GameObject _roomObject;
    [SerializeField]
    private GameObject _roomClueObjectPhase01;

    [SerializeField]
    private GameObject _roomClueObjectPhase01_A; //Piatti, bicchiere, bottiglia

    [SerializeField]
    private GameObject _roomClueObjectPhase01_B; //Postit, biglietti da visita(num. binari)

    [SerializeField]
    private GameObject[] _roomClueObjectPhase01_C; //Email nuove

    [SerializeField]
    private GameObject[] _roomClueObjectPhase01_D; //Siti sul browser

    [SerializeField]
    private GameObject _instantFinishWorkButton; //Pulsante per finire il lavoro istantaneamente

    [SerializeField]
    private GameObject _roomClueObjectPhase02;

    [SerializeField]
    private GameObject _roomClueObjectPhase02_A; //Rivista e fogli sulla scrivania

    [SerializeField]
    private GameObject _roomClueObjectPhase02_B;

    [SerializeField]
    private GameObject _roomClueObjectPhase02_C;

    [SerializeField]
    private GameObject _roomClueObjectPhase03;

    [SerializeField]
    private GameObject _roomClueObjectPhase03_A;

    [SerializeField]
    private GameObject _roomClueObjectPhase03_B;

    [SerializeField]
    private GameObject _roomClueObjectPhase03_C;

    // [Header("Bathroom")]
    // [SerializeField] private GameObject _bathroomObject;
    // [SerializeField] private GameObject _bathroomClueObject1;
    // [SerializeField] private GameObject _bathroomClueObject2;
    // [SerializeField] private GameObject _bathroomClueObject3;

    private int _seasonNumberManager = 1;
    public SOProgressManager _soProgressManager;

    private void Start() => FallTextureForTrees();

    public void SetSeasonNumber() => _seasonNumberManager++;

    public void ResetSeasonNumber() => _seasonNumberManager = 1;

    public int GetSeasonNumber() => _seasonNumberManager;

    public void MySeasonChoice(int seasonNumber) => _seasonNumberManager = seasonNumber;

    void SetActiveSeasonOff()
    {
        foreach (GameObject season in _seasons)
            season.SetActive(false);
    }

    public void SeasonManager()
    {
        switch (_seasonNumberManager)
        {
            case 1
            or 2:
                SetActiveSeasonOff();
                _winterObject.SetActive(true);
                FallTextureForTrees();
                Debug.LogWarning($"Season: WINTER");
                break;
            case 3
            or 4:
                SetActiveSeasonOff();
                _summerObject.SetActive(true);
                FallTextureForTrees();
                Debug.LogWarning($"Season: SUMMER");
                break;
            case 5
            or 6:
                SetActiveSeasonOff();
                _springObject.SetActive(true);
                FallTextureForTrees();
                Debug.LogWarning($"Season: SPRING");
                break;
            case 7
            or 8:
                SetActiveSeasonOff();
                _fallObject.SetActive(true);
                FallTextureForTrees();
                Debug.LogWarning($"Season: FALL");
                break;
        }
        SetSeasonNumber();
        if (_seasonNumberManager == 9)
            ResetSeasonNumber();
    }

    public void RoomAndCluesManager()
    {
        ProgressCluesManagerCycle1();
        switch (GameManager.instance.PhaseManager)
        {
            case 1:
                _roomClueObjectPhase01.SetActive(true);
                break;
            case 2:
                _roomClueObjectPhase02.SetActive(true);
                break;
            case 3:
                _roomClueObjectPhase03.SetActive(true);
                break;
            default:
                Debug.Log(
                    $"Phase: {GameManager.instance.PhaseManager}, senza niente da poter attivare."
                );
                break;
        }
    }

    public void ProgressCluesManagerCycle1()
    {
        Debug.LogWarning($"---Verificando attivazione indizi---");
        if ( //Verifiche per attivare gli indizi della Phase 1
            _soProgressManager.Phase1Check() == true
            && _soProgressManager.NewPassNeedCheck() == true
        )
        {
            _roomClueObjectPhase01_A.SetActive(true);

            if (
                _soProgressManager.GameOutOfGameCheck() == true
                && _soProgressManager.AwakeNumber >= 2
            )
            {
                _roomClueObjectPhase01_B.SetActive(true);
            }

            if (_soProgressManager.InstantWorkButton == true)
                _instantFinishWorkButton.SetActive(true);

            if (
                _soProgressManager.GameOutOfGameCheck() == true
                && _soProgressManager.AwakeNumber >= 3
                && _soProgressManager.EmailAfterMetaGame == true
                && _roomClueObjectPhase01_C[0].activeSelf == false
            )
            {
                foreach (GameObject roomClueObjectPhase01_C in _roomClueObjectPhase01_C)
                    roomClueObjectPhase01_C.SetActive(true);
                PcManager.instance.AlertIconActivation(0, true);
            }

            if (
                _soProgressManager.GameOutOfGameCheck() == true
                && _soProgressManager.AwakeNumber >= 4
                && _roomClueObjectPhase01_D[0].activeSelf == false
            )
            {
                foreach (GameObject roomClueObjectPhase01_D in _roomClueObjectPhase01_D)
                    roomClueObjectPhase01_D.SetActive(true);
                PcManager.instance.AlertIconActivation(1, true);
            }
        }
    }

    void FallTextureForTrees()
    {
        Renderer rend = _fallTreeObject.GetComponent<Renderer>();

        if (_fallObject.activeSelf)
            rend.sharedMaterial.SetColor("_BaseColor", _fallColor);
        else
            rend.sharedMaterial.SetColor("_BaseColor", _basicColor);
    }

    public void InstantActiveAllCluesCycle1()
    {
        _roomClueObjectPhase01_A.SetActive(true);
        _roomClueObjectPhase01_B.SetActive(true);
        _roomClueObjectPhase01_C[0].SetActive(true);
        _roomClueObjectPhase01_C[1].SetActive(true);
        _roomClueObjectPhase01_D[0].SetActive(true);
        _roomClueObjectPhase01_D[1].SetActive(true);
    }
}
