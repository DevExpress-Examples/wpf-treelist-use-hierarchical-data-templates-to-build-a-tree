<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128657742/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3410)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Tree List - Use the Hierarchical Data Template to Build a Tree

This example demonstrates how to use the [HierarchicalDataTemplate](https://learn.microsoft.com/en-us/dotnet/api/system.windows.hierarchicaldatatemplate) to apply a custom appearance to hierarchical data.

![image](https://user-images.githubusercontent.com/65009440/193810135-6eea56c8-2bf4-4caa-a3a0-c51bcea2260e.png)

1. If all objects have the same field that contains child nodes, create a hierarchical data template and assign it to the [TreeListView.DataRowTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView.DataRowTemplate) property. You can also put hierarchical data templates into resources.
2. Specify the data type to which the template should be applied:

   ```xml
   <Window.Resources>
       <HierarchicalDataTemplate DataType="{x:Type local:ProjectObject}" ItemsSource="{Binding Stages}"/>
       <HierarchicalDataTemplate DataType="{x:Type local:ProjectStage}" ItemsSource="{Binding Tasks}"/>
   </Window.Resources>
   ```
3. Set the [TreeListView.TreeDerivationMode](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TreeListView.TreeDerivationMode) property to `HierarchicalDataTemplate`.

## Files to Review

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [ViewModel.cs](./CS/ViewModel.cs) (VB: [ViewModel.vb](./VB/ViewModel.vb))

## Documentation

* [Hierarchical Data Templates](https://docs.devexpress.com/WPF/10366/controls-and-libraries/data-grid/display-hierarchical-data/bind-to-hierarchical-data-structure#hierarchical-data-templates)
* [System.Windows.HierarchicalDataTemplate](https://learn.microsoft.com/en-us/dotnet/api/system.windows.hierarchicaldatatemplate)

## More Examples

* [WPF Tree List - Use the Child Nodes Selector to Display Hierarchical Data](https://github.com/DevExpress-Examples/wpf-treelist-use-child-nodes-selector-to-display-hierarchical-data)
* [WPF Tree List - Implement the Child Nodes Path](https://github.com/DevExpress-Examples/wpf-treelist-implement-childnodespath)
* [WPF Tree List - Bind to Self-Referential Data Structure](https://github.com/DevExpress-Examples/wpf-treelist-bind-to-self-referential-data)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-treelist-use-hierarchical-data-templates-to-build-a-tree&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-treelist-use-hierarchical-data-templates-to-build-a-tree&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
