using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class GameCanvas : Scenegleton<GameCanvas>
{
    private RectTransform rectTransform;

    public static float Scale => Instance.rectTransform.lossyScale.x;


    private void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }
}
