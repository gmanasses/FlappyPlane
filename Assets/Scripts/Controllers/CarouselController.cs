using UnityEngine;

public class CarouselController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _speed = 5;
    private Vector3 _initialPosition;
    private float _realImageSize;


    // --- Core Functions ---
    private void Awake() {
        this._initialPosition = this.transform.position;

        float imageSize = this.GetComponent<SpriteRenderer>().size.x;
        float scale = this.transform.localScale.x;
        _realImageSize = imageSize * scale;
    }

    private void Update() {
        float imageShift = Mathf.Repeat(this._speed * Time.time, _realImageSize);
        this.transform.position = this._initialPosition + (Vector3.left * imageShift);
    }

}
