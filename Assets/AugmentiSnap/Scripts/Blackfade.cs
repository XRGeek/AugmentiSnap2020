using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackfade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(TurnOffImage), 2);
    }

    // Update is called once per frame
   public void TurnOffImage()
    {
        GetComponent<Image>().enabled = false;
    }
}
