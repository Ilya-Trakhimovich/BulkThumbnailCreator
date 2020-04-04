using System;
using System.Collections.Generic;
using System.Text;

namespace BulkThumbnailCreator
{
    public class ImageSize
    {
        public float Height { get; set; }
        public float Weight { get; set; }

        public ImageSize(float weight, float height)
        {
            Weight = weight;
            Height = height;
        }
    }
}
