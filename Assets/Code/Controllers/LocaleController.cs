using UnityEngine;

public enum ELocales
{
    English = 0,
    Chinese
}

public static class LocaleController
{
    [SerializeField]
    public static ELocales Locale;
}
