using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Mouse Sway")]
    public float mouseSwayAmount = 0.0f;
    public float mouseSwaySmooth = 6f;

    [Header("Movement Sway")]
    public float moveSwayAmount = 0.1f;
    public float moveSwaySpeed = 6f;

    private Vector3 initialPosition;
    private float moveTimer;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Mouse sway (kamera dönüşüne bağlı)
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 swayMouse = new Vector3(-mouseY, mouseX, 0) * mouseSwayAmount;

        // Hareket sway (yürüme gibi)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            moveTimer += Time.deltaTime * moveSwaySpeed;
            float swayX = Mathf.Sin(moveTimer) * moveSwayAmount;
            float swayY = Mathf.Cos(moveTimer * 2f) * moveSwayAmount * 0.5f;
            swayMouse += new Vector3(swayY, swayX, 0);
        }
        else
        {
            moveTimer = 0;
        }

        // Hedef pozisyon ve geçiş
        Vector3 targetPosition = initialPosition + swayMouse;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * mouseSwaySmooth);
    }
}