using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }

    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float maxSpeed = 5f;

    private Rigidbody rigid;

    public Vector3 CurrentPos { get { return transform.position; } }


    private void Awake()
    {
        _instance = this;
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3 (horizontalKey, 0f ,verticalKey).normalized * moveSpeed;
        rigid.AddForce (moveVec, ForceMode.Acceleration);
        
        if (rigid.linearVelocity.magnitude > maxSpeed)
        {
            rigid.linearVelocity = rigid.linearVelocity.normalized * maxSpeed;
        }

    }
}
