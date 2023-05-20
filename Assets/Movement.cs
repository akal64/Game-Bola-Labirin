using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    [SerializeField] PopUp popup;
    [SerializeField] Image HPBar;
    [SerializeField] ParticleSystem Dead;
    [SerializeField] Animator coundown;

    private Rigidbody rb;
    private AudioSource sfx;
    private AccelerometerCalibration accelerometerCalibration;
    private float maxAcceleration = 50f;
    public float HP = 100f;

    private void Start()
    {
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody>();
        accelerometerCalibration = FindObjectOfType<AccelerometerCalibration>();
        sfx = GameObject.Find("SFX").GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (coundown.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        Vector3 acceleration = accelerometerCalibration.GetCalibratedAcceleration();
        // Mengatur batas maksimal percepatan agar pergerakan tidak terlalu kuat
        acceleration = Vector3.ClampMagnitude(acceleration, maxAcceleration);

        // Menghitung vektor gerakan berdasarkan percepatan
        Vector3 movement = new Vector3(acceleration.x, 0f, acceleration.y);
        movement = movement.normalized * movementSpeed * Time.deltaTime;

        // Menggerakkan pemain
        rb.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            sfx.Play();
            HP -= 10f;
            HPBar.fillAmount = HP / 100f;
            if (HP == 0f)
            {
                gameObject.SetActive(false);
                Dead.transform.position = transform.position;
                Dead.Play();
                Invoke("WaitPopUp", 1f);

            }
        }
        if (other.transform.CompareTag("Respawn"))
        {
            HP -= 5f;
            HPBar.fillAmount = HP / 100f;
            transform.position = transform.position + new Vector3(27f, 1f, 2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            popup.Popup();
        }
    }
    private void WaitPopUp()
    {
        popup.Popup();
    }
}
