using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private Image _image;
    
    /// <summary>
    /// Image UI component of this tile.
    /// </summary>
    public Image Image
    {
        get
        {
            return _image;
        }
    }

    // Use this for initialization
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
