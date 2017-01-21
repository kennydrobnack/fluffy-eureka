using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour {

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("player", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Time.timeScale = 0;
        }
    }
}
