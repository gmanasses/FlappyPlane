using UnityEngine;

public class CarouselController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _speed = 5;
    private Vector3 _initialPosition;
    private float _realImageSize;


    // --- Core Functions ---
    private void Awake() {
        _initialPosition = transform.position;

        float imageSize = this.GetComponent<SpriteRenderer>().size.x;
        float scale = this.transform.localScale.x;
        _realImageSize = imageSize * scale;
    }

    private void Update() {
        float imageShift = Mathf.Repeat(_speed * Time.time, _realImageSize);
        transform.position = _initialPosition + (Vector3.left * imageShift);
    }

}
