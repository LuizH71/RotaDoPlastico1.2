using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animais : MonoBehaviour
{
    private ResiduoCanvas _residuoCanvas;
    private GameManager _gameManager;

    [SerializeField] private Sprite _animalImage;
    [TextArea]
    [SerializeField] private string _animalInfo;

    private NavMeshAgent _agent;

    private bool _resgataddo = false;
    private void Start()
    {
        _residuoCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ResiduoCanvas>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _resgataddo)
        {
            _gameManager.PassAnimal();
            _residuoCanvas.PassResToCanvas(_animalInfo, _animalImage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boia"))
        {
            _resgataddo = true;
            _agent.enabled = false;
            Debug.Log("ahhh");
            gameObject.transform.SetParent(collision.gameObject.transform);
            gameObject.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }
    }
}
