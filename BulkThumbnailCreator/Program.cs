using System.Threading;
using System.Configuration;


namespace BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathtoDirectory = ConfigurationManager.AppSettings["Path"];
            var pathToNewFolder = ConfigurationManager.AppSettings["NewPAth"];
            ImageManipulation manipulator = new ImageManipulation(pathtoDirectory);
            Thread threadChangeImageSize = new Thread(manipulator.ChangeImageSize);
            Thread threadSaveImages = new Thread(manipulator.SaveChangedImages);
            threadSaveImages.Priority = ThreadPriority.Lowest;
            string[] images = manipulator.GetImages("*.jpg");

            manipulator.SetBitmapObjects(images);
            threadChangeImageSize.Start(new ImageSize(800,600));
            threadSaveImages.Start(pathToNewFolder);
        }
    }
}
