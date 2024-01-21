using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] _arenaScreens;
    [SerializeField] private Transform[] _PlayerPosition;
    [SerializeField] private Transform[] _enemiesPosition;

    [SerializeField] private List<GameObject> _SpawnedObjects = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            BattleStart(2);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BattleEnd(2);
        }
    }

    private void BattleStart(int arenaID)
    {
        _arenaScreens[arenaID].SetActive(true);

        _camera.orthographicSize = 10f;
        _camera.transform.position = new Vector3(34f, _camera.transform.position.y, _camera.transform.position.z);

    }
    private void BattleEnd(int arenaID)
    {
        _arenaScreens[arenaID].SetActive(false);

        _camera.orthographicSize = 5f;
        _camera.transform.position = new Vector3(0, _camera.transform.position.y, _camera.transform.position.z);

        if (_SpawnedObjects != null) 
        {
            for (int i = 0; i < _SpawnedObjects.Count; i++)
            {
                Destroy(_SpawnedObjects[i]);
            } 
        }
    }
    private void SpawnFighters(Transform spawnPosition, GameObject prefab) 
    {
        GameObject fighter = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
        fighter.transform.SetParent(spawnPosition);
        
        _SpawnedObjects.Add(fighter);
    }
}
