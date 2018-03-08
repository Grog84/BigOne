using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconOrientation : MonoBehaviour {

    private void Update()
    {
        
        transform.DOLookAt(Camera.main.transform.position, 0.1f);
    }
}
