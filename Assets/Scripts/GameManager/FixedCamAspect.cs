using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedCamAspect : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        cam.aspect = 16f / 9f; // tu relaci�n deseada, ej. 16:9
    }

    void Update()
    {
        // Mant�n el aspecto fijo incluso si cambias el tama�o de la ventana
        cam.aspect = 16f / 9f;
    }
}
