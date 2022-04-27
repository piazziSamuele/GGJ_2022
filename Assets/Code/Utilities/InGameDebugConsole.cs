using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDebugConsole : MonoBehaviour
{

    public DebugMessage[] m_messages = new DebugMessage[0];
    public static InGameDebugConsole IGDebugConsole = null;
    // Start is called before the first frame update
    void Awake()
    {
        if( IGDebugConsole == null )
        {
            IGDebugConsole = this;
        }
        else
        {
            DestroyImmediate( this );
        }
    }

    public void ShowMessage(string debugmessage, uint issueType = 0)
    {
        bool foundMessageAvailableFromPool = false;

        for (int i = 0; i < m_messages.Length; i++)
        {
            if( m_messages[i].gameObject.activeSelf == false )
            {
                m_messages[i].ShowMessage( debugmessage, issueType);
                foundMessageAvailableFromPool = true;
                break;
                
            }
        }

        if( foundMessageAvailableFromPool == false )
        {
            transform.GetChild(transform.childCount - 1).GetComponent<DebugMessage>().ShowMessage(debugmessage, issueType);
        }
    }


}
