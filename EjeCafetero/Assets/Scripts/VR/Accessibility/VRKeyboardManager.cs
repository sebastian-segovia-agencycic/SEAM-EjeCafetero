using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VRKeyboardManager : MonoBehaviour
{
    public static VRKeyboardManager Instance;

    private TMP_InputField currentInputField;
    private bool isBloqMayusOn = false;

    public List<Sprite> specialCharacters = new List<Sprite>();
    public Image bloqMayusButton;
    private VRKeyButton[] buttons;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        buttons = GetComponentsInChildren<VRKeyButton>();
    }

    public void SetCurrentInputField(TMP_InputField inputField)
    {
        currentInputField = inputField;
    }

    public void InsertCharacter(string character)
    {
        if (currentInputField != null)
        {
            if (isBloqMayusOn)
                character = character.ToUpper();
            else
                character = character.ToLower();
            currentInputField.text += character;
        }
    }

    public void Backspace()
    {
        if (currentInputField != null && currentInputField.text.Length > 0)
            currentInputField.text = currentInputField.text.Substring(0, currentInputField.text.Length - 1);
    }

    public void ToggleBloqMayus()
    {
        isBloqMayusOn = !isBloqMayusOn;
        bloqMayusButton.sprite = isBloqMayusOn ? specialCharacters[0] : specialCharacters[1];
        if (isBloqMayusOn)
        {
            foreach (VRKeyButton button in buttons)
                button.text.text = button.gameObject.name.ToUpper();
        }
        else
        {
            foreach (VRKeyButton button in buttons)
                button.text.text = button.gameObject.name.ToLower();
        }
    }
}