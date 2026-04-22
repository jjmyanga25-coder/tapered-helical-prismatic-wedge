using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace TaperedHelicalWedgeApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Width { get; set; }

        [BindProperty]
        public double Depth { get; set; }

        [BindProperty]
        public double Height { get; set; }

        [BindProperty]
        public double Taper { get; set; }

        [BindProperty]
        public double Twist { get; set; }

        public double Volume { get; set; }

        public void OnPost()
        {
            int n = 1000;
            double dz = Height / n;
            double volume = 0;

            for (int i = 0; i < n; i++)
            {
                double z = i * dz;

                // Width decreases (taper)
                double widthZ = Width * (1 - Taper * (z / Height));

                // Helical twist affects orientation (adds complexity factor)
                double twistFactor = 1 + 0.2 * Math.Sin(Twist * z);

                double area = widthZ * Depth * twistFactor;

                volume += area * dz;
            }

            Volume = volume;
        }
    }
}