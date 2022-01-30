using UnityEngine;
using UnityEngine.UI;

public class LocaleComponent : MonoBehaviour
{
    private ELocales current;

    [SerializeField]
    private Text text;

    [SerializeField]
    private string english;

    [SerializeField]
    private string chinese;

    private void Update()
    {
        if (LocaleController.Locale == current)
        {
            return;
        }

        current = LocaleController.Locale;

        switch (LocaleController.Locale)
        {
            case ELocales.English:
                text.text = english;
                break;

            case ELocales.Chinese:
                text.text = chinese;
                break;
        }
    }
}
