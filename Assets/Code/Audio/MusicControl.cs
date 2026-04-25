using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private bool isDecreasingTrackPlaying = false;
    private AudioManager.SoundType currentTrack = (AudioManager.SoundType)(-1);

    private float pollution = 0f;

    void Start()
    {
        PlayTrackBasedOnPollution();
    }

    void Update()
    {
        PlayTrackBasedOnPollution();
    }

    private void PlayTrackBasedOnPollution()
    {
        AudioManager.SoundType newTrack;
        pollution = ResourceData.Pollution;

        if (pollution < 33f)
            newTrack = AudioManager.SoundType.Music_main_1;
        else if (pollution < 66f)
            newTrack = AudioManager.SoundType.Music_main_2;
        else
            newTrack = AudioManager.SoundType.Music_main_3;

        if (newTrack != currentTrack)
        {
            currentTrack = newTrack;
            AudioManager.Instance.ChangeMusicWithFade(newTrack);
        }
    }

    public void Onclick()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.button_click);
    }
}
