using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsPanel : MonoBehaviour, IEnabled
{
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private AudioSource _soundManager;
    [SerializeField] private Slider _volumeMusicSlider;
    [SerializeField] private Slider _volumeSoundSlider;
    [SerializeField] private Button _nextSongButton;
    [SerializeField] private Button _previousSongButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Text _songName;

    private void Awake()
    {
        _quitButton.onClick.AddListener(() => gameObject.SetActive(false));
        _musicManager.songChanged += (name) => _songName.text = name;
    }

    void Start()
    {
        if (StaticInfo.gameState != null)
            LoadState(StaticInfo.gameState.SettingsInfo);

        _volumeMusicSlider.onValueChanged.AddListener((value) => SetMusicVolume(value));
        _volumeSoundSlider.onValueChanged.AddListener((value) => SetSoundVolume(value));

        UIController.AddUIObject(this.gameObject.name, this);
        Disable();
    }

    public void SetMusicVolume(float value)
    {
        _musicManager.GetAudioSource.volume = value;
        StaticInfo.gameState.SettingsInfo.musicVolume = value;
        Debug.Log(StaticInfo.gameState.SettingsInfo.musicVolume);
    }
    public void SetSoundVolume(float value)
    {
        _soundManager.volume = value;
        StaticInfo.gameState.SettingsInfo.soundVolume = value;
    }

    public void Disable()
        => gameObject.SetActive(false);

    public void Enable()
        => gameObject.SetActive(true);

    public void LoadState(SettingsInfo info)
    {
        if (info == null)
        {
            StaticInfo.gameState.SettingsInfo = new SettingsInfo();
            return;
        }    
        _volumeMusicSlider.value = info.musicVolume;
        _musicManager.GetAudioSource.volume = info.musicVolume;
        _volumeSoundSlider.value = info.soundVolume;
        _soundManager.volume = info.soundVolume;
    }
}
