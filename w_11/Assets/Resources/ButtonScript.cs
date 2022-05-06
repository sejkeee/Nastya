using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject Panel;
    public Image UImage;
    public Sprite NewImage;

    public void Close()
    {
        Panel.SetActive(false);
    }
    
    public void SetNewImage()
    {
        UImage.sprite = NewImage;
    }
}
