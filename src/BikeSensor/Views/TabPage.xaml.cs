using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BikeSensor.Views
{
    public partial class TabPage : TabbedPage
    {

        public TabPage()
        {
            InitializeComponent();
            this.CurrentPage = this.Children[1];
            this.CurrentPageChanged += (object sender, EventArgs e) => {
                ActualityContent.IconImageSource = "ActualityIcone.png";
                MainContent.IconImageSource = "MenuIcone.png";
                PreferenceContent.IconImageSource = "PreferenceIcone.png";

                var i = this.Children.IndexOf(this.CurrentPage);
                if (i == 0)
                {
                    ActualityContent.IconImageSource = "ActualityIconeSelected.png";
                }
                else if (i == 1)
                {
                    MainContent.IconImageSource = "MenuIconeSelected.png";
                }
                else if (i == 2)
                {
                    // PreferenceContent.IconImageSource = "PreferenceIconeSelected.png";
                }
            };
        }

        void TabbedPage_PagesChanged(System.Object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            

           

        }
    }
}
