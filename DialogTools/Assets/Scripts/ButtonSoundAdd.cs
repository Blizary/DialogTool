using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundAdd : MonoBehaviour
{

    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("ButtonSoundSource").GetComponent<AudioSource>();
        gameObject.AddComponent<AudioSource>();
        
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySound()
    {
        source.clip = sound;
        source.PlayOneShot(sound);
    }
}
