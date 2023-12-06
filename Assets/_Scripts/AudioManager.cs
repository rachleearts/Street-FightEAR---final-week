using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class AudioManager : MonoBehaviour

{   
    public static AudioManager singleton;
    public Slider volumeSlider;
    public GameObject audioSettings;
    public AudioSource slapCompilation;
    public AudioClip [] slapSounds;    


   //Keep a single game object with background audio to transfer between scenes
   void Awake()
   {
      if (singleton == null) {
            singleton = this;
        } else if (singleton!= this) {
            Destroy(gameObject);
        }
  
   DontDestroyOnLoad(transform.gameObject);

   

    // if (!PlayerPrefs.HasKey("background volume"))
    //     {
    //         PlayerPrefs.SetFloat("background volume", 1f);
    //         Load();
    //     }
       
    //if no player prefs set, set volume to 1; otherwise load player prefs

    // if (!PlayerPrefs.HasKey("background volume"))
    //     {
    //         PlayerPrefs.SetFloat("background volume", 1);
    //         //Load();
    //         //Save();
    //     }
    // else
    //     {
    //         Load();
    //     }
       

       

   }
    
   //change audio volume with slider

    void Start()
    {
        audioSettings = GameObject.Find("PanelAudio");
        volumeSlider = audioSettings.GetComponentInChildren<Slider>();
        volumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        Save();
        //Load();
    }

    public void VolumeChanger()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    
        //Save player preferences
        //save volume

        public void Save()
        {
            PlayerPrefs.SetFloat("background volume", volumeSlider.value);
        }


        //Load player preferences

        public void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("background volume");
        }

        //on new scene find the panel audio, find its slider and set the value and volume to the player prefs
        void OnLevelWasLoaded()
        { 
           audioSettings = GameObject.Find("PanelAudio");
           volumeSlider = audioSettings.GetComponentInChildren<Slider>();
           volumeSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
           Load();
           Debug.Log("Loaded");
        }

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
