using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] private List<Sound> _soundsToRandomBetween;

    public void PlayRandomSound()
    {
        int x = Random.Range(0, _soundsToRandomBetween.Count);
        AudioManager.instance.Play(_soundsToRandomBetween[x].name);
    }
}
