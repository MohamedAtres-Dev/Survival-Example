using UnityEngine;

[CreateAssetMenu(fileName ="AudioManager" , menuName = "Singltons/Game Managers/Audio Manager")]
public class AudioManager : ScriptableObject
{
    //private static AudioManager _instance;
    //public AudioManager Instance
    //{
    //    get
    //    {
    //        return _instance;
    //    }
    //}
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    //private static void Init()
    //{
    //    _instance = Resources.Load<AudioManager>("AudioManager");
    //}

    private AudioSource _audio;

    public AudioSource Audio { get => _audio; set => _audio = value; }

    public void PlaySound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }

}
