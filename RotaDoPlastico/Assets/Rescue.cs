using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{

    [SerializeField] private GameObject _boiaPrefab;

    private GameObject _boia;

    private bool _criada = false;
    [HideInInspector] public bool Return = false;
    [SerializeField]private bool Ligado = false;

    private GameObject _player;

    public float VelocidadeParaVoltar;

    [SerializeField] private LayerMask Ground;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        BoiaManager();
    }

    private void BoiaManager()
    {
        if (!_criada)
        {
            if (Ligado)
            {
                spawnBoia();
            }

        }
        else if(Return)
        {
            MoveToBoat();
        }
    }

    private void spawnBoia()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began )
            {
                //Pega a posição da tela aonde foi clicado
                Vector3 _pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));

                //Checa se aonde foi clicado é terreno, caso sim não jogue a boia
                _boia = Instantiate(_boiaPrefab);
                _boia.transform.position = new Vector3(_pos.x, _pos.y, _boia.transform.position.z);
                _criada = true;

            }
        }
    }

    void MoveToBoat()
    {
        var step = VelocidadeParaVoltar * Time.deltaTime;
        _boia.transform.position = Vector3.MoveTowards(_boia.transform.position, _player.transform.position, step);

        if(Vector3.Distance(_boia.transform.position, _player.transform.position) < 0.1f)
        {
            _criada = false;
            Destroy(_boia);
        }
    }

    public void OnOFF()
    {
        if (Ligado)
        {
            _player.GetComponent<Player>().enabled = true;
            Ligado = false;
        }
        else
        {
            _player.GetComponent<Player>().enabled = false ;
            Ligado = true;
        }
    }
}
