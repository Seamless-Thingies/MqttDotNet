// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Sample.iOS.Phone
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnConnect { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSend { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblConnected { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblReceivedMessage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField tbContent { get; set; }

		[Action ("btnConnect_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnConnect_TouchUpInside (UIButton sender);

		[Action ("btnSend_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnSend_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnConnect != null) {
				btnConnect.Dispose ();
				btnConnect = null;
			}
			if (btnSend != null) {
				btnSend.Dispose ();
				btnSend = null;
			}
			if (lblConnected != null) {
				lblConnected.Dispose ();
				lblConnected = null;
			}
			if (lblReceivedMessage != null) {
				lblReceivedMessage.Dispose ();
				lblReceivedMessage = null;
			}
			if (tbContent != null) {
				tbContent.Dispose ();
				tbContent = null;
			}
		}
	}
}
