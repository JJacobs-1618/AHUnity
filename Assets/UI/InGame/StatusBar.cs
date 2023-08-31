using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public GameObject statusBar;

    public GameObject sanityBar;
    public GameObject sanityTextObj;
    public GameObject staminaBar;
    public GameObject staminaTextObj;

    public Sprite sanitySprite;
    public Sprite staminaSprite;

    private TextMeshProUGUI sanityText;
    private TextMeshProUGUI staminaText;

    private HorizontalLayoutGroup hlgSanity;
    private HorizontalLayoutGroup hlgStamina;

    private List<GameObject> sanityObjs;
    private List<GameObject> staminaObjs;

    private Vector2 imgSize = new(.5f, .5f);


    private void Awake()
    {
        hlgSanity = sanityBar.GetComponent<HorizontalLayoutGroup>();
        sanityText = sanityTextObj.GetComponent<TextMeshProUGUI>();
        sanityText.text = "0";
        hlgStamina = staminaBar.GetComponent<HorizontalLayoutGroup>();
        staminaText = staminaTextObj.GetComponent<TextMeshProUGUI>();
        staminaText.text = "0";

        sanityObjs = new List<GameObject>();
        staminaObjs = new List<GameObject>();
    }

    public void AddStamina(int delta)
    {
        for(int i = 0; i < delta; i++)
        {
            AddStatusIcon("StaminaImg", staminaObjs, staminaBar, staminaSprite);
            staminaText.text = $"{staminaObjs.Count}";
            staminaText.rectTransform.SetAsLastSibling();
        }
    }

    public void RemoveStamina(int delta)
    {
        for (int i = 0; i < delta; i++)
        {
            if (!RemoveStatusIcon(staminaObjs, staminaObjs.Count - 1)) return;
            staminaText.text = $"{staminaObjs.Count}";
            staminaText.rectTransform.SetAsLastSibling();
        }
    }

    public void AddSanity(int delta)
    {
        for (int i = 0; i < delta; i++)
        {
            AddStatusIcon("SanityImg", sanityObjs, sanityBar, sanitySprite);
            sanityText.text = $"{sanityObjs.Count}";
            sanityText.rectTransform.SetAsLastSibling();
        }
    }

    public void RemoveSanity(int delta)
    {
        for (int i = 0; i < delta; i++)
        {
            if (!RemoveStatusIcon(sanityObjs, sanityObjs.Count - 1)) return;
            sanityText.text = $"{sanityObjs.Count}";
            sanityText.rectTransform.SetAsLastSibling();
        }
    }

    private void AddStatusIcon(string iconType, List<GameObject> icons, GameObject bar, Sprite sprite)
    {
        GameObject add = new(iconType);
        add.transform.parent = bar.transform;
        Image img = add.AddComponent<Image>();
        img.sprite = sprite;
        img.rectTransform.sizeDelta = imgSize;
        icons.Add(add);
        float zOffset = -((RectTransform)add.transform).anchoredPosition3D.z;
        ((RectTransform)add.transform).anchoredPosition3D += new Vector3(0, 0, zOffset);
    }

    private bool RemoveStatusIcon(List<GameObject> icons, int index)
    {
        try
        {
            Destroy(icons[index]);
            icons.RemoveAt(index);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
