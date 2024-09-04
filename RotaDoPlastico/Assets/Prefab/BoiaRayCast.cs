using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaRayCast : MonoBehaviour
{
    [SerializeField] private LayerMask _whhatIsGround;
    [SerializeField] private float _rayRadius;

    public bool Land = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _rayRadius);

    }
}
