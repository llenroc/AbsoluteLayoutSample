using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AbsoluteLayoutSample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void HandlePosition(object sender, EventArgs e)
		{
			UpdatePosition();
		}

		public void HandleSize(object sender, EventArgs e)
		{
			UpdateSize();
		}

		async void UpdateSize()
		{
			ToggleEnabled(false);

			float w = 0.0f;
			float h = 0.0f;

			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
			AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			while(w <= 1.0)
			{
				w += .01f;
				h += .01f;
				AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0f, 0f, w, h));
				AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(.5, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				UpdateLabel();
				label.Text = string.Empty;

				await Task.Delay(50);
			}

			ToggleEnabled(true);
		}

		async void UpdatePosition()
		{
			ToggleEnabled(false);

			float x = 0.0f;
			AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, 0f, .25, .25));
			AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			while(x <= 1.0)
			{
				if(Math.Round(x, 2) == 0f)
				{
					label.Text = "Anchor point is far left";
					await Task.Delay(3000);
				}

				if(Math.Round(x, 2) == 0.5f)
				{
					label.Text = "Anchor point is in the middle";
					await Task.Delay(3000);
				}

				if(Math.Round(x, 2) == 1f)
				{
					label.Text = "Anchor point is far right";
					await Task.Delay(3000);
				}

				x += .01f;
				AbsoluteLayout.SetLayoutBounds(box, new Rectangle(x, 0f, .25, .25));
				AbsoluteLayout.SetLayoutBounds(anchorVert, new Rectangle(x, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

				UpdateLabel();
				label.Text = string.Empty;

				await Task.Delay(50);
			}

			ToggleEnabled(true);
		}

		void UpdateLabel()
		{
			var rect = AbsoluteLayout.GetLayoutBounds(box);
			coords.Text = string.Format("X:{0} x Y:{1}, W:{2} x H:{3}", rect.X.ToString("0.00"), rect.Y.ToString("0:00"), Math.Round(rect.Width, 2), Math.Round(rect.Height, 2));
		}

		void ToggleEnabled(bool enabled)
		{
			btnPos.IsEnabled = enabled;
			btnSize.IsEnabled = enabled;
		}
	}
}

