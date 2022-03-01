using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardItem : MonoBehaviour
{
    //P.S - В примере не стал заносить все визуальные параметры
    [SerializeField] TextMeshProUGUI numberTMP;
    [SerializeField] Image rangPanel;
    [SerializeField] Color myColor;
    CanvasGroup canvasGroup;
    
    int index;

    public void SetVisible(bool _visible)
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = _visible ? 1 : 0;
    }

    public void Init(int _number, bool _is_player = false)
    {
        index = _number;
        numberTMP.text = $"{index}";

        if (_is_player)
        {
            rangPanel.color = myColor;
            GetComponent<Image>().color = myColor;
        }
    }
}
