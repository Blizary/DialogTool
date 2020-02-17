using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPage",menuName ="Page")]
public class Page : ScriptableObject
{
    public Sprite backgroundImage;
    [TextArea]
    public string mainText;
    public List<PageOption> options;
}
