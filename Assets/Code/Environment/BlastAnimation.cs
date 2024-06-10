using UnityEngine;

[RequireComponent(typeof(Blast))]
[RequireComponent(typeof(Animator))]
public class BlastAnimation : MonoBehaviour
{
    private const string dieTrigger = "dead";

    private Blast _blast;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _blast = GetComponent<Blast>();

        _blast.OnDeath += Blast_OnDeath;
    }

    private void Blast_OnDeath()
    {
        _animator.SetTrigger(dieTrigger);
    }
}
