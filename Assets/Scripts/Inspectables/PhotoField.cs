using System;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Inspectables
{
    public class PhotoField : InspectableField<PhotoData>
    {
        [SerializeField] private RawImage field;
        [SerializeField] private Texture realPhoto;
        [SerializeField] private Texture fakePhoto;

        
        public void Set(PhotoData data, bool isFake = false)
        {
            base.Set(data);
            field.texture = isFake ? fakePhoto : realPhoto;
        }
    }
    
    [Serializable]
    public struct PhotoData : IComparableField
    {
        public string photoSerial;
        
        private bool mismatchSolved;

        
        public PhotoData(string photoSerial)
        {
            this.photoSerial = photoSerial;
            mismatchSolved = false;
        }

        public ComparisonResult Compare(object other)
        {
            if (other is not PhotoData photoData)
            {
                return ComparisonResult.Irrelevant;
            }

            if (Matches(photoData)) return ComparisonResult.Matched;

            return mismatchSolved ? ComparisonResult.MismatchSolved : ComparisonResult.Mismatched;
        }

        public bool Matches(PhotoData other)
        {
            return photoSerial == other.photoSerial;
        }

        public void SolveMismatch()
        {
            mismatchSolved = true;
        }

        public override string ToString()
        {
            return photoSerial;
        }
    }
}