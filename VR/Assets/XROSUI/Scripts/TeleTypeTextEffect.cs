using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleTypeTextEffect : MonoBehaviour
{
    private TMP_Text m_textMeshPro;
    private string m_previousTextString;
    string[] m_textCharacter;

    bool isActive;
    public float m_timeInSeconds;
    float m_timer;
    int m_charCount;

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text currentText = GetComponent<TMP_Text>();
        m_previousTextString = currentText.text;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            m_textMeshPro = GetComponent<TMP_Text>();
        }

        if (!isActive && (m_textMeshPro.text != m_previousTextString))
        {
            // print("text updated");
            isActive = true;
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textCharacter = new string[m_textMeshPro.text.Length];
            for (int i = 0; i < m_textMeshPro.text.Length; i++)
            {
                m_textCharacter[i] = m_textMeshPro.text.Substring(i, 1);
            }
            m_textMeshPro.text = "";
            m_charCount = 0;
            m_timer = 0;
        }
        if (isActive)
        {
            // print("running teletype");
            if (m_charCount < m_textCharacter.Length)
            {
                m_timer += Time.deltaTime;
                if (m_timer >= m_timeInSeconds)
                {
                    m_textMeshPro.text += m_textCharacter[m_charCount];
                    m_charCount++;
                    m_timer = 0;
                }
                if (m_charCount == m_textCharacter.Length)
                {
                    m_previousTextString = m_textMeshPro.text;
                    isActive = false;
                }
            }
        }
    }
}
