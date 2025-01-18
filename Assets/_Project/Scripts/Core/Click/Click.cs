using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private AudioSource _click;

    private int _leftMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
            _click.Play();
    }
}
