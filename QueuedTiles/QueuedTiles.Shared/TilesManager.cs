using NotificationsExtensions.TileContent;
using System;
using System.IO;
using Windows.UI.Notifications;

namespace QueuedTiles
{
    public static class TilesManager
    {
        private static string[] NAMES = { "4", "3", "2", "1", "0" };
        private const string TILE_SQUARE_310X310_IMAGE_FORMAT = "ms-appx:///Assets/Tiles/{0}_Square310x310Logo.scale-240.png";
        private const string TILE_WIDE_310x150_IMAGE_FORMAT = "ms-appx:///Assets/Tiles/{0}_WideLogo.scale-240.png";
        private const string TILE_SQUARE_150X150_IMAGE_FORMAT = "ms-appx:///Assets/Tiles/{0}_Logo.scale-240.png";
        private const string TILE_SQUARE_71X71_IMAGE_FORMAT = "ms-appx:///Assets/Tiles/{0}_Square71x71Logo.scale-240.png";
        private const string TILE_SQUARE_70X70_IMAGE_FORMAT = "ms-appx:///Assets/Tiles/{0}_Square70x70Logo.scale-240.png";

        public static void ShowQueuedTiles()
        {
            TileNotification[] tileNotifications = CreateTileQueue();

            if (tileNotifications == null || tileNotifications.Length == 0)
            {
                TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            }
            else
            {
                foreach (TileNotification tn in tileNotifications)
                    TileUpdateManager.CreateTileUpdaterForApplication().Update(tn);
            }
        }

        #region Private Part

        private static TileNotification[] CreateTileQueue()
        {
            try
            {
                int articlesCount = NAMES.Length;
                TileNotification[] tileNotifications = new TileNotification[articlesCount];
                for (int i = 0; i < articlesCount; i++)
                {
                    string nm = NAMES[i];
                    TileItem tileItem = CreateTileItem(nm);
                    tileNotifications[i] = CreateTileNotification(tileItem, "Optional text", nm);
                }

                return tileNotifications;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static TileItem CreateTileItem(string tileName)
        {
            TileItem tileItem = new TileItem();

            tileItem.TileSquare310X310Image = string.Format(TILE_SQUARE_310X310_IMAGE_FORMAT, tileName);

            tileItem.TileWide310X150Image = string.Format(TILE_WIDE_310x150_IMAGE_FORMAT, tileName);

            tileItem.TileSquare150X150Image = string.Format(TILE_SQUARE_150X150_IMAGE_FORMAT, tileName);

            tileItem.TileSquare71X71Image = string.Format(TILE_SQUARE_71X71_IMAGE_FORMAT, tileName);

            //tileItem.TileSquare70X70Image = string.Format(TILE_SQUARE_70X70_IMAGE_FORMAT, tileName);

            return tileItem;
        }

        private static TileNotification CreateTileNotification(TileItem tileItem, string defaultTitle, string tag)
        {
            // Create a notification for the Square310x310 tile using one of the available templates for the size.
            ITileSquare310x310Image tileContent = TileContentFactory.CreateTileSquare310x310Image();
            tileContent.Image.Src = tileItem.TileSquare310X310Image;
            tileContent.Image.Alt = defaultTitle;

            // Create a notification for the Wide310x150 tile using one of the available templates for the size.
            ITileWide310x150Image wide310x150Content = TileContentFactory.CreateTileWide310x150Image();
            wide310x150Content.Image.Src = tileItem.TileWide310X150Image;
            wide310x150Content.Image.Alt = defaultTitle;

            // Create a notification for the Square150x150 tile using one of the available templates for the size.
            ITileSquare150x150Image square150x150Content = TileContentFactory.CreateTileSquare150x150Image();
            square150x150Content.Image.Src = tileItem.TileSquare150X150Image;
            square150x150Content.Image.Alt = defaultTitle;

            // Create a notification for the Square71x71 tile using one of the available templates for the size.
            ITileSquare71x71Image square71x71Content = TileContentFactory.CreateTileSquare71x71Image();
            square71x71Content.Image.Src = tileItem.TileSquare71X71Image;
            square71x71Content.Image.Alt = defaultTitle;

            // Attach the Square71x71 template to the Square150x150 template.
            square150x150Content.Square71x71Content = square71x71Content;

            // Attach the Square150x150 template to the Wide310x150 template.
            wide310x150Content.Square150x150Content = square150x150Content;

            // Attach the Wide310x150 to the Square310x310 template.
            tileContent.Wide310x150Content = wide310x150Content;

            TileNotification tileNotification = tileContent.CreateNotification();
            tileNotification.Tag = tag;

            return tileNotification;
        }

        #endregion
    }
}
