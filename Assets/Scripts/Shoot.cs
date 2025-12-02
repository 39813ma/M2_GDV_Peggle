using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
    [SerializeField] private float maxLineLength = 10f;  // <-- maximale lijnlengte

    private float _pressTimer = 0f;
    private LineRenderer _line;
    private bool _lineActive = false;

    private void Update()
    {
        HandleShot();
    }

    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0f;
            _lineActive = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);
        }

        if (Input.GetMouseButton(0) && _pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }

        if (_lineActive)
        {
            // Bepaal lengte en begrens met maxLineLength
            float length = Mathf.Min(_pressTimer * forceBuild, maxLineLength);

            _line.SetPosition(1, Vector3.right * length);
        }
    }

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 2;
        _line.SetPosition(0, Vector3.zero);
        _line.SetPosition(1, Vector3.zero);
    }
}
