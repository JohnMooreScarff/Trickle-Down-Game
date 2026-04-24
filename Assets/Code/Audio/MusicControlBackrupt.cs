using UnityEngine;

public class MusicControlBackrupt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Music_Menu_Bankrupt);
        AudioManager.Instance.Play(AudioManager.SoundType.loose_bankrupt_effect);
        AudioManager.Instance.Play(AudioManager.SoundType.Music_main_2);
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
