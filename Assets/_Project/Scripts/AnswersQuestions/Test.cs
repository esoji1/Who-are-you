using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    private Sequence _tween;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            _tween = DOTween.Sequence();

            _tween
                .Append(GameObject.transform.DOScale(3, 3f))
                .Join(GameObject.transform
                .DORotate(new Vector3(0f, 0f, 360f), 3f, RotateMode.FastBeyond360));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _tween.Kill();
            Destroy(gameObject);
        }
    }
}
