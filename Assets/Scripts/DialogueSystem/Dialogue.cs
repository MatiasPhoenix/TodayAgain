using System.Collections.Generic;

public static class Dialogue
{
    // struttura: Speaker -> Topic -> lista di frasi
    private static readonly Dictionary<Speaker, Dictionary<Topic, List<string>>> _dialogues =
        new Dictionary<Speaker, Dictionary<Topic, List<string>>>()
        {
            {
                Speaker.Programmer,
                new Dictionary<Topic, List<string>>()
                {
                    {
                        Topic.Room,
                        new List<string> { "prova room" }
                    },
                    {
                        Topic.Computer,
                        new List<string>
                        {
                            "Oggi lavoro sugli script",
                            "Provo a correggere il bug di ieri",
                            "Dov'ero rimasto?",
                            "Non so come funzionerà... ci provo",
                            "Dopo mi faccio un'altro caffè",
                        }
                    },
                    {
                        Topic.Mirror,
                        new List<string> { "Sto na' merda...", "Mmh", "Dovrei farmi la barba" }
                    },
                    {
                        Topic.Chair,
                        new List<string> { "prova chair" }
                    },
                }
            },
            {
                Speaker.Soul,
                new Dictionary<Topic, List<string>>()
                {
                    {
                        Topic.Room,
                        new List<string>
                        {
                            "finalmente riesci a sentirmi",
                            "leggi le email",
                            "nel prossimo risveglio... novità",
                            "lui l'ha sempre odiato",
                            "ricordo quel giorno...",
                        }
                    },
                    {
                        Topic.Computer,
                        new List<string>
                        {
                            "ora cominci a vedere",
                            "leggi le email",
                            "le persone parlano tanto",
                            "adesso 'completare il lavoro' sarà più facile...",
                            "da qui tutto cambia, inizierai a capire molto di più, spero tu sia pronto...",
                        }
                    },
                    {
                        Topic.Mirror,
                        new List<string> { "prova soul mirror" }
                    },
                    {
                        Topic.Chair,
                        new List<string> { "........" }
                    },
                    {
                        Topic.Email,
                        new List<string>
                        {
                            "adesso capirai alcune cose",
                            "indizi, fuori...",
                            "e da qui andrai oltre il nostro limite...",
                        }
                    },
                    {
                        Topic.MetaGame,
                        new List<string> { "prova soul chair" }
                    },
                    {
                        Topic.SoulComment,
                        new List<string>
                        {
                            "non temere, questa non è la fine",
                            "hai visto come passa il tempo?",
                            "credevi che questo fosse solo un gioco, vero?",
                            "hai viso la scrivania? che pena questa situazione...",
                            "tranquillo, la fine di ogni ciclo ti aiuterà a capire meglio",
                        }
                    },
                }
            },
        };

    public static string GetDialogue(Speaker speaker, Topic topic, int index)
    {
        if (speaker == Speaker.Soul)
            SoundManager.Instance.PlayTalkSound(2, 2);
        else
            SoundManager.Instance.PlayTalkSound(2, 0);

        if (!_dialogues.TryGetValue(speaker, out var topicDict))
            return $"Missing speaker: {speaker}";

        if (!topicDict.TryGetValue(topic, out var lines))
            return $"Missing topic: {topic} for speaker {speaker}";

        if (index < 0 || index >= lines.Count)
            return $"Invalid dialogue index: {index} for {speaker}/{topic}";

        return lines[index];
    }
}

public enum Speaker
{
    Programmer,
    Soul,
}

public enum Topic
{
    Room,
    Computer,
    Mirror,
    Chair,
    Email,
    MetaGame,
    SoulComment,
}
