using UnityEngine;

public class MusicControlWln
 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.Play(AudioManager.SoundType.Music_Menu_Win);
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
