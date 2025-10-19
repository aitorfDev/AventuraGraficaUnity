using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField] private Camera mainCam;

    void Awake()
    {
        // Asegura que solo haya una instancia del CameraManager
        if (Instance == null)
        {
            Instance = this;

            if (mainCam == null)
            {
                mainCam = Camera.main;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoverACocina()
    {
        mainCam.transform.position = new Vector3(-80, -5, -20);
    }

    public void MoverAComedor()
    {
        mainCam.transform.position = new Vector3(-60, -5, -20);
    }

    public void MoverAVestibulo()
    {
        mainCam.transform.position = new Vector3(-40, -5, -20);
    }

    public void MoverAExterior()
    {
        mainCam.transform.position = new Vector3(-20, -5, -20);
    }
    public void MoverATexto()
    {
        mainCam.transform.position = new Vector3(-120, -5, -20);
    }
}
