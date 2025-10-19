using UnityEngine;

public class DetectiveGM : MonoBehaviour
{
    public void MoverVest()
    {
        
        CameraManager.Instance.MoverAVestibulo();
        GameManager.Instance.ClearDialog();
    }

}

