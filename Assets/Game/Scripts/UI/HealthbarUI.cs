using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthbarFill;

    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }
    private void Start()
    {
        SetNameText(character.displayName);
    }

    void SetNameText (string text)
    {
        nameText.text = text;
    }

    void UpdateHealthBar()
    {
        float healthPercent = (float)character.curHp / (float)character.maxHp;
        healthbarFill.fillAmount = healthPercent;
    }
}
