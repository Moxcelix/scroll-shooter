using UnityEngine;

public class Attacker : MonoBehaviour 
{
    public delegate void OnAttackDelegate();
    public event OnAttackDelegate OnAttack;

    [SerializeField] private float _coolDown;

    private float _timer = 0;

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_timer <= 0)
        {
            _timer = _coolDown;

            OnAttack?.Invoke();
        }
    }
}
