using UnityEngine;
using UnityEngine.EventSystems;

public class RayHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Materiales")]
    public Material normalMaterial;
    public Material hoverMaterial;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Aseguramos que empieza con el material normal
        if (normalMaterial != null)
            spriteRenderer.material = normalMaterial;
    }

    // Detecta cuando el puntero entra (raycast del EventSystem)
    public void OnPointerEnter(PointerEventData eventData)
    {
  
        if (hoverMaterial != null && spriteRenderer != null)
        {
            spriteRenderer.material = hoverMaterial;
        }
    }

    // Detecta cuando el puntero sale (raycast del EventSystem)
    public void OnPointerExit(PointerEventData eventData)
    {
  

        if (normalMaterial != null && spriteRenderer != null)
        {
            spriteRenderer.material = normalMaterial;
        }
    }
}
