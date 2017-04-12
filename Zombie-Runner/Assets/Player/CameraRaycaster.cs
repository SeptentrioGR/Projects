using UnityEngine;
public class CameraRaycaster : MonoBehaviour
{
	public Layer[] layerPriorities = {
			 Layer.World,
		Layer.Interactable,
		Layer.Monster,
		Layer.NotInteractable,
		Layer.RaycastEndStop
	};
	Camera viewCamera;
	RaycastHit mRaycastHit;
	[SerializeField]
	float distanceToBackground = 100f;
	[SerializeField]
	float distance;



	public RaycastHit hit
	{
		get { return mRaycastHit; }
	}

	Layer mLayerHit;
	public Layer layerHit
	{
		get { return mLayerHit; }
	}

	public delegate void OnLayerChange(Layer newLayer);//declare new delegate type
	public OnLayerChange onLayerChange;//Instansiate a objserver set
	World_Interaction interactions;
	void Start()
	{
		viewCamera = Camera.main;
		interactions = new World_Interaction();
	}

	void Update()
	{
		foreach (Layer layer in layerPriorities)
		{
			var hit = RaycastForLayer(layer);
			if (hit.HasValue)
			{
				mRaycastHit = hit.Value;
				if (mLayerHit != layer)
				{
					//Debug.Log("Log " + mLayerHit);
					mLayerHit = layer;
					onLayerChange(layer);
				}
				mLayerHit = layer;

				if (Input.GetKeyDown(KeyCode.E))
				{
					interactions.hitSomethingInFrontOfMe(mRaycastHit);
				}

				return;
			}
		}

		// Otherwise return background hit
		mRaycastHit.distance = distanceToBackground;
		mLayerHit = Layer.RaycastEndStop;

	}

	RaycastHit? RaycastForLayer(Layer layer)
	{
		int layerMask = 1 << (int)layer; // See Unity docs for mask formation

		Ray ray = new Ray(Camera.main.transform.position, viewCamera.transform.forward);
		Debug.DrawRay(ray.origin, ray.direction, Color.blue, 0, true);
		RaycastHit hit; // used as an out parameter
		bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);

		if (hasHit)
		{
			return hit;
		}
		return null;
	}
}
