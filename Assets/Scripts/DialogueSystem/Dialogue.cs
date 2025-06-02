// using UnityEngine;

// [System.Serializable]
// public class Dialogue
// {
//     [TextArea]
//     public string Testo;

//     public int CurrentMessage;
//     public int Scena;
//     public LoreFlags loreFlags;
//     public int FinaliSbloccati;
//     public bool PC,
//         Mirror,
//         SoulTalk;

//     public bool CorrectDialogue(
//         int scenaCorrente,
//         int finaliAttuali,
//         string contestoAttuale,
//         ProgressManager pm
//     )
//     {
//         if (Scena != scenaCorrente)
//             return false;
//         if (FinaliSbloccati != finaliAttuali)
//             return false;

//         bool momentoValido =
//             (PC && contestoAttuale == "PC")
//             || (Mirror && contestoAttuale == "Mirror")
//             || (SoulTalk && contestoAttuale == "SoulTalk");

//         if (!momentoValido)
//             return false;

//         if (!loreFlags.IsCompatibleWith(pm))
//             return false;

//         return true;
//     }
// }

// [System.Serializable]
// public class LoreFlags
// {
//     public bool EternalCycle;
//     public bool NewPassNeed;
//     public bool GameOutOfGame;
//     public bool Fase1;
//     public bool Fase2;
//     public bool Fase3;

//     public bool IsCompatibleWith(ProgressManager pm)
//     {
//         if (EternalCycle && !pm.EternalCycle)
//             return false;
//         if (NewPassNeed && !pm.NewPassNeed)
//             return false;
//         if (GameOutOfGame && !pm.GameOutOfGame)
//             return false;
//         if (Fase1 && !pm.Fase1)
//             return false;
//         if (Fase2 && !pm.Fase2)
//             return false;
//         if (Fase3 && !pm.Fase3)
//             return false;

//         return true;
//     }
// }
