using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void TapToPlayButton()
    {
        EventManager.OnTapToplayButtonPressed?.Invoke();
    }

    public void NextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }
}
