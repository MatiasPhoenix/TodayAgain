using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCodeManager : MonoBehaviour
{
    [SerializeField]
    private Light _morseLight;

    [SerializeField]
    private float _unitTime = 1f;

    private Dictionary<char, string> _morseCode = new Dictionary<char, string>()
    {
        { 'A', ".-" },
        { 'B', "-..." },
        { 'C', "-.-." },
        { 'D', "-.." },
        { 'E', "." },
        { 'F', "..-." },
        { 'G', "--." },
        { 'H', "...." },
        { 'I', ".." },
        { 'J', ".---" },
        { 'K', "-.-" },
        { 'L', ".-.." },
        { 'M', "--" },
        { 'N', "-." },
        { 'O', "---" },
        { 'P', ".--." },
        { 'Q', "--.-" },
        { 'R', ".-." },
        { 'S', "..." },
        { 'T', "-" },
        { 'U', "..-" },
        { 'V', "...-" },
        { 'W', ".--" },
        { 'X', "-..-" },
        { 'Y', "-.--" },
        { 'Z', "--.." },
        { ' ', " " },
    };

    public void StartMorse(string message)
    {
        StartCoroutine(PlayMorse(message.ToUpper()));
    }

    private IEnumerator PlayMorse(string message)
    {
        foreach (char c in message)
        {
            if (_morseCode.TryGetValue(c, out string code))
            {
                if (code == " ")
                {
                    yield return new WaitForSeconds(_unitTime * 7); // spazio tra parole
                    continue;
                }

                foreach (char symbol in code)
                {
                    _morseLight.enabled = true;

                    if (symbol == '.')
                        yield return new WaitForSeconds(_unitTime);
                    else if (symbol == '-')
                        yield return new WaitForSeconds(_unitTime * 3);

                    _morseLight.enabled = false;
                    yield return new WaitForSeconds(_unitTime); // pausa tra simboli
                }

                yield return new WaitForSeconds(_unitTime * 2); // pausa tra lettere (3 unità in totale, 1 già fatta sopra)
            }
        }
    }
}
