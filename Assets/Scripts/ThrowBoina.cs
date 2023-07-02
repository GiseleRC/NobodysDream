using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoina : MonoBehaviour
{
    [SerializeField] float speed, distance, speedRot;
    float actualTime;
    bool reverse;
    Transform character;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        actualTime = distance;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        character = GameObject.Find("Char").GetComponent<Transform>();
        actualTime -= Time.deltaTime;
        Vector3 headPos = new Vector3(character.position.x, character.position.y + .7f, character.position.z);
        if (!reverse)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, headPos, speed / 1.3f * Time.deltaTime);
        }

        transform.GetChild(0).transform.Rotate(0, speedRot * Time.deltaTime, 0);

        if (actualTime < 0 && !reverse)
        {
            reverse = true;
        }

        float distance = Vector3.Distance(transform.position, headPos);

        if(distance < .3 && reverse)
        {
            character.GetComponent<BoinaMec>().CantUse = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char" && reverse)
        {
            other.gameObject.GetComponent<BoinaMec>().CantUse = false;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Colectible")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        reverse = true;
    }
}
