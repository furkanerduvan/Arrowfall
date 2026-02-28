using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Ranged")]
    [SerializeField] private Transform muzzle;
    [SerializeField] private RangedWeaponItemData weapon;
    [SerializeField] private float attackRange;
    [SerializeField] private int inspectorScoreValue;

    private void OnValidate()
    {
        scoreValue = inspectorScoreValue;
    }

    protected override void AttackTarget()
    {
        Quaternion projRotation = Quaternion.FromToRotation(transform.up, GetTargetDirection());
        weapon.Fire(muzzle.position, projRotation, team);
    }

    protected override bool CanAttack()
    {
        return Time.time - lastAttackTime > weapon.FireRate;
    }

    protected override bool InAttackRange()
    {
        return targetDistance <= attackRange;
    }
}
