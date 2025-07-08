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
    private GameObject[] _seasons;

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
    private GameObject _roomClueObjectPhase01_C; //Rivista e fogli sulla scrivania

    [SerializeField]
    private GameObject _instantFinishWorkButton; //Pulsante per finire il lavoro istantaneamente

    [SerializeField]
    private GameObject _roomClueObjectPhase02;

    [SerializeField]
    private GameObject _roomClueObjectPhase02_A;

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
    private SOProgressManager _soProgressManager;

    public void SetSeasonNumber() => _seasonNumberManager++;

    public void ResetSeasonNumber() => _seasonNumberManager = 1;

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
                break;
            case 3
            or 4:
                SetActiveSeasonOff();
                _summerObject.SetActive(true);
                break;
            case 5
            or 6:
                SetActiveSeasonOff();
                _springObject.SetActive(true);
                break;
            case 7
            or 8:
                SetActiveSeasonOff();
                _fallObject.SetActive(true);
                break;
        }
        SetSeasonNumber();
        if (_seasonNumberManager == 9)
            ResetSeasonNumber();

        Debug.LogWarning($"Season: {_seasonNumberManager}");
    }

    public void RoomAndCluesManager()
    {
        ProgressCluesManager();
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

    public void ProgressCluesManager()
    {
        if ( //Verifiche per attivare gli indizi della Phase 1
            _soProgressManager.Phase1Check() == true
            && _roomClueObjectPhase01.activeSelf
            && _soProgressManager.NewPassNeedCheck() == true
        )
        {
            _roomClueObjectPhase01_A.SetActive(true);
            if (
                _soProgressManager.GameOutOfGameCheck() == true
                && GameManager.instance.AwakeNumberScene >= 2
            )
            {
                _roomClueObjectPhase01_B.SetActive(true);
                _instantFinishWorkButton.SetActive(true);
            }
            if (GameManager.instance.AwakeNumberScene >= 4)
                _roomClueObjectPhase01_C.SetActive(true);
        }
    }
}
