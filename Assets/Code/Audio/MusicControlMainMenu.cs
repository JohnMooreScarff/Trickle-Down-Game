using UnityEngine;

public class MusicControlMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Music_main_1);
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
