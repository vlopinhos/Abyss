using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField]
    private float writeSpeed = 50f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        // yield return new WaitForSeconds(1);

        float t = 0;
        int charIndex = 0;

        audioSource.Play();

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime;
            charIndex = Mathf.FloorToInt(t * writeSpeed);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        audioSource.Stop();

        textLabel.text = textToType;
    }
}
