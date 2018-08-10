using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Windows;

namespace TokenAssigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var claims = new[] {
                new Claim("hwId", tbHwId.Text),
                new Claim("deviceType", tbType.Text)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tbKey.Text));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(tbIssuer.Text,
              tbAudience.Text,
              claims,
              expires: dpExpDate.SelectedDate,
              signingCredentials: creds);

            

            tbResult.Text = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
