using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroPlasticArea : MonoBehaviour
{
    public List< GameObject> MicroPlasticComponents;
    [SerializeField]private bool _notFinished = true;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //CheckMicroPlasticAreaComponents();
    }

    public void CheckMicroPlasticAreaComponents()
    {
        for (int i = 0; i <MicroPlasticComponents.Count; i++)
        {
            if (MicroPlasticComponents[i] == null)
            {
                MicroPlasticComponents.RemoveAt(i);
            }
            if(MicroPlasticComponents.Count == 0)
            {
                //passar para o gameManager
                _gameManager.PassMicroPlastic();
                Debug.Log("Uhuuuu");
            }

        }
        //_notFinished = true;
    }
    
}
