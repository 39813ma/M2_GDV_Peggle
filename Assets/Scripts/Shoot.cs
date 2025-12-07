using UnityEngine;
public class Shoot : MonoBehaviour
{
    [SerializeField] private float lineSpeed = 5f;
    private LineRenderer _line;
    private bool _lineActive = false;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 10f;
    [SerializeField] private float maximumHoldTime = 2f;

    private float _pressTimer = 0f;
    private float _launchForce = 0f;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(1, Vector3.zero);

    }
    private void Update()
    {
        HandleShot();
    }
    //Die functie scrijven we zelf
    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0f;
            _lineActive = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0;

        }
        if (Input.GetMouseButtonUp(0))
        {

            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;

            GameObject ball = Instantiate(prefab, transform.parent);

            ball.transform.rotation = transform.rotation;

            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);

            ball.transform.position = transform.position;
        }
        if (_pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }
        if (_lineActive)
        {
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }
    }
}