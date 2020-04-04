using System.Threading;
using System.Configuration;
using System.Drawing;

namespace BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathtoDirectory = ConfigurationManager.AppSettings["Path"];
            var pathToNewFolder = ConfigurationManager.AppSettings["NewPath"];

            ImageManipulation manipulator = new ImageManipulation(pathtoDirectory);
            string[] images = manipulator.GetImages("*.jpg");
            manipulator.SetBitmapObjects(images);
            Bitmap[] bitmaps = manipulator.GetBitmapArray();

            for (var i = 0; i < bitmaps.Length; i++)
            {
                Thread thread = new Thread(manipulator.RenameResizeResaveImage);
                thread.Start(bitmaps[i]);
            }

            //Thread threadChangeImageSize = new Thread(manipulator.ChangeImageSize);
            //Thread threadSaveImages = new Thread(manipulator.SaveChangedImage);
            //threadSaveImages.Priority = ThreadPriority.Lowest;       
            //manipulator.SetBitmapObjects(images);
            //threadChangeImageSize.Start(new ImageSize(800,600));
            //threadSaveImages.Start(pathToNewFolder);
        }
    }
}
