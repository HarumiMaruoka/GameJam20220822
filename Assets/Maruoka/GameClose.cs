using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClose : MonoBehaviour
{
    public void OnButtonClick_GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
