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
        cam.aspect = 16f / 9f; // tu relación deseada, ej. 16:9
    }

    void Update()
    {
        // Mantén el aspecto fijo incluso si cambias el tamaño de la ventana
        cam.aspect = 16f / 9f;
    }
}
