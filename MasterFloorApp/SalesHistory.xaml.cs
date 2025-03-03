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

namespace MasterFloorApp
{
    /// <summary>
    /// Логика взаимодействия для SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : Window
    {
        
        public SalesHistory(int SelectedPartner)
        {
            InitializeComponent();
            
            LoadHistory(SelectedPartner);
        }

        /// <summary>
        /// Метод для вывода истории реализации по конкретному партнеру
        /// </summary>
        /// <param name="SelectedPartner"></param>
        private void LoadHistory(int SelectedPartner)
        {
            try
            {
                using (var dbContext = new MasterFloorEntity())
                {
                    var history = (
                                   // Выполняем запрос для получения информации из таблицы ПартнерПродукт
                                   from partnerProduct in dbContext.PartnerProduct
                                       // Соединяем с таблицей Продукт по id продукта
                                   join product in dbContext.Product
                                        on partnerProduct.idProduct equals product.id
                                   // Соединяем с таблицей Партнеров по id партнера
                                   join partner in dbContext.Partners
                                        on partnerProduct.idPartner equals partner.id
                                   // Указываем обязательно условие, так как требуется конкретный партнер
                                   where partner.id == SelectedPartner
                                   select new
                                   {
                                       product.nameProduct, // Наименование продукта
                                       partnerProduct.dateSale, // Дата продажи
                                       partnerProduct.quantity // Количество
                                   }).ToList();

                    // Устанавливаем источник данных для элемента управления
                    listHistory.ItemsSource = history;

                    //Устанавливаем наименование партнера
                    var name = dbContext.Partners
                                               .FirstOrDefault(p => p.id == SelectedPartner);

                    namePartnerBox.Text = name.namePartner;
                }
            }
            catch
            {
                // Обработка исключения, диалог с пользователем
                MessageBox.Show(
                    $"Произошла ошибка загрузки базы данных. Обратитесь к системному администратору.", // Текст сообщения
                    "Ошибка", // Заголовок окна
                    MessageBoxButton.OK, // Кнопка 
                    MessageBoxImage.Error); // Пентаграмма
            }

        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
