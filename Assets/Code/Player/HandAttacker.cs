using UnityEngine;

public class HandAttacker : Attacker
{
    [SerializeField] private float _power;

    private Player _target;

    protected override void AttackAction()
    {
        if(_target == null)
        {
            return;
        }

        _target.Damageable.Damage(_power);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out var player))
        {
            _target = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            if(_target == player)
            {
                _target = null;
            }
        }
    }
}

