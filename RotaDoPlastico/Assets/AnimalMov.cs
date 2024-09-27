using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMov : MonoBehaviour
{
    private NavMeshAgent _agent;
    public float range; //radius of sphere

    [SerializeField]private List<Transform> points;

    private Transform _centerPoint; //ccenter of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    private GameObject _player;

    private bool _playerClose;

    private Vector3 _lastDestination;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (_playerClose)
        {
            MoveAwayFromPlayer();
        }
        else
        {
            GetMoveTargetLocation();
        }

        //_agent.SetDestination(_lastDestination);
    }

    private void GetMoveTargetLocation()
    {


        if (_agent.remainingDistance <= _agent.stoppingDistance) //done with path
        {

            if (RandomPoint(transform.position, range, out _lastDestination)) //pass in our center point and radius of area
            {
                Debug.DrawRay(_lastDestination, Vector3.up, Color.cyan, 1.0f); //so you can see with gizmos
                _agent.SetDestination(_lastDestination);
            }
        }


    }
    private void MoveAwayFromPlayer()
    {
        Vector3 directionToClosestToPlayer = (_player.transform.position - transform.position);

        _agent.velocity = Vector3.Lerp(
            a: _agent.desiredVelocity,
            b: -directionToClosestToPlayer.normalized * _agent.speed * 2,
            t: Mathf.Clamp01(2 - directionToClosestToPlayer.magnitude / 4));
    }

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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player = collision.gameObject;
            _playerClose = true;
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
