using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollControl : MonoBehaviour
{
    [SerializeField] LeaderboardItem itemPrefab;
    [SerializeField] LeaderboardItem itemTopBar;
    [SerializeField] LeaderboardItem itemBottomBar;

    //P.S - ¬ примере пишем номер игрока в инспекторе
    [SerializeField] int playerNumber;

    //P.S - ¬ примере получаем количество из инспектора
    [SerializeField] int itemsCount;



    LeaderboardItem[] items;
    RectTransform contentRect;
    LeaderboardItem player;
    RectTransform playerRect;
    float spacingContent;

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
        items = new LeaderboardItem[itemsCount];
        Init(itemsCount);
        spacingContent = (contentRect.localPosition.y - contentRect.anchoredPosition.y) * 2;
    }

    public void Init(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            LeaderboardItem item = Instantiate(itemPrefab, transform, false);
            item.Init(i + 1, i + 1 == playerNumber);
            item.name = $"{i + 1}_item";
            items[i] = item;
            if (i + 1 == playerNumber)
            {
                player = item;
                playerRect = player.GetComponent<RectTransform>();
            }
        }
        itemTopBar.Init(playerNumber, true);
        itemBottomBar.Init(playerNumber, true);
    }

    public void Reset()
    {
        foreach(var item in items)
        {
            Destroy(item.gameObject);
        }
        items = new LeaderboardItem[itemsCount];
        Init(itemsCount);
    }

    private void FixedUpdate()
    {
        if (items.Length <= 0)
            return;

        for (int i = 0; i < itemsCount; i++)
        {
            bool top_visible = contentRect.anchoredPosition.y > (-player.transform.localPosition.y) - playerRect.sizeDelta.y / 2;
            itemTopBar.SetVisible(top_visible);
            bool bottom_visible = contentRect.anchoredPosition.y < -player.transform.localPosition.y - spacingContent + playerRect.sizeDelta.y / 2;
            itemBottomBar.SetVisible(bottom_visible);
        }
    }
}
