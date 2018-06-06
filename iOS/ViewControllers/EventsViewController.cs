using Foundation;
using Models.Models;
using System;
using System.Collections.Generic;
using UIKit;
using BusinessLayer.Interfaces;
using BusinessLayer.BusinessLogic;

namespace UFCApp.iOS
{
    public partial class EventsViewController : UITableViewController
    {
		private List<Events> events;
		private IEventsBusinessLogic eventsBusinessLogic;

        public EventsViewController (IntPtr handle) : base (handle)
        {
			eventsBusinessLogic = new EventsBusinessLogic();
			events = new List<Events>();
        }

		public override async  void ViewDidLoad()
		{
			base.ViewDidLoad();
			events = await eventsBusinessLogic.GetEvents();
			TableView.ReloadData();
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return events.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("eventCell");

			var currentEvent = events[indexPath.Row];
			cell.TextLabel.Text = currentEvent.Title;
			cell.DetailTextLabel.Text = currentEvent.Arena;

			return cell;
		}
	}
}