using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{
    [Header("instances")]
    private GameObject _player;
    [SerializeField] private GameObject _boiaPrefab;
    private GameObject _boia;


    [Header("Lerp/Launch")]
    [SerializeField] private float _desiredTimeDuration;
    private float _elapsedTime;
    [SerializeField] private Transform _boiaEndPos;
    [HideInInspector] public bool Launch;

    private bool _launched = false;

    [Header("Return")]
    public float VelocidadeParaVoltar;
    [HideInInspector] public bool Return = false;
    private bool _returned = false;

    [SerializeField] private bool Ligado = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Launch)
        {
            MoveBoiaToEndPos(_boiaEndPos.position);
        }
        else if (Return)
        {
            MoveToBoat();
        }
    }

    public void MoveBoiaToEndPos(Vector3 _endPos)
    {

        _elapsedTime += Time.deltaTime;
        float percentageComplete = _elapsedTime / _desiredTimeDuration;
        _boia.transform.position = Vector3.Lerp(_boia.transform.position, _endPos, percentageComplete);

        float distance = Vector3.Distance(_boia.transform.position, _endPos);
        if (distance < 0.1f)
        {
            Launch = false;
            _elapsedTime = 0;
            _launched = true;
            _boia.GetComponent<Rigidbody2D>().simulated = true;
            _boiaEndPos.gameObject.GetComponent<BoiaMove>().ResetPos();
        }
    }

    public void SpawnBoia()
    {
        _boia = Instantiate(_boiaPrefab);
        _boia.transform.position = transform.position;
        _boia.GetComponent<Animator>().SetTrigger("LaunchBoia");
    }

    void MoveToBoat()
    {
        if (_launched)
        {
            var step = VelocidadeParaVoltar * Time.deltaTime;
            _boia.transform.position = Vector3.MoveTowards(_boia.transform.position, _player.transform.position, step);

            if (Vector3.Distance(_boia.transform.position, _player.transform.position) < 0.1f)
            {
                Destroy(_boia);
                _launched = false;
            }
        }

    }

    public void OnOFF()
    {
        if (Ligado && !_launched && !Launch)//Desliga
        {
            _player.GetComponent<Player>().enabled = true;
            Ligado = false;
            _boiaEndPos.gameObject.SetActive(false);
            _boiaEndPos.gameObject.GetComponent<BoiaMove>().ResetPos();
            _returned = false;
        }
        else//Liga
        {
            _player.GetComponent<Player>().enabled = false;
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Ligado = true;
            _boiaEndPos.gameObject.SetActive(true);
        }
    }
    /*
    private void GetInput()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            RaycastHit2D raycastHit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), _rayRadius,Vector2.zero); 

            if (raycastHit)
            {
                Debug.Log("Something Hit");

                if (raycastHit.collider.CompareTag("Terreno"))
                {
                    Debug.Log("object clicked");
                    //TropfenObject.GetComponent<Tropfen>().TropfenDestruction();
                }
            }
        }
    }
    */
}
