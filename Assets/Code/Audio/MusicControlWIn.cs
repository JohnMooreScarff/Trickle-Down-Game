using UnityEngine;
using System.Collections;

public class MusicControlWln : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Music_Menu_Win);
        StartCoroutine(PlayFireworksRepeatedly());
    }

    IEnumerator PlayFireworksRepeatedly()
    {
        while (true)
        {
            AudioManager.Instance.Play(AudioManager.SoundType.Fireworks);
            yield return new WaitForSeconds(Random.Range(0.2f,0.4f));
        }
    }

    public void Onclick()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.button_click);
    }
}
