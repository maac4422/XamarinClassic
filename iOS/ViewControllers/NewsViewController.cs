using Foundation;
using Models.Models;
using System;
using System.Collections.Generic;
using UIKit;
using BusinessLayer.Interfaces;
using BusinessLayer.BusinessLogic;

namespace UFCApp.iOS
{
    public partial class NewsViewController : UITableViewController
    {
		private List<News> news;
		private INewsBusinessLogic newsBusinessLogic;

        public NewsViewController (IntPtr handle) : base (handle)
        {
			newsBusinessLogic = new NewsBusinessLogic();
			news = new List<News>();
        }

		public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
			news = await newsBusinessLogic.GetNews();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return news.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = tableView.DequeueReusableCell("newCell") as NewsTableViewCell;

            var currentNew  = news[indexPath.Row];
			cell.titleLabel.Text = currentNew.Title;
			cell.authorLabel.Text = currentNew.Author;
			if(!String.IsNullOrEmpty(currentNew.Image)){
			    cell.newImage.Image = UIImageFromUrl(currentNew.Image);
			}
            return cell;
        }

        public static UIImage UIImageFromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        [Export("tableView:heightForRowAtIndexPath:")]
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 81;
        }
    }
}