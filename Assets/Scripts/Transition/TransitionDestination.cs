using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDestination : MonoBehaviour
{
    public enum DestinationTag
    {
        NULL,
        Scene_01,
        A01,
        B01,
        C01,
        D01,
        Scene_02,
        A02,
        B02,
        C02,
        D02,
        
    }
   

    public DestinationTag destinationtag;
}
