﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.Windows.Shell;

namespace Glass.Basics.Styles
{

    public class MaximizeButton : CheckBox
    {
        static MaximizeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));
        }

        protected override void OnClick()
        {
            //base.OnClick();
            var window = Window.GetWindow(this);
            
            //window.WindowState = WindowState.Minimized;
            if (IsChecked.HasValue) {

                if (IsChecked.Value)
                    SystemCommands.RestoreWindow(window);
                else
                    SystemCommands.MaximizeWindow(window);

            }
        } 
    }
}
