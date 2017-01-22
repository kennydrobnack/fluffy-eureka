using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BackgroundCollector : MonoBehaviour
{

    [SerializeField]
    private List<Transform> backgrounds = new List<Transform>();

	[SerializeField]
	public bool shiftRight = true;

    private Transform lastBg;


    // Use this for initialization
    void Start()
    {
        SetLastBg();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Background", System.StringComparison.CurrentCultureIgnoreCase))
        {
            MoveBG(collision);
            SetLastBg();
        }
    }

    private void SetLastBg()
    {
		if(shiftRight)
        	lastBg = backgrounds.OrderByDescending(x => x.position.x).FirstOrDefault();
		else
			lastBg = backgrounds.OrderByDescending(x => -1*x.position.x).FirstOrDefault();
		
    }

    private void MoveBG(Collider2D collision)
    {
        float bgWidth = lastBg.GetComponent<BoxCollider2D>().bounds.size.x;
        Vector3 newX = collision.transform.position;
		if (shiftRight)
			newX.x = lastBg.position.x + bgWidth;
		else
			newX.x = lastBg.position.x - bgWidth;
        collision.transform.position = newX;
    }
}
