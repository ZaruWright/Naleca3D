using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NalecaDebug : MonoBehaviour {

	public enum Severity
    {
        Debug,
        Warning,
        Error
    }

    static public void Log(string message, Severity severity = Severity.Debug)
    {
        switch (severity)
        {
            case Severity.Debug:
                Debug.Log("<color=black>Debug: " + message + "</color>");
                break;
            case Severity.Warning:
                Debug.Log("<color=yellow>Warning: " + message + "</color>");
                break;
            case Severity.Error:
                Debug.Log("<color=red>Error: " + message + "</color>");
                break;
        }
    }
}
