using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPosHUD : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] Image _image;

    private void Start()
    {
        _anim = this.GetComponent<Animator>();
    }

    public void StartAnim()
    {
        _anim.SetTrigger("Anim");
        _image.enabled = true;
    }
    public void DisableIMG()
    {
        _image.enabled = false;
    }
}
