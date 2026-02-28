using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private int inspectorScoreValue;

    private void OnValidate()
    {
        scoreValue = inspectorScoreValue;
    }

    protected override void AttackTarget()
    {
        IDamagable damagable = target.GetComponent<IDamagable>();

        if (damagable != null )
            damagable.TakeDamage( damage );
    }

    protected override bool CanAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }

    protected override bool InAttackRange()
    {
        return targetDistance <= attackRange;   
    }
}
