using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    public static BGM instance;
    [SerializeField] private AudioClip _bgmClip;
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private float _bgmVolume;

    public bool isDestroyOnLoad;


    private void Awake()
    {
        if (isDestroyOnLoad) return;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        SetBGMVolume(_bgmVolume);

        _bgmSource.Play();

        if (isDestroyOnLoad) return;
        DontDestroyOnLoad(gameObject);
    }


    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = volume;
    }

    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    public void PlayBGM()
    {
        _bgmSource.Play();
    }

    public void UnpauseBGM()
    {

        _bgmSource.UnPause();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public void DestroyBGMGameObject()
    {
        Destroy(gameObject);
    }
}