using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // 静态实例
    private static AudioManager instance;

    // 公共属性，用于访问实例
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {

                instance = FindObjectOfType<AudioManager>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject("AudioManager");
                    instance = singleton.AddComponent<AudioManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    // 音频剪辑
    public AudioClip birdCollison;
    public AudioClip birdSelect;
    public AudioClip birdFlying;
    public AudioClip[] pigCollisons;
    public AudioClip woodCollision;
    public AudioClip woodDestoryed;


    // 播放音效方法
    public void PlayBirdCollison(Vector3 position)
    {
        PlaySound(birdCollison, position, 1f);
    }

    public void PlayBirdSelect(Vector3 position)
    {
        PlaySound(birdSelect, position, 1f);
    }

    public void PlayBirdFlying(Vector3 position)
    {
        PlaySound(birdFlying, position, 1f);
    }

    public void PlayPigCollision(Vector3 position)
    {
        int randomIndex = Random.Range(0, pigCollisons.Length);
        AudioClip ac = pigCollisons[randomIndex];
        PlaySound(ac, position, 1f);
    }

    public void PlayWoodCollision(Vector3 position)
    {
        PlaySound(woodCollision, position, 0.3f);
    }

    public void PlayWoodDestroyed(Vector3 position)
    {
        PlaySound(woodDestoryed, position, 0.2f);
    }

    private void PlaySound(AudioClip clip, Vector3 position, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, position, volume);
        }
    }
}
