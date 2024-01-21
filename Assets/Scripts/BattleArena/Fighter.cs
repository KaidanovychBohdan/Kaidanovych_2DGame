using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FighterAnimator), typeof(FighterAttack), typeof(FighterMove))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Fighter _target;
    [SerializeField] private float _fightDistance;

    public PlayerParams playerParams;

    [SerializeField] private float _health;
    private GameObject _stayPoint;
    private FighterAnimator _animator;
    private FighterAttack _attack;
    private FighterMove _move;
    private FighterTurnMeter _turnMeter;

    public event UnityAction<Fighter> TurnMeterFilled;
    public event UnityAction<Fighter> Died;


    private void Awake()
    {
        _animator = GetComponent<FighterAnimator>();
        _attack = GetComponent<FighterAttack>();
        _move = GetComponent<FighterMove>();
        _turnMeter = GetComponent<FighterTurnMeter>();

        _health = playerParams.Health;
    }


    public void TurnMeter()
    {
        _turnMeter.Increase();
        if (_turnMeter.CanOffensive) 
        {
            TurnMeterFilled?.Invoke(this);
        }
    }

    public void CurrentStayPoint(GameObject spawnPoint) 
    {
        _stayPoint = spawnPoint;
    }

    public void GetDMG(int damage) 
    {
        _health -= damage;

        if (_health <= 0) 
        {
            Die();
        }
    }

    private void Die() 
    {
        _animator.Dead();
        Died?.Invoke(this);
    }

    public Coroutine StartOffensive(Fighter target) 
    {
        return StartCoroutine(Offensive(target));
    }

    private IEnumerator Offensive(Fighter target)
    {
        _animator.Run(); 
        yield return _move.StartLookAtRotation(target.transform);
        yield return _move.StartMove(target.transform,_fightDistance); // ідемо до ворога

        _animator.Idle();
        _attack.SetTarget(target);
        yield return new WaitForSeconds(_animator.StartAttack()); // удар по ворозі

        _animator.Run();
        yield return _move.StartLookAtRotation(_stayPoint.transform);
        yield return _move.StartMove(_stayPoint.transform); // повертаємося назад

        yield return _move.StartRotation(_stayPoint.transform.rotation);
        _animator.Idle(); // повертаємося в початкову точку 
    }
}
