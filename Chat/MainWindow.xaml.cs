using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chat.Net.IO;
using Microsoft.Win32;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string userPhoto;
        public MainWindow()
        {
            InitializeComponent();
            this.Width = 302;
            this.Height = 400;
            LabelUsername.Visibility = Visibility.Hidden;
            ContactColumn.Width = new GridLength(1);
            ChatColumn.Width = new GridLength(1);
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonImg_Click(object sender, RoutedEventArgs e)
        {

        }
       

        private void ButtonMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximazed_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
                this.ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnChoosePhotoUser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // открываем окно для выбора изображения
            openFileDialog.ShowDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                ImgUser.Source = new BitmapImage(new Uri(openFileDialog.FileName)); // выводим изображение на экран

                userPhoto = openFileDialog.FileName; // сохранияем пусть к изображению пользователя
            }
        }

        private void TxbUserName_GotFocus(object sender, RoutedEventArgs e)
        {
        }
        private void CenterWindowOnScreen()
        {
            // Чтобы после изменений размера окна окно в итоге было по центру экрана
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void TxbUserName_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            /* то, как должно работать(Логин), но по каким то причинам оно не работает, костыль кодом ниже
            Model.UserModel userDataClass = new Model.UserModel();
            userDataClass.Username = TxbUserName.Text; // сохраняем имя пользвателя 
            userDataClass.UserImage = userPhoto;
            Model.UserModel.users.Add(new ClassHelper.UserDataClass() { UserName = TxbUserName.Text, UserImage = userPhoto });
            MainWindow mainWindow = new MainWindow(); // переход на главное окно 
            mainWindow.Show();
            this.Close();
            */

            /* Тут кусок кода, чтобы после логина, форма для логина пропала, и появился сам чат
            Логин через другое окно не работает, по этому все делается в одном окне*/
            LabelUsername.Visibility = Visibility.Visible;
            Brush brush = new SolidColorBrush(Colors.Green);
            OnlineStatus.Background = brush;
            StatusLabel.Content = "Online";
            this.Width = 1200;
            this.Height = 650;
            ContactColumn.Width = new GridLength(200);
            ChatColumn.Width = new GridLength(999);
            LoginColumn.Width = new GridLength(1);
            this.MinWidth = 1200;
            this.MinHeight = 650;
            TextBoxChatting.Width = 900;
            TextBoxChatting.VerticalContentAlignment = VerticalAlignment.Center;
            CenterWindowOnScreen();
        }

        private void TextBoxChatting_KeyDown(object sender, KeyEventArgs e)
        {
            // Метод для того, чтобы на enter сообщение отправлялось в чат
            if (e.Key == Key.Return)
            {
                /* В Server есть метод SendmessageToServer, тут ссылаться на него, и передать ему текст из
                TextBoxChatting(поле ввода сообщения), затем не забыть очистить само поле ввода после отсылки сообщения в чат */
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Тут очистка поля для ввода сообщения, его нужно очистить, но не сразу, иначе сообщение просто не успеет отправится на сервер
            Самое простое решение открыть Thread и кинуть его в Sleep на 15-20 мс, чтобы сообщение отправилось и после этого очистилось поле
            TextBoxChatting.Clear();*/
        }
    }
}
