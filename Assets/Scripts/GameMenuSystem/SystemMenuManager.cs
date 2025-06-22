using System.Collections;
using UnityEngine;

public class SystemMenuManager : MonoBehaviour
{
    [Header("System Enigmas")]
    [SerializeField]
    private Light _monitorLight;

    [SerializeField]
    private float _startIntensityMonitorLight;

    [SerializeField]
    private float _endIntensityMonitorLight;

    [SerializeField]
    private float _durationIntensityMonitorLight;

    private void Start()
    {
        StartCoroutine(LightIntensityLoop());
    }

    private IEnumerator LightIntensityLoop()
    {
        while (true)
        {
            yield return WhileForLightIntensityIncrese();
            yield return WhileForLightIntensityDecrese();
        }
    }

    public IEnumerator WhileForLightIntensityIncrese()
    {
        float elapsed = 0f;
        while (elapsed < _durationIntensityMonitorLight)
        {
            _monitorLight.intensity = Mathf.Lerp(
                _startIntensityMonitorLight,
                _endIntensityMonitorLight,
                elapsed / _durationIntensityMonitorLight
            );
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator WhileForLightIntensityDecrese()
    {
        float elapsed = 0f;
        while (elapsed < _durationIntensityMonitorLight)
        {
            _monitorLight.intensity = Mathf.Lerp(
                _endIntensityMonitorLight,
                _startIntensityMonitorLight,
                elapsed / _durationIntensityMonitorLight
            );
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
