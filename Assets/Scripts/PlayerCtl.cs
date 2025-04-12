using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCtl : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject WinPn;
    [SerializeField] private GameObject LosePn;
    [SerializeField] private TMP_Text num;
    private float Boot;
    public bool ismove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)) {
            BottonDown();
            Debug.Log("Asd");
        }

        PlayerMove();
    }

    private void PlayerMove()
    {
        if (ismove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
/*        transform.Translate(Vector3.right * speed * Time.deltaTime);
*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            speed = 3;
        }
        if (collision.gameObject.CompareTag("Slow"))
        {
            speed = 2;
        }
        if (collision.gameObject.CompareTag("Van"))
        {
            speed = 5;
        }
        if (collision.gameObject.CompareTag("SpeedUp"))
        {
            speed = 6;
        }
        if (collision.gameObject.CompareTag("DungNham"))
        {
            WinPn.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Energy"))
        {
            Boot++;
            num.text = Boot.ToString();
        }
        if (collision.gameObject.CompareTag("Die"))
        {
            LosePn.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void BottonDown() { ismove = true; }
    public void BottonUp() { ismove = false; }
    public void BottonDownBoot()
    {
        if (Boot > 0)
        {
            StartCoroutine(TemporarySpeedBoost());
        }
    }

    private IEnumerator TemporarySpeedBoost()
    {
        Boot--;
        num.text = Boot.ToString();
        float originalSpeed = 3;
        speed = speed+2;
        yield return new WaitForSeconds(0.5f);
        speed = originalSpeed;
    }
}
