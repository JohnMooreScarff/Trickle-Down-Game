using UnityEngine;

public class MusicControlFlood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.bubbles);
        AudioManager.Instance.Play(AudioManager.SoundType.Music_Menu_Water);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.button_click);
    }
}
