using UnityEngine;
using UnityEngine.UI;

public class ForumScript : MonoBehaviour
{
    [Header("Forum")]
    [SerializeField]
    private RawImage _pageObjectForBrowser;

    [SerializeField]
    private Texture[] _browserPages;

    [SerializeField]
    private GameObject _forumButtonsForNavigation;
    

    public void BrowserPagesManager(int indexPage)
    {
        switch (indexPage)
        {
            case 0:
                _pageObjectForBrowser.texture = _browserPages[0];
                _forumButtonsForNavigation.SetActive(false);
                break;
            case 1:
                _pageObjectForBrowser.texture = _browserPages[1];
                _forumButtonsForNavigation.SetActive(false);
                break;
            case 2:
                _pageObjectForBrowser.texture = _browserPages[2];
                _forumButtonsForNavigation.SetActive(false);
                break;
            case 3:
                _pageObjectForBrowser.texture = _browserPages[3];
                _forumButtonsForNavigation.SetActive(false);
                break;
            default:
                Debug.Log($"There is no page with the index {indexPage}");
                break;
        }
    }
}
