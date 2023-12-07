using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AudioManager : MonoBehaviour

{   
    public static AudioManager singleton;
    public Slider volumeSlider;
    public GameObject audioSettings;
    public AudioSource slapCompilation;
    public AudioClip [] slapSounds;    


   //Singleton: keepx a single game object containing background audio, destroys all others
   void Awake()
    {
        if (singleton == null) 
        {
            singleton = this;
        } 
        
        else if (singleton!= this) 
        {
            Destroy(gameObject);
        }
  
        DontDestroyOnLoad(transform.gameObject);   
    }
    

    //Find the audio panel on the canvas which contains the volume slider. When the slider is changed, get ValueChangeCheck and Save functions to commence.
    void Start()
    {
        audioSettings = GameObject.Find("PanelAudio");
        volumeSlider = audioSettings.GetComponentInChildren<Slider>();
        volumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        Save();
    }

    //On new scene, find the panel audio and the slider. Set the value and volume to the player prefs.
    //If the slider is changed, ValueChangeCheck function commences
    void OnLevelWasLoaded()
    { 
        audioSettings = GameObject.Find("PanelAudio");
        volumeSlider = audioSettings.GetComponentInChildren<Slider>();
        volumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        Load();
    }

    //The background volume picked up by the audio listener is equal to the position on the volume slider. This volume is saved (see Save function).
    public void VolumeChanger()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    
    //Save player preference for background volume correlating to the set slider position
    //Save volume
    public void Save()
    {
        PlayerPrefs.SetFloat("background volume", volumeSlider.value);
    }


    //Load player preferences: the value on the slider equals the background volume player pref.
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("background volume");
    }


    //Calls the VolumeChanger function
    public void ValueChangeCheck()
	{
		VolumeChanger();
	}

    public void SlapAudioTrigger()
    {
        slapCompilation.clip =  slapSounds[Random.Range(0, slapSounds.Length)];
        slapCompilation.Play();
    }

}
