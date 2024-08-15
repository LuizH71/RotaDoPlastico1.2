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

    private void Start()
    {
        _residuosToGetTXT.text = ResiduosAmountToGet.ToString();
    }

    public void PassResiduo()
    {
        ResiduoAmount += 1;
        _residuosAmountTXT.text = ResiduoAmount.ToString();
    }
}
