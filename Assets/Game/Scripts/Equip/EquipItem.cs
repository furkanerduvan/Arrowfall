using UnityEngine;

public abstract class EquipItem : MonoBehaviour
{
    [SerializeField] protected ItemData item;

    public virtual void OnUse()
    {

    }
}
