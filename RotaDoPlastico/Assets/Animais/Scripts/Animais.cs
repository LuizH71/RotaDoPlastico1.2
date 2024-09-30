using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animais : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    private ResiduoCanvas _residuoCanvas;
    private GameManager _gameManager;

    [Space]

    [SerializeField] private Sprite _animalImage;
    [TextArea]
    [SerializeField] private string _animalInfo;

    private bool _resgatado = false;
    private void Start()
    {
        _residuoCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ResiduoCanvas>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _resgatado)
        {
            _gameManager.PassAnimal();
            _residuoCanvas.PassResToCanvas(_animalInfo, _animalImage);
            Destroy(_parent);
        }
        if (collision.CompareTag("Boia"))
        {
            _resgatado = true;
            _parent.GetComponent<AnimalMov>().enabled = false;
            _parent.GetComponent<Collider2D>().enabled = false;
            Debug.Log("ahhh");
            _parent.transform.SetParent(collision.gameObject.transform);
            _parent.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }
    }
}
