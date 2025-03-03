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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterFloorApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPartnerList();
        }

        /// <summary>
        /// Метод для загрузки и вывода списка партнеров в интерфейс
        /// </summary>
        private void LoadPartnerList()
        {
            try
            {
                // Создаем контекст базы данных для выполнения запросов
                using (var dbContext = new MasterFloorEntity())
                {
                    // Выполняем запрос для получения информации о партнерах
                    var partners = (
                        from partner in dbContext.Partners
                            // Соединяем с таблицей PartnerType по типу партнера
                        join partnerType in dbContext.PartnerType
                            on partner.idPartnerType equals partnerType.id
                        // Соединяем с таблицей PartnerProduct по идентификатору партнера
                        join partnerProduct in dbContext.PartnerProduct
                            on partner.id equals partnerProduct.idPartner into partnerProducts
                        // Вычисляем общую сумму количества продуктов для каждого партнера
                        let totalQuantity = partnerProducts.Sum(p => p.quantity)
                        select new
                        {
                            partner.id, // Идентификатор партнера
                            partnerType.typePartner, // Название типа партнера
                            partner.namePartner, // Название организации
                            partner.directorName, // ФИО директора
                            partner.phone, // Телефон
                            partner.rate, // Рейтинг
                                          // Определяем скидку на основе общей суммы количества продуктов
                            discount = partnerProducts.Any()
                                ? (totalQuantity < 10000) ? 0 // Скидка 0%, если сумма меньше 10,000
                                : (totalQuantity < 50000) ? 5 // Скидка 5%, если сумма от 10,000 до 49,999
                                : (totalQuantity < 300000) ? 10 // Скидка 10%, если сумма от 50,000 до 299,999
                                : 15 // Скидка 15%, если сумма 300,000 и более
                                : 0 // Скидка 0%, если нет связанных продуктов
                        }
                    ).ToList();

                    // Устанавливаем источник данных для элемента управления
                    listPartners.SelectedValuePath = "id";
                    listPartners.ItemsSource = partners;
                }
            }
            catch
            {
                // Обработка исключения, диалог с пользователем
                MessageBox.Show(
                    $"Произошла ошибка загрузки базы данных. Обратитесь к системному администратору.", // Текст сообщения
                    "Ошибка", // Заголовок окна
                    MessageBoxButton.OK, // Кнопка 
                    MessageBoxImage.Error ); // Пентаграмма

            }

        }

        
        private void AddNewPartner_Click(object sender, RoutedEventArgs e)
        {
            int SelectedPartner = 0;
            ChangeListPartners changeListPartners = new ChangeListPartners(SelectedPartner);
            changeListPartners.ShowDialog();

            LoadPartnerList();
        }

        private void listPartners_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int SelectedPartner = (int)listPartners.SelectedValue;

            ChangeListPartners changeListPartners = new ChangeListPartners(SelectedPartner);
            changeListPartners.ShowDialog();

            LoadPartnerList();
        }

        private void CheckHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Если выбран какой-либо индекс в листе, который не равен -1, 
                //то есть выбран какой-либо объект
                if (listPartners.SelectedIndex != -1)
                {
                    int SelectedPartner = (int)listPartners.SelectedValue;

                    SalesHistory salesHistory = new SalesHistory(SelectedPartner);
                    salesHistory.ShowDialog();
                }
                else
                {
                    // Сообщение для пользователя
                    MessageBox.Show($"Выберите партнера в списке для просмотра истории.", // Текст сообщения
                                     "Не выбран объект", // Заголовок окна
                                     MessageBoxButton.OK, // Кнопка 
                                     MessageBoxImage.Exclamation); // Пентаграмма
                }
            }
            catch
            {
                // Обработка исключения, диалог с пользователем
                MessageBox.Show($"Произошла ошибка обработки запроса. Обратитесь к системному администратору.", // Текст сообщения
                                "Ошибка", // Заголовок окна
                                MessageBoxButton.OK, // Кнопка 
                                MessageBoxImage.Error); // Пентаграмма
            }
        }
    }
}
