using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPos : MonoBehaviour
{
    private Vector3 _initialPos;


    private void Start()
    {
        _initialPos = transform.position;
    }

    public void ResetPos()
    {
        transform.position = new Vector3(_initialPos.x,_initialPos.y,_initialPos.z);
    }
}
