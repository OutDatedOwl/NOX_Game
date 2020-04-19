using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    string spell_ID;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            spell_ID = eventData.pointerDrag.name;
        }
    }

    public string Spell_Return()
    {
        if (spell_ID != null)
            return spell_ID;
        else
            return null;
    }
}
