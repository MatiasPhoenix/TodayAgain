using UnityEngine;

public class ScenarioProgressManager : MonoBehaviour
{
    public static ScenarioProgressManager instance;

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


    [Header("Outside scenarios")]
    [SerializeField] private GameObject _winterObject;
    [SerializeField] private GameObject _summerObject;
    [SerializeField] private GameObject _springObject;
    [SerializeField] private GameObject _fallObject;
    [SerializeField] private GameObject _winterClueObject1;
    [SerializeField] private GameObject _winterClueObject2;
    [SerializeField] private GameObject _summerClueObject1;
    [SerializeField] private GameObject _summerClueObject2;
    [SerializeField] private GameObject _springClueObject1;
    [SerializeField] private GameObject _springClueObject2;
    [SerializeField] private GameObject _fallClueObject1;
    [SerializeField] private GameObject _fallClueObject2;


    [Header("Room scenario")]
    [SerializeField] private GameObject _roomObject;
    [SerializeField] private GameObject _roomClueObject1;
    [SerializeField] private GameObject _roomClueObject2;
    [SerializeField] private GameObject _roomClueObject3;


    [Header("Bathroom")]
    [SerializeField] private GameObject _bathroomObject;
    [SerializeField] private GameObject _bathroomClueObject1;
    [SerializeField] private GameObject _bathroomClueObject2;
    [SerializeField] private GameObject _bathroomClueObject3;
}
