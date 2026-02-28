using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private ItemSlot ItemSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemSlot != null)
            Inventory.Instance.UseItem(ItemSlot);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ItemSlot.Item != null)
        {
            Inventory.Instance.UI.TooltipUI.SetTooltip(ItemSlot.Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory.Instance.UI.TooltipUI.DisableToolTip();
    }

    public void SetItemSlot (ItemSlot slot)
    {
        ItemSlot = slot;

        if(slot.Item == null)
        {
            icon.enabled = false;
            quantityText.text = string.Empty;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.Item.Icon;
            quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : string.Empty;
        }

    }
}
