using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{

    [SerializeField] private GameObject _boia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Vector3 _pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));
                _boia.transform.position = new Vector3(_pos.x, _pos.y, _boia.transform.position.z);
            }
        }
    }
}
