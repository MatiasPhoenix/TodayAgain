public static class Dialogue
{
    public static string DialoguesMetod(int numberSpeaker, int enumDialogue)
    {
        //numberSpeaker: 0 = Programmer, 1 = Soul
        //enumDialogue: 0 = Programmer, 1 = Soul

        if (numberSpeaker == 0) //Programmer parla
        {
            switch (enumDialogue) //quale dialogo si attiva
            { //scelto il dialogo si attiva direttamente chi lo dice in base al altro parametro
                case 1:
                    return DialogueProgrammer(DialogueEnumProgrammer.Room);

                case 2:
                    return DialogueProgrammer(DialogueEnumProgrammer.Computer);

                case 3:
                    return DialogueProgrammer(DialogueEnumProgrammer.Mirror);

                case 4:
                    return DialogueProgrammer(DialogueEnumProgrammer.Chair);

                default:
                    return "Default";
            }
        }
        else //Soul parla
        {
            switch (enumDialogue) //quale dialogo si attiva
            { //scelto il dialogo si attiva direttamente chi lo dice in base al altro parametro
                case 1:
                    return DialogueSoul(DialogueEnumSoul.SoulRoom);

                case 2:
                    return DialogueSoul(DialogueEnumSoul.SoulComputer);

                case 3:
                    return DialogueSoul(DialogueEnumSoul.SoulMirror);

                case 4:
                    return DialogueSoul(DialogueEnumSoul.SoulChair);

                default:
                    return "Default";
            }
        }
    }

    static string DialogueProgrammer(DialogueEnumProgrammer dialogueEnumProgrammer)
    {
        return "Programmer";
    }
    static string DialogueSoul(DialogueEnumSoul dialogueEnumSoul)
    {
        return "Soul";
    }
}

enum DialogueEnumProgrammer
{
    Room,
    Computer,
    Mirror,
    Chair,
}

enum DialogueEnumSoul
{
    SoulRoom,
    SoulComputer,
    SoulMirror,
    SoulChair,
}
