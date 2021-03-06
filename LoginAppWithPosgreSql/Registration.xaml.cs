using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Npgsql;

namespace LoginAppWithPosgreSql
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            loginInpt.TextChanged += LoginInpt_TextChanged;
        }

        private void LoginInpt_TextChanged(object sender, TextChangedEventArgs e)
        {
            int textboxLength = loginInpt.Text.Length;
            if (textboxLength != 0 || textboxLength > 3 )
            {
                string error = "";
                errorsLabel.Content = error;
            }

            else if (textboxLength < 3)
            {
                string error = "Точно не правилный логин";
                errorsLabel.Content = error;
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            int userId =Convert.ToInt16(idInpt.Text);
            string userLogin = loginInpt.Text;
            string userPass = passInpt.Text;
            int userRole = 1;

            string connString = "Host=localhost;Port=7777;Database=postgres;Username=postgres;Password=13123866rT;Persist Security Info=True";
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            using (var insertCommand = new NpgsqlCommand("INSERT INTO public.users_list(user_id, user_login, user_pass, user_role_id) VALUES(@userId, @userLogin, @userPass, @userRole); ", connection))
            {
                insertCommand.Parameters.AddWithValue("userId", userId);
                insertCommand.Parameters.AddWithValue("userLogin", userLogin);
                insertCommand.Parameters.AddWithValue("userPass", userPass);
                insertCommand.Parameters.AddWithValue("userRole", userRole);
                insertCommand.ExecuteNonQuery();
              
            }


        }
    }
}
