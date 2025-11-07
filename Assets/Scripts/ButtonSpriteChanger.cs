using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSpriteChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public Sprite clickSprite;
    public float clickSpriteDuration = 0.5f; // Duration to show the click sprite
    public AudioClip clickSound; // Audio clip to play on click

    private Image buttonImage;
    private AudioSource audioSource;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultSprite;

        // Add AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonImage.sprite = clickSprite;
        StartCoroutine(RevertToDefaultSpriteAfterDelay());

        // Play click sound
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private IEnumerator RevertToDefaultSpriteAfterDelay()
    {
        yield return new WaitForSeconds(clickSpriteDuration);
        buttonImage.sprite = defaultSprite;
    }
}
