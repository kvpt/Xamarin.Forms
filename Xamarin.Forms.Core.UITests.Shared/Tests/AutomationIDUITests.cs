using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Xamarin.Forms.Core.UITests
{
	[TestFixture]
	[Category(UITestCategories.AutomationId)]
	[Category(UITestCategories.UwpIgnore)]
	internal class AutomationIDUITests : BaseTestFixture
	{
		protected override void NavigateToGallery()
		{
			App.NavigateToGallery(GalleryQueries.AutomationIDGallery);
		}

		[Test]
		public void Test1()
		{
			App.WaitForElement(c => c.Marked("btnTest1"));
			App.Tap(c => c.Marked("btnTest1"));
			App.WaitForElement(c => c.Marked("stckMain"));
			App.WaitForElement(c => c.Marked("actHello"));
			App.WaitForElement(c => c.Marked("bxvHello"));
			App.Tap(c => c.Marked("btnHello"));
			App.WaitForElement(c => c.Marked("dtPicker"));
			App.WaitForElement(c => c.Marked("tPicker"));

			var label = App.Query("lblHello")[0];
			Assert.AreEqual("Hello Label", label.Text);

			var editor = App.Query("editorHello")[0];
			Assert.AreEqual("Hello Editor", editor.Text);

			var entry = App.Query("entryHello")[0];
			Assert.AreEqual("Hello Entry", entry.Text);

			App.Tap(c => c.Marked("popModal"));
		}


		[Test]
		public async Task Test2()
		{
			await Task.Delay(1000);
			App.WaitForElement(c => c.Marked("btnTest2"));
			App.Tap(c => c.Marked("btnTest2"));
			App.WaitForElement(c => c.Marked("imgHello"));
			App.WaitForElement(c => c.Marked("lstView"));
			App.WaitForElement(c => c.Marked("pickerHello"));
			App.WaitForElement(c => c.Marked("progressHello"));
			App.ScrollDownTo(c => c.Marked("progressHello"));
			App.WaitForElement(c => c.Marked("srbHello"));
			App.WaitForElement(c => c.Marked("sliHello"));
			App.WaitForElement(c => c.Marked("stepperHello"));
			App.WaitForElement(c => c.Marked("switchHello"));
			//App.WaitForElement (c => c.Marked ("webviewHello"));
			App.Tap(c => c.Marked("popModal"));
		}
#if __IOS__
		[Test]
		public void TestToolbarItem()
		{
			App.Tap(c => c.Marked("tbItemHello"));
			App.WaitForElement(x => x.Marked("Hello"));
			App.Tap(c => c.Marked("ok"));
			App.Tap(c => c.Marked("tbItemHello2"));
			App.WaitForElement(x => x.Marked("Hello2"));
			App.Tap(c => c.Marked("ok"));
		}
#endif
	}
}

