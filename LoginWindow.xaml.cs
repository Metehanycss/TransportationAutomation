using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;
using TaşımacılıkOtomasyonu;

namespace TaşımacılıkOtomasyonu
{
    public partial class LoginWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public LoginWindow(AppDbContext context, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _context = context;
            _serviceProvider = serviceProvider;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameVal.Text;
            string password = passwordVal.Password;

            var user = _context.Users.SingleOrDefault(u => u.Email == username && u.Password == password);

            if (user != null)
            {
                var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
            }
        }
    }
}
