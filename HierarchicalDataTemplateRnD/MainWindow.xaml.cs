using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HierarchicalDataTemplateRnD
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var items = GetExplorerItems();
            TreeView1.ItemsSource = items;
            TreeView2.ItemsSource = items;

            TreeView3.ItemTemplate = GenerateHierarchicalDataTemplate();
            TreeView3.ItemsSource = items;

            TreeView4.ItemsSource = items;

            TreeView5.ItemTemplate = GenerateHierarchicalDataTemplateWithImage();
            TreeView5.ItemsSource = items;

            TreeView6.ItemsSource = GetSinglePathExplorerItems();

            MyCustomControl1.ItemsSource = GetExplorerItems();
        }

        private HierarchicalDataTemplate GenerateHierarchicalDataTemplate()
        {
            HierarchicalDataTemplate dataTemplate = new HierarchicalDataTemplate(typeof(ExplorerItem));

            string hierarchicalItemsSource = "Items"; // Explorer Items property
            dataTemplate.ItemsSource = new Binding(hierarchicalItemsSource);

            string hierarchicalMemberPath = "Header"; // Explorer Header property
            FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            frameworkElementFactory.SetBinding(ContentPresenter.ContentProperty, new Binding(hierarchicalMemberPath));
            dataTemplate.VisualTree = frameworkElementFactory;

            return dataTemplate;
        }

        private HierarchicalDataTemplate GenerateHierarchicalDataTemplateWithImage()
        {
            HierarchicalDataTemplate dataTemplate = new HierarchicalDataTemplate(typeof(ExplorerItem));

            string hierarchicalItemsSource = "Items"; // Explorer Items property
            string hierarchicalMemberPath = "Header"; // Explorer Header property
            string hierarchicalImagePath = "ImagePath"; // Explorer ImagePath property

            dataTemplate.ItemsSource = new Binding(hierarchicalItemsSource);

            FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Grid));

            var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column1.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);

            var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            column2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));

            frameworkElementFactory.AppendChild(column1);
            frameworkElementFactory.AppendChild(column2);

            var image = new FrameworkElementFactory(typeof(Image));
            image.SetValue(Image.SourceProperty, new Binding(hierarchicalImagePath));
            image.SetValue(Image.MaxHeightProperty, 16.0);
            image.SetValue(Image.MaxWidthProperty, 16.0);
            image.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            image.SetValue(Image.MarginProperty, new Thickness(3, 0, 3, 0));

            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetValue(TextBlock.TextProperty, new Binding(hierarchicalMemberPath));
            textBlock.SetValue(Grid.ColumnProperty, 1);

            frameworkElementFactory.AppendChild(image);
            frameworkElementFactory.AppendChild(textBlock);

            dataTemplate.VisualTree = frameworkElementFactory;

            return dataTemplate;
        }

        private List<ExplorerItem> GetExplorerItems()
        {
            return new List<ExplorerItem>
            {
                new ExplorerItem
                {
                    Header = "C:",
                    ImagePath = "Images/today.png",
                    Items = new List<ExplorerItem>
                {
                   new ExplorerItem
                   {
                       Header = "Program Files",
                       ImagePath = "Images/tomorrow.png",
                       Items = new List<ExplorerItem>
                       {
                             new ExplorerItem
                             {
                                 Header = "AMD",
                                 ImagePath = "Images/today.png",
                             },
                             new ExplorerItem
                             {
                                 Header = "dotnet",
                             }
                       }
                   },
                    new ExplorerItem
                   {
                       Header = "Program Files(x86)",
                       ImagePath = "Images/today.png",
                       Items = new List<ExplorerItem>
                       {

                       }
                   }
                }
                },
                new ExplorerItem
                {
                    Header = "D:",
                    ImagePath = "Images/week.png",
                }
            };
        }

        private List<ExplorerItem> GetSinglePathExplorerItems()
        {
            return new List<ExplorerItem>
            {
                new ExplorerItem
                {
                    Header = "C:",
                    ImagePath = "Images/today.png",
                    Items = new List<ExplorerItem>
                    {
                       new ExplorerItem
                       {
                           Header = "Program Files",
                           ImagePath = "Images/tomorrow.png",
                           Items = new List<ExplorerItem>
                           {
                                 new ExplorerItem
                                 {
                                     Header = "dotnet",
                                 }
                           }
                       }
                    }
                }
            };
        }
    }
}
