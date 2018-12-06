﻿namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries
{
	internal class ObservableCollectionGallery : ContentPage
	{
		public ObservableCollectionGallery()
		{
			var desc = "Observable Collection Galleries";

			var descriptionLabel = new Label { Text = desc, Margin = new Thickness(2, 2, 2, 2) };

			Title = "Simple DataTemplate Galleries";

			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Children =
					{
						descriptionLabel,

						GalleryBuilder.NavButton("Filter Items", () => new FilterCollectionView(), Navigation),

						GalleryBuilder.NavButton("Add/Remove Items (list)", () =>
							new ObservableCodeCollectionViewGallery(grid: false), Navigation),

						GalleryBuilder.NavButton("Add/Remove Items (grid)", () =>
							new ObservableCodeCollectionViewGallery(), Navigation),

						GalleryBuilder.NavButton("Add Items start Empty Collection (grid)", () =>
							new ObservableCodeCollectionViewGallery(empty: true), Navigation),

						GalleryBuilder.NavButton("Add Items start Empty Collection (list)", () =>
							new ObservableCodeCollectionViewGallery(grid: false, empty: true), Navigation),

						GalleryBuilder.NavButton("Add Items with timer to Empty Collection", () =>
							new ObservableCodeCollectionViewGallery(grid: false, empty: true, addItemsWithTimer: true), Navigation)
					}
				}
			};
		}
	}
}