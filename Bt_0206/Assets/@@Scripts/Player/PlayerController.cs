using Bootcamp0207;
using System.Collections;
using UnityEngine;




[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }


    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float rotationSpeed = 2.0f;

    [Header("Animation Time")]
    [SerializeField] private float sleepTime = 10f;
    [SerializeField] private float tvTime = 20f;


    private Vector3 movement = Vector3.zero;
    private Rigidbody rigid;
    private Animator animator;

    private bool isSleep;
    private bool isTV;
    private bool isDead;


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
        isTV = false;
        isDead = false;
    }


    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        if(isSleep == false && isTV == false && isDead == false)
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
        if(isDead == true)
        {
            return;
        }

        if (true == Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 5;
            animator.SetBool("isFly", true);
            if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.z, 0))
            {
                animator.SetBool("isFlyMove", false);
            }
            else
            {
                animator.SetBool("isFlyMove", true);
            }
        }
        else 
        {
            moveSpeed = 2.5f;
            animator.SetBool("isFly", false);
            if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.z, 0))
            {
                animator.SetBool("isMove", false);
            }
            else
            {
                animator.SetBool("isMove", true);
            }
        }
        

        if (animator.GetBool("isSleep") != isSleep)
        {
            animator.SetBool("isSleep", isSleep);
        }

        if (animator.GetBool("isTV") != isTV)
        {
            animator.SetBool("isTV", isTV);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (true == other.gameObject.CompareTag("MusicSpot"))
        {
            StartCoroutine(CoOnSleep());
        }

        if(true == other.gameObject.CompareTag("TVSpot"))
        {
            StartCoroutine(CoOnTV());
        }
    }

    #region Coroutine
    IEnumerator CoOnSleep()
    {
        isSleep = true;
        movement = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        PopupUI.Instance?.OnPopupUI(PopupType.Sleep);
        yield return new WaitForSeconds(sleepTime);
        isSleep = false;
    }

    IEnumerator CoOnTV()
    {
        isTV = true;
        movement = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        PopupUI.Instance?.OnPopupUI(PopupType.TV);
        yield return new WaitForSeconds(tvTime);
        isTV = false;
    }
    #endregion

    #region Event
    public void OnDamageByEvent()
    {
        PopupUI.Instance?.OnPopupUI(PopupType.Damage);
    }

    public void OnDeadByEvent()
    {
        isDead = true;
        if (animator.GetBool("isDead") != isDead)
        {
            animator.SetBool("isDead", isDead);
        }
        PopupUI.Instance?.OnPopupUI(PopupType.Dead);
    }
    #endregion
}
