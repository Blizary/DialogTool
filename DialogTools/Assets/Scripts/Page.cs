using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPage",menuName ="Page")]
public class Page : ScriptableObject
{
    public bool ending;
    public Sprite backgroundImage;
    [TextArea]
    public string mainText;
    [TextArea]
    public List<string> texts;
    //[HideInInspector]
    public int numOfPages;
    public bool talkingToSomeone;
    public Sprite otherPersonSprite;
    public List<PageOption> options;
    public AudioClip pageMusic;
}
