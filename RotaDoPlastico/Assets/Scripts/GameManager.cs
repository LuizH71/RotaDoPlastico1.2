using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        _residuosToGetTXT.text = ResiduosAmountToGet.ToString();
        _animalToGetTXT.text = AnimalAmountToGet.ToString();
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
}
