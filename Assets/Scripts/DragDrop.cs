using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] public GameObject spell_Block_Sprite;
    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public Image image_Color;
    AudioSource audioSource;

    private void Awake()
    {
        rectTransform = spell_Block_Sprite.GetComponent<RectTransform>();
        canvasGroup = spell_Block_Sprite.GetComponent<CanvasGroup>();
        audioSource = spell_Block_Sprite.GetComponentInParent<AudioSource>();
        image_Color = spell_Block_Sprite.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        spell_Block_Sprite.SetActive(true);
        spell_Block_Sprite.transform.position = eventData.position;
        //image_Color.color = new Color(image_Color.color.r, image_Color.color.g, image_Color.color.b, 1);
        PullSpellSound();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    private void PullSpellSound()
    {
        audioSource.clip = Game_Manager.Get().audioArray[5];
        audioSource.Play();
    }
}
