using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResiduoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _residuosPrefab;

    [SerializeField]private List<GameObject> _spawnPoints;
    [SerializeField] private List<Residuo> _residuos;

    private void Start()
    {
        SpawnResiduos();
    }

    public void SpawnResiduos()
    {
        for (int i = _residuos.Count-1; i >=0; i--)
        {
            GameObject residuo = _residuosPrefab;
            int spawnPointIndex = Random.Range(0, _spawnPoints.Count);

            Instantiate(residuo);
            residuo.transform.position = new Vector2(_spawnPoints[spawnPointIndex].transform.position.x, _spawnPoints[spawnPointIndex].transform.position.y);//set the residuo position to the spawn position
            residuo.GetComponent<ResiduoTrigger>().ResiduoSO = _residuos[i];

            _spawnPoints.RemoveAt(spawnPointIndex);//Remove the spawnPoint from the list so the residuo doesn't spawn in the same place as other

        }
    }
}
