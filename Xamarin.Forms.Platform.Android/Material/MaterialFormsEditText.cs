#if __ANDROID_28__
using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.Design.Widget;
using Android.Runtime;

namespace Xamarin.Forms.Platform.Android.Material
{
	public class MaterialFormsEditText : TextInputEditText, IDescendantFocusToggler
	{
		DescendantFocusToggler _descendantFocusToggler;
		int? bottomPadding;

		public MaterialFormsEditText(Context context) : base(context)
		{
			VisualElement.VerifyVisualFlagEnabled();
			DrawableCompat.Wrap(Background);
		}

		public override ViewGroup.LayoutParams LayoutParameters
		{
			get => base.LayoutParameters;
			set => base.LayoutParameters = value;
		}

		protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
		{
			//if (bottomPadding == null)
			//{
			//	bottomPadding = base.PaddingBottom;
			//}

			//int paddingToUse = bottomPadding.Value;

			//if (String.IsNullOrWhiteSpace(Text) && !HasFocus)
			//{
			//	paddingToUse = (bottom - top - paddingToUse) / 2;
			//}

			//if (String.IsNullOrWhiteSpace(Text) && !HasFocus)
			//{
			//	SetPadding(PaddingLeft, 0, PaddingRight, paddingToUse);
			//}
			//UpdatePadding();
			base.OnLayout(changed, left, top, right, bottom);
		}

		void UpdatePadding()
		{

			if (bottomPadding == null)
			{
				bottomPadding = base.PaddingBottom;
			}

			int paddingToUse = bottomPadding.Value;

			if (String.IsNullOrWhiteSpace(Text) && !HasFocus)
			{
				paddingToUse = (MeasuredHeight - paddingToUse) / 2;
			}

			if (String.IsNullOrWhiteSpace(Text) && !HasFocus)
			{
				SetPadding(PaddingLeft, 0, PaddingRight, paddingToUse);
			}
		}

		protected override void OnFocusChanged(bool gainFocus, [GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
		{
			base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
			//UpdatePadding();
		}

		bool IDescendantFocusToggler.RequestFocus(global::Android.Views.View control, Func<bool> baseRequestFocus)
		{
			_descendantFocusToggler = _descendantFocusToggler ?? new DescendantFocusToggler();

			return _descendantFocusToggler.RequestFocus(control, baseRequestFocus);
		}

		public override bool OnKeyPreIme(Keycode keyCode, KeyEvent e)
		{
			if (keyCode != Keycode.Back || e.Action != KeyEventActions.Down)
			{
				return base.OnKeyPreIme(keyCode, e);
			}

			this.HideKeyboard();

			OnKeyboardBackPressed?.Invoke(this, EventArgs.Empty);
			return true;
		}

		public override bool RequestFocus(FocusSearchDirection direction, Rect previouslyFocusedRect)
		{
			return (this as IDescendantFocusToggler).RequestFocus(this, () => base.RequestFocus(direction, previouslyFocusedRect));
		}

		protected override void OnSelectionChanged(int selStart, int selEnd)
		{
			base.OnSelectionChanged(selStart, selEnd);
			SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(selStart, selEnd));
		}

		internal event EventHandler OnKeyboardBackPressed;
		internal event EventHandler<SelectionChangedEventArgs> SelectionChanged;



		//public override int CompoundPaddingTop
		//{
		//	get
		//	{
		//		if (!topPadding.HasValue)
		//		{
		//			topPadding = base.CompoundPaddingTop;
		//		}

		//		if (!String.IsNullOrWhiteSpace(Text))
		//			return topPadding.Value;

		//		return topPadding.Value + 45;
		//	}
		//}

		//public override int CompoundPaddingBottom
		//{
		//	get
		//	{
		//		if (!bottomPadding.HasValue)
		//		{
		//			bottomPadding = base.CompoundPaddingBottom;
		//		}

		//		if (!String.IsNullOrWhiteSpace(Text))
		//			return bottomPadding.Value;


		//		return bottomPadding.Value + 45;
		//	}
		//}
	}
}
#endif