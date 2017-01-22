using UnityEngine;
using System.Collections;

public class MonetizrExample : MonoBehaviour
{
	// Example usage (this function is not called in the demo scene)
	void LevelCompleted ()
	{
		// ...

		// Show product with ID 9359302538
		Monetizr.Instance.ShowProductWithID("9359302538");

		// ...
	}
}
