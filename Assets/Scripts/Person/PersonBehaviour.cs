using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using Worlds;

namespace Person
{
    public class PersonBehaviour : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PersonGenerator personGenerator;
        
        [Header("Move Animation")]
        [SerializeField] private AnimationCurve motionCurve;
        [SerializeField] private AnimationCurve heightCurve;
        [SerializeField] private float enterBoothDuration;
        [SerializeField] private float exitBoothDuration;
        [SerializeField] private float deltaHeight;

        
        [Button()]
        public void GoBoothEntrance()
        {
            transform.position = World.BoothEntrance;
        }
        
        [Button()]
        public void EnterBooth()
        {
            StartCoroutine(Move());


            IEnumerator Move()
            {
                personGenerator.BlackOut();

                transform.MoveY(transform.position.y + deltaHeight, enterBoothDuration, heightCurve);
                yield return transform.MoveX(World.Booth.x, enterBoothDuration, motionCurve);

                yield return personGenerator.Illuminate();
            }
        }

        [Button()]
        public void ExitBoothFromRight()
        {
            StartCoroutine(Move());
            
            
            IEnumerator Move()
            {
                yield return personGenerator.BlackOut();

                transform.MoveY(transform.position.y + deltaHeight, exitBoothDuration, heightCurve);
                yield return transform.MoveX(World.BoothExit.x, exitBoothDuration, motionCurve);

                personGenerator.Illuminate();
            }
        }
        
        [Button()]
        public void ExitBoothFromLeft()
        {
            StartCoroutine(Move());
            
            
            IEnumerator Move()
            {
                yield return personGenerator.BlackOut();

                transform.MoveY(transform.position.y + deltaHeight, exitBoothDuration, heightCurve);
                yield return transform.MoveX(World.BoothEntrance.x, exitBoothDuration, motionCurve);

                personGenerator.Illuminate();
            }
        }
    }
}
