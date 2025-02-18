using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    public string[] StaticAnimations = { "Static N", "Static NO", "Static O", "Static SO", "Static S", "Static SE", "Static E", "Static NE" };
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
