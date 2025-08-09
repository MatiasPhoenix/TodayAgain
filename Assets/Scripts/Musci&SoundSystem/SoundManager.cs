using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource[] _audioSources;

    [Header("Sounds Clips")]
    [SerializeField]
    private AudioClip[] _characterTalkSounds;

    [SerializeField]
    private AudioClip[] _computerSounds;
    [SerializeField]
    private AudioClip[] _keyboardAndMouseSounds;

    [SerializeField]
    private AudioClip[] _extraSounds;

    [SerializeField]
    private AudioClip[] _messageAlertSounds;

    public void StopMusic(int index) => _audioSources[index].Stop();

    public void PlayMusic(int index) => _audioSources[index].Play();

    public void PlayTalkSound(int audioSourceNumber, int soundNumber) =>
        _audioSources[audioSourceNumber].PlayOneShot(_characterTalkSounds[soundNumber]);

    public void PlayComputerSound(int audioSourceNumber, int soundNumber) =>
        _audioSources[audioSourceNumber].PlayOneShot(_computerSounds[soundNumber]);

    public void PlayKeyboardAndMouseSound(int audioSourceNumber, int soundNumber) =>
        _audioSources[audioSourceNumber].PlayOneShot(_keyboardAndMouseSounds[soundNumber]);

    public void PlayExtraSound(int audioSourceNumber, int soundNumber) => _audioSources[audioSourceNumber].PlayOneShot(_extraSounds[soundNumber]);

    public void PlayMessageAlertSound(int audioSourceNumber, int soundNumber) =>
        _audioSources[audioSourceNumber].PlayOneShot(_messageAlertSounds[soundNumber]);

    public bool IsPlaying(int audioSourceNumber) => _audioSources[audioSourceNumber].isPlaying;
}
