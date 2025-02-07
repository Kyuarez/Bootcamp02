using UnityEngine;

public class TopDownCamController : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private Vector3 fixedPos = new Vector3(-2.5f, 5.0f, -5f);
    [SerializeField] private float fixedR_X = 30f;
    [SerializeField] private float fixedR_Y = 10f;
    [SerializeField] private float smoothSpeed = 2.0f;

    private void Awake()
    {
        cam = GetComponent<Camera>();

        cam.transform.position = fixedPos;
        cam.transform.rotation = Quaternion.Euler(fixedR_X, fixedR_Y, 0f);

    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPos = new Vector3(fixedPos.x + PlayerController.Instance.CurrentPos.x, fixedPos.y, fixedPos.z + PlayerController.Instance.CurrentPos.z);
        cam.transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
