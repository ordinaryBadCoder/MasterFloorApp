using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace MasterFloorApp
{
    /// <summary>
    /// Логика взаимодействия для ChangeListPartners.xaml
    /// </summary>
    public partial class ChangeListPartners : Window
    {
        private readonly int SelectedPartner;
        public ChangeListPartners(int SP)
        {
            InitializeComponent();

            SelectedPartner = SP;

            if (SelectedPartner == 0) // Если открыто добавление партнёра
            {
                LoadTypePartner(); // Мы просто подгружаем ComboBox для выбора
            }
            else // Если открыто редактирование партнёра
            {
                LoadTypePartner();
                LoadPartnerForEdit(SelectedPartner); // Подгружаем информацию о соответствующем партнере
            }
        }

        /// <summary>
        /// Метод загрузки данных партнёра для редактирования
        /// </summary>
        /// <param name="SelectedPartner"></param>
        private void LoadPartnerForEdit(int SelectedPartner)
        {
            try
            {
                using (var dbContext = new MasterFloorEntity())
                {
                    // Поиск партнера по выбранному id
                    var Partner = dbContext.Partners
                                           .FirstOrDefault(p => p.id == SelectedPartner);
                    //Загрузка полученных данных в интерфейс
                    NamePartnerBox.Text = Partner.namePartner;
                    TypePartnerBox.SelectedValue = Partner.idPartnerType;
                    RateBox.Text = Convert.ToString(Partner.rate);
                    AddressBox.Text = Partner.address;
                    DirectorNameBox.Text = Partner.directorName;
                    PhoneBox.Text = Partner.phone;
                    EmailBox.Text = Partner.email;

                }
            }
            catch
            {
                // Обработка исключения, диалог с пользователем
                MessageBox.Show(
                    $"Произошла ошибка загрузки данных о партнёре. Обратитесь к системному администратору.", // Текст сообщения
                    "Ошибка", // Заголовок окна
                    MessageBoxButton.OK, // Кнопка 
                    MessageBoxImage.Error); // Пентаграмма
            }
        }


        /// <summary>
        /// Загрузка данных в TypePartnerBox для выбора
        /// </summary>
        private void LoadTypePartner()
        {
            try
            {
                // Создаем контекст базы данных для выполнения запросов
                using (var dbContext = new MasterFloorEntity()){

                    // Выполняем запрос для получения информации о типах партнеров
                    var typesPartner = (from listTypePartner in dbContext.PartnerType
                                       select new
                                       {
                                           listTypePartner.id,  
                                           listTypePartner.typePartner
                                       }).ToList();

                    // Устанавливаем источник данных для элемента управления
                    TypePartnerBox.ItemsSource = typesPartner;
                    TypePartnerBox.SelectedValuePath = "id";
                    TypePartnerBox.DisplayMemberPath = "typePartner";
                }
            }
            catch
            {
                // Обработка исключения, диалог с пользователем
                MessageBox.Show(
                    $"Произошла ошибка загрузки списка типов партнёров. Обратитесь к системному администратору.", // Текст сообщения
                    "Ошибка", // Заголовок окна
                    MessageBoxButton.OK, // Кнопка 
                    MessageBoxImage.Error); // Пентаграмма
            }
        }


      
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveChanged_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextValidation())
                {
                    //Если запущено как окно добавления нового партнера
                    if (SelectedPartner == 0)
                    {
                        using (var dbContext = new MasterFloorEntity())
                        {
                            // Сбор данных из формы
                            Partners partner = new Partners()
                            {
                                namePartner = NamePartnerBox.Text,
                                idPartnerType = Convert.ToInt32(TypePartnerBox.SelectedValue),
                                rate = Convert.ToInt32(RateBox.Text),
                                address = AddressBox.Text,
                                directorName = DirectorNameBox.Text,
                                phone = PhoneBox.Text,
                                email = EmailBox.Text
                            };

                            dbContext.Partners.Add(partner); // добавляем запись в базу данных

                            dbContext.SaveChanges(); // сохраняем изменения                       
                        }
                        MessageBox.Show($"Новый партнёр успешно добавлен.", // Текст сообщения
                                  "Успех!", // Заголовок окна
                                  MessageBoxButton.OK, // Кнопка 
                                  MessageBoxImage.Information); // Пентаграмма

                        // Очистка полей 
                        NamePartnerBox.Text = string.Empty;
                        TypePartnerBox.SelectedIndex = -1;
                        RateBox.Text = string.Empty;
                        AddressBox.Text = string.Empty;
                        DirectorNameBox.Text = string.Empty;
                        PhoneBox.Text = string.Empty;
                        EmailBox.Text = string.Empty;
                    }
                    else // Если SelectedPartner не равен 0, т.е. открыто редактирование
                    {
                        using (var dbContext = new MasterFloorEntity())
                        {
                            // Поиск партнера по выбранному id
                            var Partner = dbContext.Partners
                                           .FirstOrDefault(p => p.id == SelectedPartner);
                            //Вставка изменений
                            Partner.namePartner = NamePartnerBox.Text;
                            Partner.idPartnerType = Convert.ToInt32(TypePartnerBox.SelectedValue);
                            Partner.rate = Convert.ToInt32(RateBox.Text);
                            Partner.address = AddressBox.Text;
                            Partner.directorName = DirectorNameBox.Text;
                            Partner.phone = PhoneBox.Text;
                            Partner.email = EmailBox.Text;

                            dbContext.SaveChanges(); // сохраняем изменения  

                        }

                        MessageBox.Show($"Данные о партнере успешно обновлены!", // Текст сообщения
                                "Успех!", // Заголовок окна
                                MessageBoxButton.OK, // Кнопка 
                                MessageBoxImage.Information); // Пентаграмма
                    }
                }
                else
                {
                    MessageBox.Show($"Ошибка обработки введенной информации. Проверьте ввод или обратитесь к системному администратору.", // Текст сообщения
                                "Ошибка!", // Заголовок окна
                                MessageBoxButton.OK, // Кнопка 
                                MessageBoxImage.Error); // Пентаграмма
                }
            }
            catch
            {
                MessageBox.Show($"Ошибка сохранения информации. Проверьте ввод или обратитесь к системному администратору.", // Текст сообщения
                                 "Ошибка!", // Заголовок окна
                                 MessageBoxButton.OK, // Кнопка 
                                 MessageBoxImage.Error); // Пентаграмма
            }
        }
     
        private void RateBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }


        /// <summary>
        /// Получает введенное значение из RateBox и разрешает только цифры. 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsTextAllowed(string text)
        {
            // Регулярное выражение для проверки, что вводимое значение - это число
            Regex regex = new Regex("[^0-9]+"); // Разрешаем только цифры
            return regex.IsMatch(text);
        }


        /// <summary>
        /// Метод, проверяющий значения перед записью данных
        /// </summary>
        /// <returns></returns>
        private bool TextValidation()
        {
            try
            {
                bool result = true; // Изначально предполагаем, что все проверки пройдены

                // Создаем список всех текстовых полей для проверки
                TextBox[] textBoxes = { NamePartnerBox,
                         RateBox,
                         AddressBox,
                         DirectorNameBox,
                         PhoneBox,
                         EmailBox
                       };

                // Перебираем все textBox и проверяем их
                foreach (var textBox in textBoxes)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.BorderBrush = Brushes.Red; // Устанавливаем красную обводку
                        result = false;
                    }
                    else
                    {
                        textBox.BorderBrush = Brushes.Green; // Устанавливаем зеленую обводку
                    }
                }

                // Проверка выпадающего списка
                if (TypePartnerBox.SelectedIndex == -1)
                {
                    TypePartnerBox.BorderBrush = Brushes.Red; // Устанавливаем красную обводку для выпадающего списка
                    result = false;
                }
                else
                {
                    TypePartnerBox.BorderBrush = Brushes.Green; // Устанавливаем зеленую обводку для выпадающего списка
                }

                // Проверка рейтинга на все условия
                if (Int32.TryParse(RateBox.Text, out int n))
                {
                    if (n < 0 || n > 10)
                    {
                        RateBox.BorderBrush = Brushes.Red; // Устанавливаем красную обводку
                        MessageBox.Show($"Рейтинг может быть значением от 0 до 10. Проверьте вводимые данные.", // Текст сообщения
                                         "Внимание!", // Заголовок окна
                                         MessageBoxButton.OK, // Кнопка 
                                         MessageBoxImage.Warning); // Пентаграмма
                        result = false;
                    }
                    else
                    {
                        RateBox.BorderBrush = Brushes.Green; // Устанавливаем зеленую обводку для выпадающего списка
                    }
                }
                else
                {
                    RateBox.BorderBrush = Brushes.Red; // Устанавливаем красную обводку
                    MessageBox.Show($"Рейтинг может быть только целым числом. Проверьте вводимые данные.", // Текст сообщения
                                     "Внимание!", // Заголовок окна
                                     MessageBoxButton.OK, // Кнопка 
                                     MessageBoxImage.Warning); // Пентаграмма
                    result = false;
                }

                return result;
            }
            catch
            {
                MessageBox.Show( $"Ошибка обработки введенных данных. Проверьте ввод или обратитесь к системному администратору.", // Текст сообщения
                                 "Ошибка!", // Заголовок окна
                                 MessageBoxButton.OK, // Кнопка 
                                 MessageBoxImage.Error); // Пентаграмма
                return false;
            }
        }
    }
}
