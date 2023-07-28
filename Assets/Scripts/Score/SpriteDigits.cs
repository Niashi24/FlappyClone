using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteDigits : ScriptableObject
{
    [field: SerializeField]
    public float SpriteWidth { get; private set; }
    
    [field: SerializeField]
    public Sprite Zero { get; private set; }
    [field: SerializeField]
    public Sprite One { get; private set; }
    [field: SerializeField]
    public Sprite Two { get; private set; }
    [field: SerializeField]
    public Sprite Three { get; private set; }
    [field: SerializeField]
    public Sprite Four { get; private set; }
    [field: SerializeField]
    public Sprite Five { get; private set; }
    [field: SerializeField]
    public Sprite Six { get; private set; }
    [field: SerializeField]
    public Sprite Seven { get; private set; }
    [field: SerializeField]
    public Sprite Eight { get; private set; }
    [field: SerializeField]
    public Sprite Nine { get; private set; }
    [field: SerializeField]
    public Sprite Invalid { get; private set; }

    public Sprite this[int value] => value switch
    {
        0 => Zero,
        1 => One,
        2 => Two,
        3 => Three,
        4 => Four,
        5 => Five,
        6 => Six,
        7 => Seven,
        8 => Eight,
        9 => Nine,
        _ => Invalid
    };
}
