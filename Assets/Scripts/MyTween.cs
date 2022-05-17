using System.Collections;
using UnityEngine;

public static class MyTween
{
    private class TweenRunner : MonoBehaviour
    {
        private static TweenRunner runner;
        
        public static TweenRunner Current
        {
            get
            {
                if (runner == null)
                {
                    runner = new GameObject("Tween Runner", typeof(TweenRunner)).GetComponent<TweenRunner>();
                    DontDestroyOnLoad(runner.gameObject);
                }

                return runner;
            }
        }
    }

    private static TweenRunner tweenRunner => TweenRunner.Current;
    
    public static Coroutine Move(this Transform transform, Vector3 to, float duration = default, AnimationCurve curve = default)
    {
        return tweenRunner.StartCoroutine(Animation());

        IEnumerator Animation()
        {
            if (duration <= 0f)
            {
                transform.position = to;
                yield break;
            }
            
            float speed = 1f / duration;
            float t = 0f;

            Vector3 start = transform.position;

            bool useCurve = curve != null;
            
            while (true)
            {
                t += Time.deltaTime * speed;

                if (t >= 1f)
                {
                    transform.position = to;
                    yield break;
                }

                transform.position = Vector3.Lerp(start, to, useCurve ? curve.Evaluate(t) : t);

                yield return null;
            }
        }
    }
    
    public static Coroutine MoveX(this Transform transform, float to, float duration = default, AnimationCurve curve = default)
    {
        return tweenRunner.StartCoroutine(Animation());

        IEnumerator Animation()
        {
            if (duration <= 0f)
            {
                var oldPosition = transform.position;
                oldPosition.x = to;
                transform.position = oldPosition;
                yield break;
            }
            
            float speed = 1f / duration;
            float t = 0f;

            float start = transform.position.x;

            bool useCurve = curve != null;
            
            while (true)
            {
                t += Time.deltaTime * speed;

                var oldPosition = transform.position;

                if (t >= 1f)
                {
                    t = 1f;
                    oldPosition.x = Mathf.Lerp(start, to, useCurve ? curve.Evaluate(t) : t);
                    transform.position = oldPosition;
                    yield break;
                }

                oldPosition.x = Mathf.Lerp(start, to, useCurve ? curve.Evaluate(t) : t);

                transform.position = oldPosition;

                yield return null;
            }
        }
    }
    
    public static Coroutine MoveY(this Transform transform, float to, float duration = default, AnimationCurve curve = default)
    {
        return tweenRunner.StartCoroutine(Animation());

        IEnumerator Animation()
        {
            if (duration <= 0f)
            {
                var oldPosition = transform.position;
                oldPosition.y = to;
                transform.position = oldPosition;
                yield break;
            }
            
            float speed = 1f / duration;
            float t = 0f;

            float start = transform.position.y;

            bool useCurve = curve != null;
            
            while (true)
            {
                t += Time.deltaTime * speed;

                var oldPosition = transform.position;

                if (t >= 1f)
                {
                    t = 1f;
                    oldPosition.y = Mathf.Lerp(start, to, useCurve ? curve.Evaluate(t) : t);
                    transform.position = oldPosition;
                    yield break;
                }

                oldPosition.y = Mathf.Lerp(start, to, useCurve ? curve.Evaluate(t) : t);

                transform.position = oldPosition;

                yield return null;
            }
        }
    }
    
    public static Coroutine RotateY(this Transform transform, float angle, float duration = default, AnimationCurve curve = default)
    {
        return tweenRunner.StartCoroutine(Animation());

        IEnumerator Animation()
        {
            if (duration <= 0f)
            {
                var oldRotation = transform.eulerAngles;
                oldRotation.y = angle;
                transform.eulerAngles = oldRotation;
                yield break;
            }
            
            float speed = 1f / duration;
            float t = 0f;

            Vector3 start = transform.eulerAngles;

            bool useCurve = curve != null;

            while (true)
            {
                t += Time.deltaTime * speed;

                if (t >= 1f)
                {
                    transform.eulerAngles = new Vector3(start.x, angle, start.z);
                    yield break;
                }

                var lerpedAngle = Mathf.LerpAngle(start.y, angle, useCurve ? curve.Evaluate(t) : t);

                transform.eulerAngles = new Vector3(start.x, lerpedAngle, start.z);

                yield return null;
            }
        }
    } 
}
