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
                        new List<string> { "sto na' merda...", "mmh", "dovrei farmi la barba" }
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
                            "adesso 'completare il lavoro' sarà veloce...",
                            "leggi le email",
                            "nel prossimo risveglio... novità",
                            "lui l'ha sempre odiato",
                            "ricordo quel giorno...",
                        }
                    },
                    {
                        Topic.Computer,
                        new List<string> { "prova soul computer" }
                    },
                    {
                        Topic.Mirror,
                        new List<string> { "prova soul mirror" }
                    },
                    {
                        Topic.Chair,
                        new List<string> { "prova soul chair" }
                    },
                    {
                        Topic.Email,
                        new List<string> { "adesso capirai alcune cose" }
                    },
                    {
                        Topic.MetaGame,
                        new List<string> { "prova soul chair" }
                    },
                    {
                        Topic.SoulComment,
                        new List<string> { "commento dell'anima, semplice prova" }
                    }
                }
            },
        };

    public static string GetDialogue(Speaker speaker, Topic topic, int index)
    {
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
