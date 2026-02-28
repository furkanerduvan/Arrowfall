using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] starterItems;
    [SerializeField] private int inventorySize;
    private ItemSlot[] ItemSlots;

    public InventoryUI UI;

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        ItemSlots = new ItemSlot[inventorySize];

        for (int i = 0; i < ItemSlots.Length; i++)
        {
            ItemSlots[i] = new ItemSlot();
        }

        for (int i = 0; i < starterItems.Length; i++)
        {
            AddItem(starterItems[i]);
        }
    }

    public void AddItem(ItemData item)
    {
        ItemSlot slot = FindAvailableItemSlot(item);

        if(slot != null)
        {
            slot.Quantity++;
            UI.UpdateUI(ItemSlots);
            return;
        }

        slot = GetEmptySlot();

        if(slot != null )
        {
            slot.Item = item;
            slot.Quantity = 1;
        }
        else
        {
            Debug.Log("Full");
            return;
        }

        UI.UpdateUI(ItemSlots);
    }

    public void RemoveItem(ItemData item)
    {
        for(int i = 0; i < ItemSlots.Length;i++)
        {
            if(ItemSlots[i].Item == item)
            {
                RemoveItem(ItemSlots[i]);
                return;
            }
        }
    }

    public void RemoveItem(ItemSlot slot)
    {
        if(slot == null)
        {
            Debug.LogError("Cant remove");
            return;
        }

        slot.Quantity--;

        if(slot.Quantity <= 0)
        {
            slot.Item = null;
            slot.Quantity = 0;
        }

        UI.UpdateUI(ItemSlots);
    }

    ItemSlot FindAvailableItemSlot(ItemData item)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].Item == item && ItemSlots[i].Quantity < item.MaxStackSize)
                return ItemSlots[i];
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (ItemSlots[i].Item == null)
                return ItemSlots[i];
        }

        return null;
    }

    public void UseItem(ItemSlot slot)
    {
        if(slot.Item is MeleeWeaponItemData || slot.Item is RangedWeaponItemData)
        {
            Player.Instance.EquipCtrl.Equip(slot.Item);
        }
        else if(slot.Item is FoodItemData)
        {
            FoodItemData food = slot.Item as FoodItemData;
            Player.Instance.Heal(food.HealthToGive);

            RemoveItem(slot);
        }
    }

    public bool HasItem(ItemData item)
    {
        for (int i = 0; i < ItemSlots.Length;i++)
        {
            if (ItemSlots[i].Item == item && ItemSlots[i].Quantity > 0)
                return true;
        }

        return false;
    }
}
