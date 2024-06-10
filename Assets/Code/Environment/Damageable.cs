using UnityEngine;

public class Damageable : MonoBehaviour
{
    public delegate void OnDamageDelegate(float damage);
    public event OnDamageDelegate OnDamage;

    public void Damage(float damage)
    {
        OnDamage?.Invoke(damage);
    }
}
