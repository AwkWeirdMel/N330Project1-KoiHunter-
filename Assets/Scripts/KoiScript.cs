using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiScript : MonoBehaviour, IClicked
{
    public void onClickAction()
    {
        Destroy(gameObject);
    }

}
