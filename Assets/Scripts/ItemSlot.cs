using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [HideInInspector] public string spell_ID;
    AudioSource audioSource;
    Image current_Spell_Image;
    Drag_Drop_Slot spell_Info;

    private void Start()
    {
        spell_Info = GetComponent<Drag_Drop_Slot>();
        audioSource = GetComponentInParent<AudioSource>();
        current_Spell_Image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            LockAndLoad(eventData);
            ColorChange(eventData);
            GetAudio(eventData);
            GiveSpellInfo(eventData);
        }
    }

    private void ColorChange(PointerEventData spell_Block)
    {
        if (spell_Block.pointerDrag.GetComponent<DragDrop>() != null)
        {
            current_Spell_Image.sprite = spell_Block.pointerDrag.GetComponent<DragDrop>().spell_Block_Sprite.GetComponent<Image>().sprite;
            current_Spell_Image.color = new Color(current_Spell_Image.color.r, current_Spell_Image.color.g, current_Spell_Image.color.b, 1);
        }
        if(spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>() != null && spell_ID != "")
        {
            current_Spell_Image.sprite = spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().spell_Block_Sprite.GetComponent<Image>().sprite;
            current_Spell_Image.color = new Color(current_Spell_Image.color.r, current_Spell_Image.color.g, current_Spell_Image.color.b, 1);
        }
    }

    private void GetAudio(PointerEventData spell_Block)
    {
        if (spell_Block.pointerDrag.GetComponent<DragDrop>() != null && spell_ID != "")
        {
            audioSource.clip = Game_Manager.Get().audioArray[6];
            audioSource.Play();
        }
        if (spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>() != null && spell_ID != "")
        {
            audioSource.clip = Game_Manager.Get().audioArray[6];
            audioSource.Play();
        }
    }

    private void LockAndLoad(PointerEventData spell_Block)
    {
        if (spell_Block.pointerDrag.GetComponent<DragDrop>() != null)
        {
            spell_Block.pointerDrag.GetComponent<DragDrop>().spell_Block_Sprite.GetComponent<RectTransform>().anchoredPosition
                = GetComponent<RectTransform>().anchoredPosition;
            spell_ID = spell_Block.pointerDrag.GetComponent<DragDrop>().spell_Block_Sprite.name;
            spell_Block.pointerDrag.GetComponent<DragDrop>().spell_Block_Sprite.SetActive(false);
        }

        if (spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>() != null)
        {
            spell_ID = spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().spell_Block_Sprite.name;
            if (spell_ID != "")
            {
                spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().spell_Block_Sprite.GetComponent<RectTransform>().anchoredPosition
                    = GetComponent<RectTransform>().anchoredPosition;
                spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().spell_Block_Sprite.SetActive(false);
            }
        }
    }

    private void GiveSpellInfo(PointerEventData spell_Block)
    {
        if (spell_Block.pointerDrag.GetComponent<DragDrop>() != null)
        {
            spell_Info.GimmeDatSpellInfo(spell_Block.pointerDrag.GetComponent<DragDrop>().spell_Block_Sprite,
                spell_Block.pointerDrag.GetComponent<DragDrop>().rectTransform,
                spell_Block.pointerDrag.GetComponent<DragDrop>().canvasGroup,
                spell_Block.pointerDrag.GetComponent<DragDrop>().image_Color);
        }
        if(spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>() != null && spell_ID != "")
        {
            spell_Info.GimmeDatSpellInfo(spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().spell_Block_Sprite,
            spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().rectTransform,
            spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().canvasGroup,
            spell_Block.pointerDrag.GetComponent<Drag_Drop_Slot>().image_Color);
        }

        //spell_Info.spell_Block_Sprite = spell_Block.pointerDrag.gameObject;
    }

    public string Spell_Return()
    {
        if (spell_ID != null)
            return spell_ID;
        else
            return null;
    }
}
