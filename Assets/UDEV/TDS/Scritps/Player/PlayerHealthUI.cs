using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image hpFill;
    [SerializeField] private TextMeshProUGUI hpText;

    public void UpdateHP(int current, int max)
    {
        //hpFill.fillAmount = (float)current / max;

        float percent = (float)current / max;

        hpFill.DOFillAmount(percent, 0.3f);

        hpText.text = $"{current}/{max}";
    }
}