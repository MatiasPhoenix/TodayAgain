using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FootstepController : MonoBehaviour
{
    [Header("Footstep Clips")]
    [SerializeField]
    private AudioClip[] _footstepClips; // i tuoi 8 clip

    [Header("Settings")]
    [SerializeField]
    private float _baseStepInterval = 0.5f; // tempo base tra i passi quando si cammina a velocità normale

    [SerializeField]
    private float _stepIntervalSpeedMultiplier = 1f; // scala con la velocità

    [SerializeField]
    private float _minPitch = 0.95f;

    [SerializeField]
    private float _maxPitch = 1.05f;

    [SerializeField]
    private float _minVolume = 0.8f;

    [SerializeField]
    private float _maxVolume = 1f;

    private CharacterController _charController;
    private AudioSource _audioSource;
    private float _stepTimer = 0f;
    private int _lastClipIndex = -1;

    void Awake()
    {
        _charController = GetComponent<CharacterController>();
        _audioSource = GetComponentInChildren<AudioSource>();
        if (_audioSource == null)
            Debug.LogError("Devi assegnare un AudioSource figlio per i passi.");
    }

    void Update()
    {
        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        // controlla se stai camminando (proiezione sul piano, ignore vertical)
        Vector3 horizontalVelocity = new Vector3(
            _charController.velocity.x,
            0f,
            _charController.velocity.z
        );
        float speed = horizontalVelocity.magnitude;

        bool isMoving = speed > 0.1f; // soglia per evitare micro-movimenti

        if (isMoving)
        {
            // calibra intervallo: più veloce = passi più ravvicinati
            float interval = _baseStepInterval / (1f + (speed * _stepIntervalSpeedMultiplier));

            _stepTimer += Time.deltaTime;
            if (_stepTimer >= interval)
            {
                PlayFootstep();
                _stepTimer = 0f;
            }
        }
        else
        {
            _stepTimer = 0f; // reset se fermo
        }
    }

    private void PlayFootstep()
    {
        if (_footstepClips == null || _footstepClips.Length == 0)
            return;

        int index = GetRandomClipIndex();
        AudioClip clip = _footstepClips[index];
        _lastClipIndex = index;

        _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.volume = Random.Range(_minVolume, _maxVolume);
        _audioSource.PlayOneShot(clip);
    }

    private int GetRandomClipIndex()
    {
        if (_footstepClips.Length == 1)
            return 0;

        int idx = Random.Range(0, _footstepClips.Length);
        if (idx == _lastClipIndex)
        {
            // evita ripetizione immediata: prendi il successivo (wrap)
            idx = (idx + 1) % _footstepClips.Length;
        }
        return idx;
    }
}
