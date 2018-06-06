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
    [Register ("NewsTableViewCell")]
    partial class NewsTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel authorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
		public UIKit.UIImageView newImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
		public UIKit.UILabel titleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (authorLabel != null) {
                authorLabel.Dispose ();
                authorLabel = null;
            }

            if (newImage != null) {
                newImage.Dispose ();
                newImage = null;
            }

            if (titleLabel != null) {
                titleLabel.Dispose ();
                titleLabel = null;
            }
        }
    }
}