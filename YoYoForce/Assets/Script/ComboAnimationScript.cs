using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboAnimationScript : MonoBehaviour
{

    public void EventDestroy(){
        Destroy(this.gameObject.transform.parent.gameObject);
        Destroy(this.gameObject);
    }
}
