// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UFCApp.iOS
{
    [Register ("EventsTableViewCell")]
    partial class EventsTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel baseTitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
		public UIKit.UILabel dateEventLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
		public UIKit.UIImageView imageEvent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
		public UIKit.UILabel titleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (baseTitleLabel != null) {
                baseTitleLabel.Dispose ();
                baseTitleLabel = null;
            }

            if (dateEventLabel != null) {
                dateEventLabel.Dispose ();
                dateEventLabel = null;
            }

            if (imageEvent != null) {
                imageEvent.Dispose ();
                imageEvent = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }
        }
    }
}