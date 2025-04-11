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
    [SerializeField] private bool _residuosDone;

    [Header("Animal")]
    public int AnimalAmountToGet;
    [HideInInspector] public int AnimalAmount = 0;
    [SerializeField] private TextMeshProUGUI _animalToGetTXT;
    [SerializeField] private TextMeshProUGUI _animalAmountTXT;
    [SerializeField] private bool _animalDone;

    [Header("MicroPlastic")]
    public int MicroPlasticAmountToGet;
    public int MicroPlasticAmount = 0;
    [SerializeField] private TextMeshProUGUI _microPlasticToGetTXT;
    [SerializeField] private TextMeshProUGUI _microPlasticAmountTXT;
    [SerializeField] private bool _microPlasticDone;

    [Header("Finalize Game")]
    [SerializeField] private GameObject _finalizeOBJ;

    [Header("Fail Game")]
    [SerializeField] private GameObject _failOBJ;

    public bool FinalGame;
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
    private void Update()
    {
        if (FinalGame)
        {
            FinalizeGame();
            FinalGame = false;
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

        if(ResiduoAmount >= ResiduosAmountToGet)
        {
            _residuosDone = true;
            FinalizeGame();
        }
    }
    public void PassAnimal()
    {
        AnimalAmount += 1;
        _animalAmountTXT.text = AnimalAmount.ToString();
        if (AnimalAmount >= AnimalAmountToGet)
        {
            _animalDone = true;
            FinalizeGame();
        }
    }
    public void PassMicroPlastic()
    {
        MicroPlasticAmount += 1;
        _microPlasticAmountTXT.text = MicroPlasticAmount.ToString();
        if (MicroPlasticAmount >= MicroPlasticAmountToGet)
        {
            _microPlasticDone = true;
            FinalizeGame();
        }
    }

    public void FinalizeGame()
    {
        if(_microPlasticDone && _microPlasticDone && _animalDone)
        {
            _finalizeOBJ.SetActive(true);
            Player.Instance.StopAccelerating();
        }
    }

    public void FailGame()
    {
        _failOBJ.SetActive(true);
        Player.Instance.StopAccelerating();
    }
}
