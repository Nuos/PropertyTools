// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditableTextBlockAndPropertyGridPage.xaml.cs" company="PropertyTools">
//   Copyright (c) 2014 PropertyTools contributors
// </copyright>
// <summary>
//   Interaction logic for EditableTextBlockAndPropertyGridPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ControlDemos
{
    using System.Windows.Input;

    using PropertyTools;
    using PropertyTools.Wpf;

    /// <summary>
    /// Interaction logic for EditableTextBlockAndPropertyGridPage.xaml
    /// </summary>
    public partial class EditableTextBlockAndPropertyGridPage
    {
        private ViewModel vm;

        public EditableTextBlockAndPropertyGridPage()
        {
            this.InitializeComponent();
            this.vm = new ViewModel(this);
            this.DataContext = this.vm;
        }

        public class ViewModel : Observable
        {

            private readonly EditableTextBlockAndPropertyGridPage page;

            private string name;

            public ViewModel(EditableTextBlockAndPropertyGridPage page)
            {
                this.page = page;
                this.Name = "Model1";
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.page.DataContext = null;
                    this.SetValue(ref this.name, value, nameof(this.Name));
                    this.page.DataContext = this.page.vm;
                }
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var etb = (EditableTextBlock)sender;
            etb.IsEditing = !etb.IsEditing;
        }
    }
}