using Unity.Mathematics;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float _speed;
    [SerializeField] private bool _isFacingRight;
    
    void Update()
    {
        _speed = Input.GetAxis("Horizontal");
        if (_speed < 0 && _isFacingRight || _speed > 0 && !_isFacingRight)
        {
            SwapRotation();
        }


        _animator.SetFloat("Speed", Mathf.Abs(_speed));
    }

    private void SwapRotation()
    {
        _isFacingRight = !_isFacingRight;
        transform.rotation = Quaternion.Euler(0, _isFacingRight ? 0 : 180, 0);
    }
}
