using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMessage : MonoBehaviour
{
    private Text m_textComponent;
    private const float SHOW_TIMER_LENTGH = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (m_textComponent == null)
        {
            m_textComponent = GetComponent<Text>();
            gameObject.SetActive(false);
        }

    }


    public void ShowMessage( string message, uint logType) // 0 = log / 1 = warning / 2 = error
    {
        StopCoroutine(HideMessage());
        gameObject.SetActive(true);
        transform.SetAsFirstSibling();
        m_textComponent.text = message;

        if( logType == 2 )
        {
            m_textComponent.color = Color.red;
        }
        else if( logType == 1 )
        {
            m_textComponent.color = Color.yellow;
        }
        else
        {
            m_textComponent.color = Color.green;
        }

        StartCoroutine(HideMessage());
    }

    

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(SHOW_TIMER_LENTGH);
        gameObject.SetActive(false);
    }
}
