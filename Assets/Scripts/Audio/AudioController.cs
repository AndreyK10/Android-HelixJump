using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void PlayButtonSound()
    {
        AudioManager.instance.PlaySound(AudioManager.BUTTON_SOUND);
    }
    public void MuteMusic()
    {
        AudioManager.instance.MuteMusic(AudioManager.BGMUSIC);
    }

    public void MuteSound()
    {
        AudioManager.instance.MuteSound(AudioManager.WIN_SOUND, AudioManager.LOSE_SOUND, AudioManager.BUTTON_SOUND);
    }
}