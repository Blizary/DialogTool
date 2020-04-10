using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPage",menuName ="Page")]
public class Page : ScriptableObject
{
    public Sprite backgroundImage;
    [TextArea]
    public string mainText;
    public int numOfPages;
    public bool talkingToSomeone;
    public Sprite otherPersonSprite;
    public List<PageOption> options;
    
}
