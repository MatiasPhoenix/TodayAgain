using System.Collections;
using UnityEngine;

public class LogoPresentationScript : MonoBehaviour
{
    [Header("Logo Presentation")]
    public GameObject BlackScreen;
    public GameObject LogoPublisher1;
    public GameObject LogoPublisher2;
    public GameObject LogoDeveloperTime;

    private void Start() => StartCoroutine(IntroductionLogo());

    IEnumerator IntroductionLogo()
    {
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        LogoPublisher1.SetActive(true);
        yield return new WaitForSeconds(3f);
        LogoPublisher1.SetActive(false);
        LogoPublisher2.SetActive(true);
        yield return new WaitForSeconds(3f);
        LogoPublisher2.SetActive(false);
        LogoDeveloperTime.SetActive(true);
        yield return new WaitForSeconds(4f);
        LogoDeveloperTime.SetActive(false);
        BlackScreen.SetActive(false);
    }
}
