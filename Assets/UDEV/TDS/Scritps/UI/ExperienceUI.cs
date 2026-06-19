using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExperienceUI : MonoBehaviour
{
    [SerializeField] private Image expFill;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;

    public void UpdateExp(
        int currentExp,
        int maxExp,
        int level)
    {
        float percent =
            (float)currentExp / maxExp;

        expFill.DOFillAmount(percent, 0.3f);

        levelText.text =
            $"Level {level}";

        expText.text =
            $"{currentExp}/{maxExp}";
    }
}