using UnityEngine;
using UnityEngine.UI;

public class SampleButtonPanel : MonoBehaviour
{
    [SerializeField] private Button btn_Add;
    [SerializeField] private Button btn_Remove;
    [SerializeField] private Button btn_Reset;

    private CircleClick circleHandler;

    private void Start()
    {
        circleHandler = GameObject.Find("Sphere")?.GetComponent<CircleClick>();

        btn_Add.onClick.AddListener(circleHandler.OnClickAdd);
        btn_Remove.onClick.AddListener(circleHandler.OnClickRemove);
        btn_Reset.onClick.AddListener(circleHandler.OnClickReset);

    }
}
