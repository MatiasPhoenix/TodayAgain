using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryTasks : MonoBehaviour
{
    [Header("Primary elements")]
    [SerializeField]
    private GameObject _passwordMenu;

    [SerializeField]
    private TMP_InputField _passwordInput;
    private string _password = "12abc";

    [SerializeField]
    private GameObject _errorMessage;

    [SerializeField]
    private GameObject _programWindow;

    [Header("Color Elements")]
    [SerializeField]
    private GameObject _goodAnswer;

    [SerializeField]
    private GameObject _badAnswer;

    [SerializeField]
    private GameObject _missColorAnswer;

    [SerializeField]
    private Image _finalColor;

    [SerializeField]
    private TextMeshProUGUI _passColorSolutionOnScreen;

    private int _firstColor = 0;
    private int _secondColor = 0;

    //Gestione dei colori per la configurazione delle password del secondary task
    private Color _orangeColor = new Color32(255, 128, 0, 255);
    private Color _violetColor = new Color32(128, 0, 128, 255);
    private Color _greenColor = Color.green;
    public string _passColorSolution = "";

    public void CheckPassword()
    {
        string playerText = _passwordInput.text;
        if (playerText == _password)
        {
            _passwordMenu.SetActive(false);
            _programWindow.SetActive(true);
        }
        else
            StartCoroutine(ShowErrorMessage());
    }

    public IEnumerator ShowErrorMessage()
    {
        _errorMessage.SetActive(true);
        yield return new WaitForSeconds(1f);
        _errorMessage.SetActive(false);
    }

    public void CloseProgramWindow()
    {
        _programWindow.SetActive(false);
        _passwordMenu.SetActive(true);
    }

    public void AddColor(int colorNumber)
    {
        if (colorNumber == 4)
        {
            _finalColor.color = Color.white;
            _firstColor = 0;
            _secondColor = 0;
            return;
        }

        if (_firstColor == 0)
        {
            _firstColor = colorNumber;
            _finalColor.color = GetColorFromNumber(colorNumber);
            return;
        }

        if (_secondColor == 0)
        {
            _secondColor = colorNumber;
            _finalColor.color = GetMixedColor(_firstColor, _secondColor);
        }
    }

    private Color GetColorFromNumber(int number)
    {
        return number switch
        {
            1 => Color.red,
            2 => Color.yellow,
            3 => Color.blue,
            _ => Color.white,
        };
    }

    private Color GetMixedColor(int first, int second)
    {
        if ((first == 1 && second == 2) || (first == 2 && second == 1))
            return new Color32(255, 128, 0, 255);

        if ((first == 1 && second == 3) || (first == 3 && second == 1))
            return new Color32(128, 0, 128, 255);

        if ((first == 2 && second == 3) || (first == 3 && second == 2))
            return Color.green;

        return Color.white;
    }

    public IEnumerator ShowAnswer(int numberAnswer)
    {
        switch (numberAnswer)
        {
            case 1:
                _goodAnswer.SetActive(true);
                yield return new WaitForSeconds(1f);
                _goodAnswer.SetActive(false);
                break;
            case 2:
                _badAnswer.SetActive(true);
                yield return new WaitForSeconds(1f);
                _badAnswer.SetActive(false);
                break;
            case 3:
                _missColorAnswer.SetActive(true);
                yield return new WaitForSeconds(1f);
                _missColorAnswer.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void ChooseColorForPassword()
    {
        if (_passColorSolution.Length < 4)
        {
            if (_finalColor.color == _orangeColor)
                _passColorSolution += "1";
            else if (_finalColor.color == _violetColor)
                _passColorSolution += "2";
            else if (_finalColor.color == _greenColor)
                _passColorSolution += "3";
            else if (_finalColor.color == Color.red)
                _passColorSolution += "4";
            else if (_finalColor.color == Color.yellow)
                _passColorSolution += "5";
            else if (_finalColor.color == Color.blue)
                _passColorSolution += "6";
            else if (_finalColor.color == Color.white)
            {
                ResetPassword();
                VisiblePasswordOnScreenReset();
                return;
            }

            VisiblePasswordOnScreen();
            Debug.LogWarning($"La password è: {_passColorSolution}");
        }
        else
            Debug.LogWarning($"Password esaurita");
    }

    public void PasswordColorVerification()
    {
        ResetPassword();
        VisiblePasswordOnScreenReset();
    }

    public void ResetPassword() => _passColorSolution = "";

    public void VisiblePasswordOnScreen() => _passColorSolutionOnScreen.text += "*";

    public void VisiblePasswordOnScreenReset() => _passColorSolutionOnScreen.text = "--";

    public void CancelLastNumber()
    {
        _passColorSolution = _passColorSolution.Remove(_passColorSolution.Length - 1, 1);

        _passColorSolutionOnScreen.text = _passColorSolutionOnScreen.text.Remove(
            _passColorSolutionOnScreen.text.Length - 1,
            1
        );
        PasswordColorVerification();
    }
}
