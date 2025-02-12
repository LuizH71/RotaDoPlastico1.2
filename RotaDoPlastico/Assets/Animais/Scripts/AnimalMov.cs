using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMov : MonoBehaviour
{
    private Transform _centerPoint; //ccenter of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    private GameObject _player;
    [SerializeField] private GameObject _animalSpriteAndDescription;
    private NavMeshAgent _agent;
    public float range; //radius of sphere
    private bool _playerClose;
    [SerializeField]private bool _move = false;
    private Vector3 _lastDestination;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (_move)
        {
            MoveAwayFromPlayer();
        }

        if(!_move && _playerClose)
        {
            CreateRandomPoint(transform.position, range);
        }
    }

    private void MoveAwayFromPlayer()
    {
        _agent.SetDestination(_lastDestination);//Moves the animal

        if(Vector3.Distance(transform.position,_lastDestination)< 0.5f)
        {
            _move = false;
            //Enable Animal Sprites and collider
            DisableOrEnableAnimal(true);
        }

    }
    private void CreateRandomPoint(Vector3 center, float range)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            if (Vector3.Distance(hit.position, _player.transform.position) < 5f)
            {
                CreateRandomPoint(transform.position, range);
            }
            else
            {
                _move = true;
                _lastDestination = hit.position;
            }

        }
        else
        {
            CreateRandomPoint(transform.position, range);
        }
    }
    private void DisableOrEnableAnimal(bool x)
    {
        _agent.enabled = !x;
        _animalSpriteAndDescription.SetActive(x);
    }

    /*
    private void MoveAwayFromPlayer()
    {
        Vector3 directionToClosestToPlayer = (_player.transform.position - transform.position);

        _agent.velocity = Vector3.Lerp(
            a: _agent.desiredVelocity,
            b: -directionToClosestToPlayer.normalized * _agent.speed * 2,
            t: Mathf.Clamp01(2 - directionToClosestToPlayer.magnitude / 4));
    }
    */
    /*
    private Vector3 MoveToRandomPoint()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(transform.position, range, out point)) //pass in our center point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.cyan, 1.0f); //so you can see with gizmos
                return point;
            }
        }
        return Vector3.zero;
    }
    */
    /*
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerClose = true;

            DisableOrEnableAnimal(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerClose = false;
        }
    }
}
