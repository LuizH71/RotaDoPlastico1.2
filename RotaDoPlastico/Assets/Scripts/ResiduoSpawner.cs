using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResiduoSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> _spawnPoints;

    [SerializeField] private List<GameObject> _residuosPrefabs;

    private void Start()
    {
        SpawnResiduos();
    }

    public void SpawnResiduos()
    {
        for (int i = 0; i < _residuosPrefabs.Count; i++)
        {
            GameObject residuo = _residuosPrefabs[i].gameObject;
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);

            Instantiate(residuo);
            residuo.transform.position = new Vector2(_spawnPoints[spawnPointIndex].transform.position.x, _spawnPoints[spawnPointIndex].transform.position.y);//set the residuo position to the spawn position

            _spawnPoints.RemoveAt(spawnPointIndex);//Remove the spawnPoint from the list so the residuo doesn't spawn in the same place as other

        }
    }
}
