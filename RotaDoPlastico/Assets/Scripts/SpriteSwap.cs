using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwap : MonoBehaviour
{

    [SerializeField] private floatVariable _audioSave;
    [SerializeField] private Sprite _audionOn;
    [SerializeField] private Sprite _audionOff;
    [SerializeField] private Image _IMG;
    // Start is called before the first frame update

    private void OnEnable()
    {
        //Swap();
    }

    public void Swap()
    {
        if(_audioSave.Value == 1)
        {
            _IMG.sprite = _audionOff;
            _audioSave.Value = 0;

            AudioManager.instance.gameObject.SetActive(false);
        }
        else if(_audioSave.Value == 0)
        {
            _IMG.sprite = _audionOn;
            _audioSave.Value = 1;

            AudioManager.instance.gameObject.SetActive(true);
        }
    }
}
