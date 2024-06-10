using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public delegate void OnAttackDelegate();
    public event OnAttackDelegate OnAttack;

    [SerializeField] private float _coolDown;
    [SerializeField] private Blast _blastPrefab;
    [SerializeField] private Transform _origin;
    [SerializeField] private float _delay;

    private float _timer = 0;

    public Vector2 Direction { get; set; } = Vector2.right;

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_timer <= 0)
        {
            _timer = _coolDown;

            StartCoroutine(Spawn(_blastPrefab, _delay));

            OnAttack?.Invoke();
        }
    }

    private void Spawn(Blast blastPrefab)
    {
        var angle = Vector2.SignedAngle(Vector2.right, Direction);
        var rotation = Quaternion.Euler(Vector3.forward * angle);
        var blast = Instantiate(blastPrefab, _origin.position, rotation);
    }

    private IEnumerator Spawn(Blast blastPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);

        Spawn(blastPrefab);
    }
}
