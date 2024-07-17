using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class VRKeyButton : MonoBehaviour
{
    public enum KeyTypes { Key, Backspace, Space, BloqMayus }
    public KeyTypes keyType = KeyTypes.Key;
    private Button button;
    [HideInInspector] public TMP_Text text;
    private string key;

    private void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
        key = gameObject.name;

        if (keyType.Equals(KeyTypes.Key))
            text.text = key;
        else
            text.gameObject.SetActive(false);

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        switch (keyType)
        {
            case KeyTypes.Backspace:
                VRKeyboardManager.Instance.Backspace();
                break;
            case KeyTypes.Space:
                VRKeyboardManager.Instance.InsertCharacter(" ");
                break;
            case KeyTypes.BloqMayus:
                VRKeyboardManager.Instance.ToggleBloqMayus();
                break;
            case KeyTypes.Key:
                VRKeyboardManager.Instance.InsertCharacter(key);
                break;
        }
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}