using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HierarchicalDataTemplateMode {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }

    public class ProjectObjectToProgressConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var po = value as ProjectObject;
            if (po != null)
                return po.Progress;
            return Binding.DoNothing;
         //   return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }

       
    }
    public class ProjectStageToProgressConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var ps = value as ProjectObject;
            if (ps != null)
                return ps.Progress;
            return Binding.DoNothing;
            //   return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }

    public class TaskToStartDateConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var obj = value as Task;
            if (obj != null)
                return obj.StartDate;
            return Binding.DoNothing;
            //   return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
    public class TaskToEndDateConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var obj = value as Task;
            if (obj != null)
                return obj.EndDate;
            return Binding.DoNothing;
            //   return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
    public class TaskToStateConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var obj = value as Task;
            if (obj != null)
                return obj.State;
            return Binding.DoNothing;
            //   return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}