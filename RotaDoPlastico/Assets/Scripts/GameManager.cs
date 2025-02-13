using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Resíduos")]
    public int ResiduosAmountToGet;
    [HideInInspector] public int ResiduoAmount = 0;
    [SerializeField] private TextMeshProUGUI _residuosToGetTXT;
    [SerializeField] private TextMeshProUGUI _residuosAmountTXT;

    [Header("Animal")]
    public int AnimalAmountToGet;
    [HideInInspector] public int AnimalAmount = 0;
    [SerializeField] private TextMeshProUGUI _animalToGetTXT;
    [SerializeField] private TextMeshProUGUI _animalAmountTXT;

    [Header("MicroPlastic")]
    public int MicroPlasticAmountToGet;
    [HideInInspector] public int MicroPlasticAmount = 0;
    [SerializeField] private TextMeshProUGUI _microPlasticToGetTXT;
    [SerializeField] private TextMeshProUGUI _microPlasticAmountTXT;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _residuosToGetTXT.text = ResiduosAmountToGet.ToString();
        _animalToGetTXT.text = AnimalAmountToGet.ToString();
        _microPlasticToGetTXT.text = MicroPlasticAmountToGet.ToString();
    }

    public void PassResiduo()
    {
        ResiduoAmount += 1;
        _residuosAmountTXT.text = ResiduoAmount.ToString();
    }
    public void PassAnimal()
    {
        AnimalAmount += 1;
        _animalAmountTXT.text = AnimalAmount.ToString();
    }
    public void PassMicroPlastic()
    {
        MicroPlasticAmount += 1;
        _microPlasticAmountTXT.text = MicroPlasticAmount.ToString();
    }
}
