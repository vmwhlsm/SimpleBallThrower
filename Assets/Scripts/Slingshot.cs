using JetBrains.Annotations;
using Models;
using UnityEngine;
using UnityEngine.Serialization;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _maxLength;
    [SerializeField] private float _slingshotPower = 100f;

    private bool _isMouseDown;
    private float _mousePositionInZ = 10;
    private Camera _camera;
    private Vector3 _stripPosition;
    private Vector3 _lastStripPosition;
    private Rigidbody2D _ballRigidbody;
    [CanBeNull] private GameObject _activeBall;

    public delegate void CreateBallDelegate(BallData ballData);
    public delegate void ThrowBallDelegate(int index, Vector3 force);

    public event CreateBallDelegate BallCreated;
    public event ThrowBallDelegate BallThrown;

    private void Start()
    {
        _camera = Camera.main;
        _lineRenderer.positionCount = 2;
    }

    private void FixedUpdate()
    {
        if (_isMouseDown)
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = _mousePositionInZ;

            var currentPosition = _camera.ScreenToWorldPoint(mousePosition);
            currentPosition = _stripPosition + Vector3.ClampMagnitude(currentPosition - _stripPosition, _maxLength);
            _lastStripPosition = currentPosition;
            SetStripPosition(currentPosition);
            
            if (_activeBall == null) 
                return;
            
            _activeBall.transform.position = currentPosition;
        }
        else
        {
            ResetStrip();
        }
    }

    private void ResetStrip()
    {
        _lineRenderer.enabled = false;
    }

    private void SetStripPosition(Vector3 vector)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(1, vector);
    }

    private void ThrowBall(Vector3 position)
    {
        _activeBall = null;
        var dir = (position - _stripPosition) * -1;
        BallThrown?.Invoke(_ballRigidbody.gameObject.GetInstanceID(), dir * _slingshotPower);
    }   

    private void CreateBall()
    {
        var ball = Instantiate(_ballPrefab, _stripPosition, Quaternion.identity);
        _ballRigidbody = ball.GetComponent<Rigidbody2D>();
        _ballRigidbody.GetComponent<Collider2D>().enabled = false;
        _ballRigidbody.isKinematic = true;
        _activeBall = ball;
        BallCreated?.Invoke(new BallData(_ballRigidbody, ball));
    }

    private void OnMouseDown()
    {
        if (!_isMouseDown)
        {
            var position = Input.mousePosition;
            position.z = _mousePositionInZ;
            _stripPosition = _camera.ScreenToWorldPoint(position);
            CreateBall();
            _lineRenderer.SetPosition(0, _stripPosition);
        }

        _isMouseDown = true;
    }

    private void OnMouseUp()
    {
        _isMouseDown = false;
        ThrowBall(_lastStripPosition);
    }
}