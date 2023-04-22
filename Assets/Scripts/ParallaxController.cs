using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _paralaxTransforms;
    [SerializeField] private float _borders;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private Parallax parallax;
    
    private void Update()
    {
        foreach (var parallaxTransform in _paralaxTransforms)
        {
            var parallaxTransformNextPosition = parallaxTransform.transform.position +
                        Vector3.right * (-Input.GetAxis("Horizontal") * parallax.Speed * _speedMultiplier * Time.deltaTime);
            if (parallaxTransformNextPosition.x < -_borders)
            {
                parallaxTransformNextPosition = new Vector3(-_borders, parallaxTransformNextPosition.y, 0);
            }

            parallaxTransform.transform.position = parallaxTransformNextPosition;
        }
        
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (_paralaxTransforms[0].transform.position.x <= -_borders)
            {
                _paralaxTransforms[0].transform.position =
                    new Vector2(_paralaxTransforms[^1].transform.position.x +
                                _paralaxTransforms[^1].bounds.extents.x * 2,
                        _paralaxTransforms[^1].transform.position.y);
                ArraySwapLeft();
            }
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            if (_paralaxTransforms[^1].transform.position.x >= _borders)
            {
                _paralaxTransforms[^1].transform.position =
                    new Vector2(_paralaxTransforms[0].transform.position.x -
                                _paralaxTransforms[0].bounds.extents.x * 2,
                        _paralaxTransforms[0].transform.position.y);
                ArraySwapRight();
            }
        }
    }


    private void ArraySwapLeft()
    {
        var first = _paralaxTransforms[0];
        var index = 1;
        while (index < _paralaxTransforms.Length)
        {
            _paralaxTransforms[index - 1] = _paralaxTransforms[index];
            index++;
        }

        _paralaxTransforms[^1] = first;
    }   
    
    private void ArraySwapRight()
    {
        var first = _paralaxTransforms[^1];
        var index = _paralaxTransforms.Length - 1;
        while (index > 0)
        {
            _paralaxTransforms[index] = _paralaxTransforms[index - 1];
            index--;
        }

        _paralaxTransforms[0] = first;
    }
    
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_borders, -100), new Vector2(_borders, +100));
        Gizmos.DrawLine(new Vector2(-_borders, -100),new Vector2(-_borders, +100));
    }
}
