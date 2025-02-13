using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResiduoCanvas : MonoBehaviour
{
    public static ResiduoCanvas Instance;

    [SerializeField] private GameObject _residuoPanel;

    public TextMeshProUGUI ResInfoTXT;
    public Image ResImage;

    private bool passed = false;
    private float TimePassedToDeactivated;
    [SerializeField]private float InformationDelay;

    [SerializeField] private Residuo Residuos;


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
        if (passed)
        {
            TimePassedToDeactivated += Time.deltaTime;
            if(TimePassedToDeactivated >= InformationDelay)
            {
                DeactivatedPanel();
            }
        }
    }
    public void PassResToCanvas(string _resInfo, Sprite _resImage)
    {
        passed = true;
        TimePassedToDeactivated = 0f;
        _residuoPanel.SetActive(true);

        ResImage.sprite = _resImage;
        ResInfoTXT.text = _resInfo;
    }

    private void DeactivatedPanel()
    {
        _residuoPanel.SetActive(false);
        passed = false;
    }
}
