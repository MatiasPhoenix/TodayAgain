using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkSpaceManager : MonoBehaviour
{
    [Header("Work Buttons")]
    [SerializeField]
    private GameObject _workButton1;

    [SerializeField]
    private GameObject _workButton2;

    [SerializeField]
    private GameObject _workButton3;

    [SerializeField]
    private GameObject _workButtonPlus;

    [SerializeField]
    private GameObject _workButtonMinus;

    [SerializeField]
    private GameObject _passButton;

    [Header("Text spaces")]
    [SerializeField]
    private TextMeshProUGUI _number1;

    [SerializeField]
    private TextMeshProUGUI _number2;

    [SerializeField]
    private TextMeshProUGUI _number3;

    [SerializeField]
    private TextMeshProUGUI _finalNumber;

    [Header("Current Set")]
    [SerializeField]
    private TextMeshProUGUI _currentSet1;

    [SerializeField]
    private TextMeshProUGUI _currentSet2;

    [SerializeField]
    private TextMeshProUGUI _currentSet3;

    [Header("Work Indicators")]
    [SerializeField]
    private TextMeshProUGUI _workRequest;

    [SerializeField]
    private GameObject _greatWorkMessage;

    [SerializeField]
    private GameObject _badWorkMessage;

    private WorkSpaceState _currentState;
    private int _number1Value = 0;
    private int _number2Value = 0;
    private int _number1Set = 0;
    private int _number2Set = 0;
    private int _number3Set = 0;
    private int _finalNumberSet = 0;
    private int _numberObjective;
    private List<int> _listNumbers = new List<int> { 11, 5, 7, 9, 6, 12, 8, 15 };
    private bool _workComplete = false;

    private void Start() => ChangeWorkSpaceState(WorkSpaceState.NumberSet1);

    public void ChangeWorkSpaceState(WorkSpaceState newWorkSpaceState)
    {
        switch (newWorkSpaceState)
        {
            case WorkSpaceState.NumberSet1:
                SetObjectiveNumber();
                _currentState = WorkSpaceState.NumberSet1;
                _number1Value = 0;
                _number2Value = 0;
                _number1Set = 0;
                _number2Set = 0;
                _number3Set = 0;
                _finalNumberSet = 0;
                _currentSet1.color = Color.green;
                break;
            case WorkSpaceState.NumberSet2:
                _currentState = WorkSpaceState.NumberSet2;
                _number1Value = 0;
                _number2Value = 0;
                _currentSet1.color = Color.black;
                _currentSet2.color = Color.green;
                break;
            case WorkSpaceState.NumberSet3:
                _currentState = WorkSpaceState.NumberSet3;
                _number1Value = 0;
                _number2Value = 0;
                _currentSet2.color = Color.black;
                _currentSet3.color = Color.green;
                break;
            case WorkSpaceState.FinalNumber:
                _currentSet3.color = Color.black;
                _currentState = WorkSpaceState.FinalNumber;
                _finalNumberSet = _number1Set + _number2Set + _number3Set;
                _finalNumber.text = _finalNumberSet.ToString();
                WorkCompleteOrNot();
                break;

            default:
                break;
        }
    }

    public void SetNumber(int number)
    {
        if (_currentState == WorkSpaceState.NumberSet1)
        {
            if (_number1Value != 0 && _number2Value != 0)
                return;
            if (_number1Value == 0)
                _number1.text = "";
            if (_number1Value == 0)
                _number1Value = number;
            else if (_number2Value == 0)
                _number2Value = number;
            _number1.text += number.ToString();
        }
        else if (_currentState == WorkSpaceState.NumberSet2)
        {
            if (_number1Value != 0 && _number2Value != 0)
                return;
            if (_number1Value == 0)
                _number2.text = "";
            if (_number1Value == 0)
                _number1Value = number;
            else
                _number2Value = number;
            _number2.text += number.ToString();
        }
        else if (_currentState == WorkSpaceState.NumberSet3)
        {
            if (_number1Value != 0 && _number2Value != 0)
                return;
            if (_number1Value == 0)
                _number3.text = "";
            if (_number1Value == 0)
                _number1Value = number;
            else
                _number2Value = number;
            _number3.text += number.ToString();
        }
    }

    public void PlusNumber()
    {
        if (_number1Value != 0 && _number2Value != 0)
            return;
        if (
            _currentState == WorkSpaceState.NumberSet1
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
            _number1.text += "+";
        else if (
            _currentState == WorkSpaceState.NumberSet2
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
            _number2.text += "+";
        else if (
            _currentState == WorkSpaceState.NumberSet3
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
            _number3.text += "+";
    }

    public void MinusNumber()
    {
        if (_number1Value != 0 && _number2Value != 0)
            return;
        if (
            _currentState == WorkSpaceState.NumberSet1
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
        {
            if (_number1.text.Contains("+"))
                _number1.text = _number1.text.Remove(_number1.text.Length - 1);

            _number1.text += "-";
        }
        else if (
            _currentState == WorkSpaceState.NumberSet2
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
        {
            if (_number2.text.Contains("+"))
                _number2.text = _number2.text.Remove(_number2.text.Length - 1);

            _number2.text += "-";
        }
        else if (
            _currentState == WorkSpaceState.NumberSet3
            && !_number1.text.Contains("+")
            && !_number1.text.Contains("-")
            && _number1Value != 0
        )
        {
            if (_number3.text.Contains("+"))
                _number3.text = _number3.text.Remove(_number3.text.Length - 1);

            _number3.text += "-";
        }
    }

    public void PassNumber()
    {
        if (_currentState == WorkSpaceState.NumberSet1 && _number1Value != 0)
        {
            if (_number1.text.Contains("+"))
            {
                int newNumber = _number1Value + _number2Value;
                _number1Set = newNumber;
                _number1.text = newNumber.ToString();
            }
            else if (_number1.text.Contains("-"))
            {
                int newNumber = _number1Value - _number2Value;
                _number1Set = newNumber;
                _number1.text = newNumber.ToString();
            }
            else
            {
                _number1Set = _number1Value;
                _number1.text = _number1Value.ToString();
            }
        }
        else if (_currentState == WorkSpaceState.NumberSet2 && _number1Value != 0)
        {
            if (_number2.text.Contains("+"))
            {
                int newNumber = _number1Value + _number2Value;
                _number2Set = newNumber;
                _number2.text = newNumber.ToString();
            }
            else if (_number2.text.Contains("-"))
            {
                int newNumber = _number1Value - _number2Value;
                _number2Set = newNumber;
                _number2.text = newNumber.ToString();
            }
            else
            {
                _number2Set = _number1Value;
                _number2.text = _number1Value.ToString();
            }
        }
        else if (_currentState == WorkSpaceState.NumberSet3 && _number1Value != 0)
        {
            if (_number3.text.Contains("+"))
            {
                int newNumber = _number1Value + _number2Value;
                _number3Set = newNumber;
                _number3.text = newNumber.ToString();
            }
            else if (_number3.text.Contains("-"))
            {
                int newNumber = _number1Value - _number2Value;
                _number3Set = newNumber;
                _number3.text = newNumber.ToString();
            }
            else
            {
                _number3Set = _number1Value;
                _number3.text = _number1Value.ToString();
            }
        }
    }

    public void PassToNextSet()
    {
        if (_currentState == WorkSpaceState.NumberSet1)
        {
            PassNumber();
            ChangeWorkSpaceState(WorkSpaceState.NumberSet2);
        }
        else if (_currentState == WorkSpaceState.NumberSet2)
        {
            PassNumber();
            ChangeWorkSpaceState(WorkSpaceState.NumberSet3);
        }
        else if (_currentState == WorkSpaceState.NumberSet3)
        {
            PassNumber();
            ChangeWorkSpaceState(WorkSpaceState.FinalNumber);
        }
    }

    public void WorkCompleteOrNot()
    {
        if (_currentState == WorkSpaceState.FinalNumber && _finalNumberSet == _numberObjective)
        {
            _workComplete = true;
            StartCoroutine(WorkFinished());
            Debug.Log("Work Complete!");
        }
        else
        {
            _workComplete = false;
            StartCoroutine(WorkFinished());
            Debug.Log("Work Not Complete!");
            ChangeWorkSpaceState(WorkSpaceState.NumberSet1);
        }
    }

    public void SetObjectiveNumber()
    {
        int randomNumber = _listNumbers[Random.Range(0, _listNumbers.Count)];
        _numberObjective = randomNumber;
        Debug.Log($"Objective Number: {randomNumber}");
        _workRequest.text = _numberObjective.ToString();
    }

    public IEnumerator WorkFinished()
    {
        if (_workComplete)
            _greatWorkMessage.SetActive(true);
        else
            _badWorkMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        _greatWorkMessage.SetActive(false);
        _badWorkMessage.SetActive(false);
    }
}

public enum WorkSpaceState
{
    NumberSet1,
    NumberSet2,
    NumberSet3,
    FinalNumber,
}
