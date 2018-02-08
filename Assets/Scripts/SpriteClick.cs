using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteClick : MonoBehaviour
{
    public GameObject UIOverlay;
  
    private void OnMouseDown()
    {
        UIOverlay.SetActive(true);       
    }
}
