using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    [Header("GameObject Element")]
    [SerializeField]
    private GameObject _elementToActivate;

    public void ActivateOrDeactivateElement()
    {
        bool active = _elementToActivate.activeSelf;
        _elementToActivate.SetActive(!active);
    }
}
