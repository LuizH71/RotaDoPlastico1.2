using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[CreateAssetMenu (fileName ="ResiduoSO", menuName = "ScriptableObjects/Residuo")]
public class Residuo : ScriptableObject
{

    [SerializeField] public Sprite _residuoImage;
    [TextArea]
    [SerializeField] public string _residuoInfo;


    [System.NonSerialized]
    public UnityEvent<string, Sprite> ResiduoColectedEvent;

}
