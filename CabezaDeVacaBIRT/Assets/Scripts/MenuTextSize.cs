using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class MenuTextSize : MonoBehaviour
{
    private const string LargeTextKey = "MainMenu.LargeText";
    private const float LargeTextScale = 1.25f;

    [SerializeField] private Transform menuCanvas;
    [SerializeField] private Toggle largeTextToggle;

    private TMP_Text[] tmpTexts;
    private Text[] legacyTexts;
    private float[] tmpSizes;
    private int[] legacySizes;

    private void Awake()
    {
        tmpTexts = menuCanvas.GetComponentsInChildren<TMP_Text>(true);
        legacyTexts = menuCanvas.GetComponentsInChildren<Text>(true);

        tmpSizes = new float[tmpTexts.Length];
        legacySizes = new int[legacyTexts.Length];

        for (int i = 0; i < tmpTexts.Length; i++)
            tmpSizes[i] = tmpTexts[i].fontSize;

        for (int i = 0; i < legacyTexts.Length; i++)
            legacySizes[i] = legacyTexts[i].fontSize;

        bool largeText = PlayerPrefs.GetInt(LargeTextKey, 0) == 1;
        largeTextToggle.SetIsOnWithoutNotify(largeText);
        ApplyTextSize(largeText);
    }

    public void SetLargeText(bool largeText)
    {
        ApplyTextSize(largeText);
        PlayerPrefs.SetInt(LargeTextKey, largeText ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplyTextSize(bool largeText)
    {
        float scale = largeText ? LargeTextScale : 1f;

        for (int i = 0; i < tmpTexts.Length; i++)
            tmpTexts[i].fontSize = tmpSizes[i] * scale;

        for (int i = 0; i < legacyTexts.Length; i++)
            legacyTexts[i].fontSize = Mathf.RoundToInt(legacySizes[i] * scale);
    }
}