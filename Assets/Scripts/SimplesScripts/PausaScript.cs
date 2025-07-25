using UnityEngine;

public class PausaScript : MonoBehaviour
{
    [Header("Pausa Menu")]
    [SerializeField]
    private GameObject _menuPausa;

    [SerializeField]
    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PausaGame();
    }

    void PausaGame()
    {
        bool pausa = _menuPausa.activeSelf;
        _playerObject.GetComponent<PlayerMovement>().enabled = pausa;
        _menuPausa.SetActive(!pausa);
        Cursor.lockState = pausa ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
