using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    float _heading;
    [SerializeField] float _speed;
    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _heading = Random.Range(0f, 360f);
        _velocity = new Vector3(Mathf.Cos(_heading),Mathf.Sin(_heading), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _velocity * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public float getHeading()
    {
        return _heading;
    }
}
