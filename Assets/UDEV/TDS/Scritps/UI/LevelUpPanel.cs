using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI txtLevelUp;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ShowLevelUp(int level)
    {
        StopAllCoroutines();

        panel.SetActive(true);

        txtLevelUp.text =
            $"LEVEL {level}";

        panel.transform.localScale = Vector3.zero;

        panel.transform
            .DOScale(Vector3.one, 0.3f)
            .SetEase(Ease.OutBack);

        StartCoroutine(HideRoutine());
    }

    private IEnumerator HideRoutine()
    {
        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
    }
}