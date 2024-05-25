using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum ActionType { Observar, Atacar, Descansar};
    public ActionType actiontype;

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            Menu();
        }
    }

    public void Menu() 
    {
        switch (actiontype) 
        {
            case ActionType.Observar:
                Debug.Log("Observas tu alrededor");
                break;
            case ActionType.Atacar:
                Debug.Log("Inicias un ataque");
                break;
            case ActionType.Descansar:
                Debug.Log("No haces nada");
                break;
        }
    }
}
