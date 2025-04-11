using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _deltaX, _deltaY;
    private Vector3 _startPos;
    private GameObject _player;

    [SerializeField] private float _rayRadius;
    [HideInInspector] public bool LaunchBoia;
    [SerializeField] private LayerMask TerrnoAndPlayer;

    [Header("SpriteSwap")]
    [SerializeField] private SpriteRenderer _spriteRender;
    [SerializeField] private Sprite _boiaNormal;
    [SerializeField] private Sprite _boiaErrada;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = Player.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();

        TargetMovement();
    }

    private void TargetMovement()//Faz o movimento da sinalização aonde a boia vai cair
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position * -1);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _deltaX = touchPos.x - transform.position.x;
                    _deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    _rb.MovePosition(new Vector2(touchPos.x - _deltaX, touchPos.y - _deltaY));
                    break;

                case TouchPhase.Ended:// Caso solte da tela ou não faz nada em caso de estar em cima da terra ou solta a boia caso esteja em cima da água
                    if (!LaunchBoia)
                    {
                        ResetPos();
                    }
                    else
                    {
                        _rb.velocity = Vector2.zero;
                        _player.GetComponent<Rescue>().SpawnBoia();
                        _player.GetComponent<Rescue>().Launch = true;
                        _spriteRender.sprite = null;
                        this.enabled = false;
                    }
                    break;


            }
        }
    }


    public void ResetPos()
    {
        transform.position = _player.transform.position;
        this.enabled = true;
    }
    private void Raycast()// Checa pra ver se onde a boia vai é  água ou terra
    {

        if (Physics2D.CircleCast(transform.position, _rayRadius, Vector2.zero,1f,TerrnoAndPlayer))// Se for terra fica vermelho e não deixa jogar a boia
        {
            //this.GetComponent<SpriteRenderer>().color = Color.red;
            _spriteRender.sprite = _boiaErrada;
            LaunchBoia = false;

        }
        else//Se For água fica azul e deixa jogar a boia
        {
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
            _spriteRender.sprite = _boiaNormal;
            LaunchBoia = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _rayRadius);

    }
}
