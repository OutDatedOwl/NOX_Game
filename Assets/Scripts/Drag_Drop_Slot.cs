using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_Drop_Slot : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [HideInInspector] public GameObject spell_Block_Sprite;
    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public Image image_Color;
    ItemSlot item_Slot;
    AudioSource audioSource;

    private void Awake()
    {
        item_Slot = GetComponent<ItemSlot>();
        audioSource = GetComponentInParent<AudioSource>();
        //rectTransform = spell_Block_Sprite.GetComponent<RectTransform>();
        //canvasGroup = spell_Block_Sprite.GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (spell_Block_Sprite != null)
        {
            spell_Block_Sprite.gameObject.SetActive(true);
            spell_Block_Sprite.transform.position = eventData.position;
            //image_Color.color = new Color(image_Color.color.r, image_Color.color.g, image_Color.color.b, 1);
            PullSpellSound();
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform != null && item_Slot.spell_ID != "")
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true;
        }
    }

    private void PullSpellSound()
    {
        audioSource.clip = Game_Manager.Get().audioArray[5];
        audioSource.Play();
    }

    public void GimmeDatSpellInfo(GameObject spell_BlockObj, RectTransform spell_BlockRectTrans, CanvasGroup spell_BlockCanvasGr, Image spell_BlockImage)
    {
        spell_Block_Sprite = spell_BlockObj;
        rectTransform = spell_BlockRectTrans;
        canvasGroup = spell_BlockCanvasGr;
        image_Color = spell_BlockImage;
    }
}
