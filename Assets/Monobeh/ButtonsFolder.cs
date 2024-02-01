using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsFolder : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();

    public Button GetButton(int index)
    {
        return buttons[index];
    }
}