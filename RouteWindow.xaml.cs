using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaşımacılıkOtomasyonu.Models;
using Microsoft.Extensions.DependencyInjection;
using TaşımacılıkOtomasyonu.Models;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class RouteWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public RouteWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
            LoadData();
        }

        private void LoadData()
        {
            var routes = _context.Routes.ToList();
            dataGrid.ItemsSource = routes;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var route = new Route
            {
                StartLocation = startLocationTextBox.Text,
                EndLocation = endLocationTextBox.Text,
                Distance = double.Parse(distanceTextBox.Text),
                EstimatedTime = TimeSpan.Parse(estimatedTimeTextBox.Text)
            };
            _context.Routes.Add(route);
            _context.SaveChanges();
            LoadData();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Route selectedRoute)
            {
                selectedRoute.StartLocation = startLocationTextBox.Text;
                selectedRoute.EndLocation = endLocationTextBox.Text;
                selectedRoute.Distance = double.Parse(distanceTextBox.Text);
                selectedRoute.EstimatedTime = TimeSpan.Parse(estimatedTimeTextBox.Text);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Route selectedRoute)
            {
                _context.Routes.Remove(selectedRoute);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            startLocationTextBox.Clear();
            endLocationTextBox.Clear();
            distanceTextBox.Clear();
            estimatedTimeTextBox.Clear();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Route selectedRoute)
            {
                startLocationTextBox.Text = selectedRoute.StartLocation;
                endLocationTextBox.Text = selectedRoute.EndLocation;
                distanceTextBox.Text = selectedRoute.Distance.ToString();
                estimatedTimeTextBox.Text = selectedRoute.EstimatedTime.ToString(@"hh\:mm");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            this.Close();
        }
    }
}
