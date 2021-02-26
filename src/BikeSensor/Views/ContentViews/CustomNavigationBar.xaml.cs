using System;
using System.Collections.Generic;
using BikeSensor.Views.Pages;
using Xamarin.Forms;

namespace BikeSensor.Views.ContentViews
{
    public partial class CustomNavigationBar : ContentView
    {
        public string TitleText
        {
            // ----- The display text for the composite control.
            get
            {
                return (string)base.GetValue(TitleTextProperty);
            }
            set
            {
                if (this.TitleText != value)
                    base.SetValue(TitleTextProperty, value);
            }
        }

        private static BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(ContentView),
                                                         defaultValue: string.Empty,
                                                         defaultBindingMode: BindingMode.OneWay,
                                                         propertyChanged: TitleTextPropertyChanged);


        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomNavigationBar targetView;

            targetView = (CustomNavigationBar)bindable;
            if (targetView != null)
                targetView.TitleEl.Text = (string)newValue;
        }

        public CustomNavigationBar()
        {
            InitializeComponent();
            OnLoad();

           
        }
        public void OnLoad()
        {
            if(Application.Current.MainPage == null)
            {
                ImageButton.Source = "Settings.png";
                return;
            }
            else
            {
                if (Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
                {
                    ImageButton.Source = "close.png";
                }
                else
                {
                    ImageButton.Source = "Settings.png";
                }
            }
          
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopAsync();
            }
            else
            {
                Navigation.PushAsync(new PreferencePage());

            }
        }
    }
}
