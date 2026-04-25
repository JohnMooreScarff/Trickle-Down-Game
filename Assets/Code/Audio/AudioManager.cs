using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        palce, place_2, error, bubbles, button_click,
        Music_Menu_Main, Music_Menu_Water, Music_Menu_Bankrupt, Music_Menu_Win,
        Music_main_1, Music_main_2, Music_main_3, Music_main_4, Music_main_5,
        win_effect, loose_bankrupt_effect, loose_flood_effect, Fireworks
    }

    [System.Serializable]
    public class Sound
    {
        public SoundType Type;
        public AudioClip Clip;
        [Range(0f, 1f)] public float Volume = 1f;

        // New bool to control volume adjustment per sound
        public bool adjustVolumeByCameraSize = false;

        [HideInInspector] public AudioSource Source;
    }

    public static AudioManager Instance;

    public Sound[] AllSounds;
    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();
    
    private AudioSource _musicSource;
    private Sound _currentMusicTrack;

    [Header("Camera Zoom Settings")]
    public Camera orthographicCamera;
    public float minCameraSize = 5f;
    public float maxCameraSize = 20f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
    }

    private void Update()
    {
        if (_musicSource != null && _musicSource.isPlaying && _currentMusicTrack != null)
        {
            if (_currentMusicTrack.adjustVolumeByCameraSize)
            {
                _musicSource.volume = CalculateAdjustedVolume(_currentMusicTrack.Volume);
            }
            else
            {
                _musicSource.volume = _currentMusicTrack.Volume;
            }
        }
    }

    private float CalculateAdjustedVolume(float originalVolume)
    {
        if (orthographicCamera == null) 
            return originalVolume;

        float zoomPercent = Mathf.InverseLerp(maxCameraSize, minCameraSize, orthographicCamera.orthographicSize);
        float multiplier = Mathf.Lerp(0.3f, 1.0f, zoomPercent); 
        return originalVolume * multiplier;
    }

    public void Play(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound s)) return;

        GameObject soundObj = new GameObject($"Temp_SFX_{type}");
        AudioSource audioSrc = soundObj.AddComponent<AudioSource>();

        audioSrc.clip = s.Clip;

        if (s.adjustVolumeByCameraSize)
            audioSrc.volume = CalculateAdjustedVolume(s.Volume);
        else
            audioSrc.volume = s.Volume;
        
        audioSrc.Play();
        Destroy(soundObj, s.Clip.length);
    }

    public void ChangeMusic(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound track)) return;

        if (_musicSource == null)
        {
            GameObject container = new GameObject("MusicSource");
            container.transform.SetParent(this.transform);
            _musicSource = container.AddComponent<AudioSource>();
            _musicSource.loop = true;
        }

        _currentMusicTrack = track;

        if (track.adjustVolumeByCameraSize)
            _musicSource.volume = CalculateAdjustedVolume(track.Volume);
        else
            _musicSource.volume = track.Volume;

        _musicSource.clip = track.Clip;
        _musicSource.Play();
    }
    private Coroutine _fadeCoroutine;

    public float musicFadeDuration = 2f; // Duration of fade in seconds

    // Call this method to change music with a smooth fade transition
    public void ChangeMusicWithFade(SoundType newTrackType)
    {
        if (!_soundDictionary.TryGetValue(newTrackType, out Sound newTrack))
        {
            Debug.LogWarning($"Music track {newTrackType} not found!");
            return;
        }

        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(FadeMusicRoutine(newTrack));
    }

    private IEnumerator FadeMusicRoutine(Sound newTrack)
    {
        if (_musicSource == null)
        {
            GameObject container = new GameObject("MusicSource");
            container.transform.SetParent(this.transform);
            _musicSource = container.AddComponent<AudioSource>();
            _musicSource.loop = true;
        }

        // Fade out current music
        float startVolume = _musicSource.volume;
        float time = 0f;
        while (time < musicFadeDuration)
        {
            time += Time.deltaTime;
            _musicSource.volume = Mathf.Lerp(startVolume, 0f, time / musicFadeDuration);
            yield return null;
        }

        // Switch to new music clip
        _musicSource.clip = newTrack.Clip;
        _currentMusicTrack = newTrack;
        _musicSource.Play();

        // Fade in new music
        time = 0f;
        while (time < musicFadeDuration)
        {
            time += Time.deltaTime;
            _musicSource.volume = Mathf.Lerp(0f, newTrack.Volume, time / musicFadeDuration);
            yield return null;
        }

        _musicSource.volume = newTrack.Volume;
    }
}
