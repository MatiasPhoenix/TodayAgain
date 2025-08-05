using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _mouseSensitivity = 100f;

    [SerializeField]
    private Transform _cameraHolder; // asse X per il pitch

    [SerializeField]
    private float _minPitch = -60f;

    [SerializeField]
    private float _maxPitch = 60f;

    [Header("Animation")]
    [SerializeField]
    private Animator _animator; // collega l'Animator (contiene isWalking)

    private float _pitch = 0f; // rotazione verticale
    private CharacterController _characterController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();

        if (_cameraHolder == null)
            Debug.LogWarning("CameraHolder non assegnato!");

        if (_animator == null)
            Debug.LogWarning("Animator non assegnato!");
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        UpdateAnimation();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // movimento relativo al facing del player (yaw)
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        moveDirection.y = 0f;

        _characterController.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // yaw: ruota il corpo sul Y
        transform.Rotate(Vector3.up * mouseX);

        // pitch: ruota la camera sull'asse X, con clamp
        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

        if (_cameraHolder != null)
            _cameraHolder.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }

    private void UpdateAnimation()
    {
        if (_animator == null)
            return;

        // considera "camminare" se c'è input sui due assi
        bool isWalking = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
        _animator.SetBool("isWalking", isWalking);
    }
}
