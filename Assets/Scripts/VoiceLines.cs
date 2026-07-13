using TMPro;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [SerializeField] string[] TimelineTextLines;
    [SerializeField] TMP_Text VoiceLineText;
    int CurrentVoiceLine = 0; 

    public void NextVoiceLine()
    {
        CurrentVoiceLine++;
        VoiceLineText.text = TimelineTextLines[CurrentVoiceLine];
    }
}
