using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    public float ballspeed = 0.0f;
    public float jumpspeed = 0.0f;
    public float jumpheight = 0.0f; 
    private bool istouching = true;
    public int counter;
    public Text cointext;
    public int coinamount;
    public AudioSource railingasource;
    public AudioClip railingaclip;
    public AudioSource coinsasource;
    public AudioClip coinsaclip;
    public AudioSource cubeasource;
    public AudioClip cubeaclip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        cointext.text = "COINS: "+ counter;
    }

    // Update is called once per frame
    void Update()
    {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");

        Vector3 ballmove = new Vector3 (Hmove,0,Vmove);

     rb.AddForce (ballmove*ballspeed);

     if(istouching == true)
     {
     if (Input.GetKey(KeyCode.Space))
     {
     Vector3 balljump = new Vector3 (0,jumpheight,0);
      rb.AddForce(balljump*jumpspeed);
     }
     }
     istouching = false;
    }
     private void OnCollisionStay()
     {
     istouching = true;
     }
     public void OnTriggerEnter(Collider other)
    {
if (other.gameObject.CompareTag("CoinsTag"))
{
    other.gameObject.SetActive(false);
    counter = counter - coinamount;
    cointext.text = "COINS: "+ counter;

    if (counter == 0)
    {
SceneManager.LoadScene("EndScene");
    }
    coinsasource.PlayOneShot(coinsaclip);
}
if (other.gameObject.CompareTag("RailingTag"))
{
   railingasource.PlayOneShot(railingaclip); 
}
    }
}
