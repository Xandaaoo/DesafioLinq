using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static TextMesh textMesh;
    public static UIController uiController;

    private void Start()
    {
        uiController = this;
    }
    static public void changeText(string text)
    {
        textMesh.text = text;
    }


}
