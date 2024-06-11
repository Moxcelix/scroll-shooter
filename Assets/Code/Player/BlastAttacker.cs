using System.Collections;
using UnityEngine;

public class BlastAttacker : Attacker
{
    [SerializeField] private Blast _blastPrefab;
    [SerializeField] private Transform _origin;
    [SerializeField] private float _delay;

    protected override void AttackAction()
    {
        StartCoroutine(Spawn(_blastPrefab, _delay));
    }
    private void Spawn(Blast blastPrefab)
    {
        var angle = Vector2.SignedAngle(Vector2.right, Direction
            );
        var rotation = Quaternion.Euler(Vector3.forward * angle);
        var blast = Instantiate(blastPrefab, _origin.position, rotation);
    }

    private IEnumerator Spawn(Blast blastPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);

        Spawn(blastPrefab);
    }
}
