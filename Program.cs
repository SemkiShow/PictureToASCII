using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;

namespace PictureToASCII
{
	class Program
	{
		public static void Main ()
		{
			// Initialization
			string brightness = " `.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";
			Console.WriteLine("Enter image number: ");
			int imageNumber = Convert.ToInt16(Console.ReadLine());
			var path = "./Images/image" + imageNumber + ".png";
			var image = Image.Load<Rgba32>(path);	

			int xCrop = Convert.ToInt16(Math.Ceiling(image.Width / Console.WindowWidth * 1d + 0.5));
			int yCrop = Convert.ToInt16(Math.Ceiling(image.Height / Console.WindowHeight * 1d + 0.5));
			int crop = new int[] {xCrop, yCrop}.Max();
			if (crop == 0) crop = 1;
			
			for (int y = 0; y < image.Height; y += crop)
			{
				for (int x = 0; x < image.Width; x += crop)
				{
					double middleColor = 0;
					for (int j = 0; j < crop; j++)
					{
						for (int i = 0; i < crop; i++)
						{
							if (x + j + 1 <= image.Width && y + i + 1 <= image.Height)
							{
								middleColor = middleColor + ((image[x + j, y + i].R + image[x + j, y + i].G + image[x + j, y + i].B) / 3);
						
							}
						}
					}
					middleColor = middleColor / (crop * crop);
					
					Console.Write(new string(brightness[Convert.ToInt16(middleColor / 255 * (brightness.Length - 1))], 2));
				}
				Console.WriteLine();
			}
		}
	}
}

