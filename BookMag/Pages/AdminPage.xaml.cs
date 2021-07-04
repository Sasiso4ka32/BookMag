using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


namespace BookMag.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
        
    {
        List<Книги> BookList = Class.DataBase.DB.Книги.ToList();

        public AdminPage()
        {
            InitializeComponent();
            DG.ItemsSource = BookList;
        }
        int i = -1;
        int ind;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Книги S = BookList[i];
                Uri U = new Uri(S.Обложка, UriKind.RelativeOrAbsolute);
                ME.Source = U;

            }
        }
        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = BookList[i];
                TB.Text = "Название: " + S.Название;

            }

        }

        private void Price_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            TB.Text = "Цена: " + Convert.ToInt32(S.Цена) + "руб.";
        }

        
        private void TextBlock_Avtor_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            TB.Text = "Автор: " + S.Авторы.Автор;
        }

        private void TextBlock_NalichieONShop_Initialized(object sender, EventArgs e)
        {

            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            if (S.Количество_магазин > 5)
            {
                TB.Text = "Наличие на складе: много";
            }
            else
            {
                TB.Text = "Количество в магазине: " + Convert.ToString(S.Количество_магазин);
            }
            
        }

        private void TextBlock_NalichieOnSklad_Initialized(object sender, EventArgs e)
        {
            
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            if (S.Количество_магазин > 5)
            {
                TB.Text = "Наличие на складе: много";
            }
            else
            {
                TB.Text = "Количество на складе: " + Convert.ToString(S.Количество_склад);
            }
        }
            
        

        int C = 0;
        int P = 0;
        int Skid = 0;
        
        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            ind = Convert.ToInt32(B.Uid);
            Книги S = BookList[ind];
            int p = S.Цена;
            C = C + 1;
            P = P + p;
            Count.Text = "Количество выбранных книг: " + C;
            PriceFinal.Text = "Количество выбранных книг: " + P + "руб";
        }

        private void Count_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            TB.Text = "Количество выбранных книг: " + C;
        }

        private void PriceFinal_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            TB.Text = "Цена покупки: " + P + " руб";
        }

        private void Skidos_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            if (C > 3 && C<5 )
            {
                Skid = 5;
                TB.Text = "Скидка: " + Skid + " %";
            }
            else if (C>5 && C<10)
            {
                Skid = 10;
                TB.Text = "Скидка: " + Skid + " %";
            }
            else if (C > 10)
            {
                Skid = 15;
                TB.Text = "Скидка: " + Skid + " %";
            }
        }

        private void BAdd_Initialized(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            if(B != null)
            {
                B.Uid = Convert.ToString(i);
            }
        }
    }
}
