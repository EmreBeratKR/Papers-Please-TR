using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Person
{
    public class BodyGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer face;
        [SerializeField] private SpriteContainer[] bodyParts;

        [Header("Fade Animation")]
        [SerializeField] private AnimationCurve fadeCurve;
        [SerializeField] private float fadeSpeed;

        
        public void Generate()
        {
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.Generate();
            }
        }

        [Button()]
        public Coroutine Illuminate()
        {
            return StartCoroutine(Fade());

            IEnumerator Fade()
            {
                float t = 1f;

                while (true)
                {
                    t -= Time.deltaTime * fadeSpeed;

                    if (t <= 0f)
                    {
                        SetColor(Color.white);
                        yield break;
                    }
                    
                    SetColor(Color.Lerp(Color.white, Color.black, fadeCurve.Evaluate(t)));

                    yield return null;
                }
            }
        }
        
        [Button()]
        public Coroutine BlackOut()
        {
            return StartCoroutine(Fade());

            IEnumerator Fade()
            {
                float t = 0f;

                while (true)
                {
                    t += Time.deltaTime * fadeSpeed;

                    if (t >= 1f)
                    {
                        SetColor(Color.black);
                        yield break;
                    }
                    
                    SetColor(Color.Lerp(Color.white, Color.black, fadeCurve.Evaluate(t)));

                    yield return null;
                }
            }
        }
        
        
        private void SetColor(Color color)
        {
            face.color = color;
            
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.SetColor(color);
            }
        }
    }
}
