using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Arena : MonoBehaviour
{
    [SerializeField] private Fighter[] _heroesTemplate; // сделать або передавать масив обраних героїв або шото придумать

    [SerializeField] private Fighter[] _enemiesTemplate;

    private List<Fighter> _heroes;
    private List<Fighter> _enemies;
    private Queue<Fighter> _readyToFight;
    private FighterSpawner _spawner;

    [Inject] private Icoin _coin;

    private void Awake()
    {
        _spawner = GetComponent<FighterSpawner>();
        _readyToFight = new Queue<Fighter>();
    }

    private void Start()
    {
        _heroes = _spawner.SpawnHeroes(_heroesTemplate);
        _enemies = _spawner.SpawnEnemies(_enemiesTemplate);

        InitialiseFighter(_enemies);
        InitialiseFighter(_heroes);

        StartCoroutine(Battle());
    }

    private IEnumerator Battle() 
    {
        while (_heroes.Count > 0 && _enemies.Count > 0) 
        {
            var nextFighter = GetNextFighter();

            if (nextFighter != null) 
            {
                if (_heroes.Contains(nextFighter)) 
                {
                    Debug.Log("heroes move");
                    yield return nextFighter.StartOffensive(GetRandomFighter(_enemies));
                }
                else
                {
                    Debug.Log("enemies move");
                    yield return nextFighter.StartOffensive(GetRandomFighter(_heroes));
                }

            }

            yield return new WaitForSeconds(1f);

            IncreaseTurnMeter(_heroes);
            IncreaseTurnMeter(_enemies);
        }
        if (_heroes.Count > 0) {
            Debug.Log("Battle win"); // Add coins and some materials
            _coin.AddCoins(1000);
            Destroy(this.gameObject);
        }
        else 
        {
            Debug.Log("Battle lose");
            Destroy(this.gameObject);
        }
    }
    private void IncreaseTurnMeter(List<Fighter> fighter) 
    {
        fighter.ForEach(f => f.TurnMeter());
    } 

    private Fighter GetNextFighter() 
    {
        if (_readyToFight.Count > 0)
        {
            return _readyToFight.Dequeue();
        }
        else
        {
            return null;
        }
    }

    private Fighter GetRandomFighter(List<Fighter> fighters) 
    {
        return fighters[Random.Range(0, fighters.Count)];
    } 

    private void OnDied(Fighter fighter)
    {
        fighter.TurnMeterFilled -= OnTurnMeterFilled;
        fighter.Died -= OnDied;
        DeleteFighter(fighter);
    }

    private void DeleteFighter(Fighter fighter) 
    {
        if (_readyToFight.Contains(fighter))
        {
            List<Fighter> remainingFighters = new List<Fighter>();

            // Переносимо усіх бійців які не є тим кого ми хочемо видалити до тимчасового списку
            while (_readyToFight.Count > 0)
            {
                Fighter nextFighter = _readyToFight.Dequeue();
                if (nextFighter != fighter)
                {
                    remainingFighters.Add(nextFighter);
                }
            }

            // Повертаємо усіх залишених бійців назад в чергу
            foreach (Fighter remainingFighter in remainingFighters)
            {
                _readyToFight.Enqueue(remainingFighter);
            }
        }
        _heroes.Remove(fighter);
        _enemies.Remove(fighter);
    }

    private void OnTurnMeterFilled(Fighter fighter)
    {
        if (_readyToFight.Contains(fighter) == false) 
        {
            _readyToFight.Enqueue(fighter);
        }
    }

    private void InitialiseFighter(List<Fighter> Fighters) 
    {
        foreach (var fighter in Fighters)
        {
            fighter.TurnMeterFilled += OnTurnMeterFilled;
            fighter.Died += OnDied;
        }
    } 
}
