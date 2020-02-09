using System;
using System.Collections.Generic;
using System.Text;

namespace VeldridFormsSamples.Models
{
    public enum MenuItemType
    {
        Browse,
        Instancing,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
