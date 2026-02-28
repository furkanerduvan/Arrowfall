using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour, IDamagable
{
    public enum Team
    {
        Player,
        Enemy
    }

    public string displayName;
    public int curHp;
    public int maxHp;

    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

    public virtual void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;

        audioSource.PlayOneShot(hitSFX);

        onTakeDamage?.Invoke();

        if (curHp <= 0)
            Die();
    }

    public virtual void Die()
    {
        Time.timeScale = 0f;
        GameoverUI.Instance.Show(ScoreManager.Instance.GetScore());
    }

    public Team GetTeam()
    {
        return team;
    }

    public virtual void Heal(int healAmount)
    {
        curHp += healAmount;

        if(curHp > maxHp)
            curHp = maxHp;

        onHeal?.Invoke();
    }
}
