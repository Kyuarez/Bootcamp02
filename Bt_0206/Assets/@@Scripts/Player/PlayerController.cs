using Bootcamp0207;
using System.Collections;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }

    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float sleepTime = 5.0f;
    private Vector3 movement = Vector3.zero;


    private Rigidbody rigid;
    private Animator animator;

    private bool isSleep;


    public Vector3 CurrentPos { get { return transform.position; } }


    private void Awake()
    {
        _instance = this;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isSleep = false;
    }


    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        if(isSleep == false)
        {
            Move();
        }
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if(movement.magnitude > 0)
        {
            movement.Normalize();
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        rigid.linearVelocity = movement * moveSpeed;

    }

    private void UpdateState()
    {
        if(Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.z, 0))
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }

        if(isSleep == true)
        {
            animator.SetBool("isSleep", true);
        }
        else
        {
            animator.SetBool("isSleep", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (true == other.gameObject.CompareTag("MusicSpot"))
        {
            StartCoroutine(CoOnSleep());           
        }
    }

    #region Coroutine
    IEnumerator CoOnSleep()
    {
        isSleep = true;
        movement = new Vector3(Mathf.Lerp(movement.x, 0, 0.5f * Time.deltaTime), 0f, Mathf.Lerp(movement.z, 0, 0.5f * Time.deltaTime));
        animator.SetBool("isSleep", true);
        yield return new WaitForSeconds(0.1f);
        PopupUI.Instance?.OnPopupUI();
        yield return new WaitForSeconds(sleepTime);
        isSleep = false;
        animator.SetBool("isSleep", false);
    }

    #endregion
}
