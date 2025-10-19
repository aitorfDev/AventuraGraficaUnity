using System.Collections;
using UnityEngine;
using TMPro;

public class MaquinaEscribir : MonoBehaviour
{
    [SerializeField] private float millisecondsPerCharacter = 50f;

    private TextMeshProUGUI textMeshPro;
    private string fullText;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = textMeshPro.text;
    }

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.ForceMeshUpdate();
        var textInfo = textMeshPro.textInfo;

        // Hacer todas las letras transparentes al inicio
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (textInfo.characterInfo[i].isVisible)
            {
                int meshIndex = textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;

                for (int j = 0; j < 4; j++)
                    vertexColors[vertexIndex + j].a = 0;
            }
        }
        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

        float delay = millisecondsPerCharacter / 1000f;

        // Mostrar las letras una a una
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (textInfo.characterInfo[i].isVisible)
            {
                int meshIndex = textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = textInfo.meshInfo[meshIndex].colors32;

                for (int j = 0; j < 4; j++)
                    vertexColors[vertexIndex + j].a = 255;

                textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}