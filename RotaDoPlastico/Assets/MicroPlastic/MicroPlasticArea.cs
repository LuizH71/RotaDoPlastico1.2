using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroPlasticArea : MonoBehaviour
{
    public List< GameObject> MicroPlasticComponents;

    private void Start()
    {
    }

    private void Update()
    {
        //CheckMicroPlasticAreaComponents();
    }

    public void CheckMicroPlasticAreaComponents()
    {
        for (int i = MicroPlasticComponents.Count-1; i >= 0; i--)
        {
            if (MicroPlasticComponents[i] == null)
            {
                MicroPlasticComponents.RemoveAt(i);

            }
            if (MicroPlasticComponents.Count == 1)
            {
                //passar para o gameManager
                GameManager.Instance.PassMicroPlastic();
                break;
            }

        }
        //_notFinished = true;
    }
    
}
