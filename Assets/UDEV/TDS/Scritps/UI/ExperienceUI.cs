using TMPro;
using UnityEngine;

public class ExperienceUI : MonoBehaviour
{
    [SerializeField] private Transform expFill;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;

    public void UpdateExp(
        int currentExp,
        int maxExp,
        int level)
    {
        float percent =
            (float)currentExp / maxExp;

        expFill.localScale =
            new Vector3(percent, 1f, 1f);

        levelText.text =
            $"Level {level}";

        expText.text =
            $"{currentExp}/{maxExp}";
    }
}