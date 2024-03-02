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

    //Function yang di panggil pada saat game dijalankan
    private void Awake()
    {
        //Singkatnya kode dibawah ini di implement untuk membuat gameobject dengan script ini menjadi tetap ada setiap perpindahan scene (gameobject akan hilang setelah perpindahan scene bila code ini tidak ada)
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

    //Function yang terpanggil bila game dimulai, tepatnya setelah awake
    private void Start()
    {
        //Intialize music BGM dengan bgm yg diinginkan,setting, dan volume
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        SetBGMVolume(_bgmVolume);

        _bgmSource.Play();

        if (isDestroyOnLoad) return;
        DontDestroyOnLoad(gameObject);
    }

    //Function untuk set volume bgm
    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = volume;
    }

    //Function untuk pause bgm
    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    //Function untuk memainkan bgm
    public void PlayBGM()
    {
        _bgmSource.Play();
    }

    //Function untuk unpause bgm
    public void UnpauseBGM()
    {

        _bgmSource.UnPause();
    }

    //Function untuk stop bgm
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    //Function untuk menghancurkan gameobject bgm
    public void DestroyBGMGameObject()
    {
        Destroy(gameObject);
    }
}