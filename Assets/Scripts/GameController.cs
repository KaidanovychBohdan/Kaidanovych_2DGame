using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public InventoryObjects Inventory;

    [SerializeField] private Camera _camera;
    // Фабрику для створення ГеймОбжектів нижче за заданою позицією + переміщувати туди камеру + розмір камери якщо потрібно  

    [SerializeField] private GameObject _openingCases;
    [SerializeField] private GameObject[] _battleArena;
    [SerializeField] private GameObject _craft;
    [SerializeField] private GameObject _upgrade;

    [SerializeField] private Transform _prefabPosition;

    [Inject] private DiContainer _container;

    private bool IsCreate = false;

    private void Start()
    {
        OpenChest.ChestOpen += AddItemToInventory;
    }

    private void OnDestroy()
    {
        OpenChest.ChestOpen -= AddItemToInventory;
    }

    private void Update()
    {
        if (!IsCreate)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Create(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Create(1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Create(2);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Create(3);
            }
        }
    }

    public void Create(int number) 
    {
        switch (number) 
        {
            case 0:
                CreatePrefab(_openingCases);
                break;
            case 1:
                _camera.orthographicSize = 10;
                CreatePrefab(_battleArena[0]);
                break;
            case 2:
                CreatePrefab(_craft);
                break;
            case 3:
                CreatePrefab(_upgrade);
                break;
        } 
    }

    private void CreatePrefab(GameObject prefab) // change name in the future
    {
        IsCreate = true;
        _camera.transform.position = new Vector3(34, 0, -10);
        _container.InstantiatePrefab(prefab, _prefabPosition.position, Quaternion.identity, _prefabPosition);
    }

    private void AddItemToInventory(Items item) // need to remaster this method cos its not what i wont
    {
        Inventory.AddItem(item, 1);
    }

    private void OnApplicationQuit()
    {
        Inventory.Container.Item = new InventorySlot[96];
    }
}
