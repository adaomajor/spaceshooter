using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    // Use this for initialization
    /*
        Sound[0]  = Theme
        Sound[1]  = GameOver
        Sound[2]  = Pause

        Sound[3] = LaserShot
        Sound[4] = Explosion
    */

    public static AudioManager Instance;

    public AudioClip[] Sounds;
    public AudioSource Muisic , SFX;
	void Start () {
        //PlayMusic(0);
	}

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayMusic(int SoundIndex)
    {
        Muisic.clip = Sounds[SoundIndex];
        if(SoundIndex == 0)
            Muisic.loop = true;
        Muisic.Play();
    }

    public void PlaySFX(int SFX_Index)
    {
        SFX.clip = Sounds[SFX_Index];
        SFX.Play();
    }
}
