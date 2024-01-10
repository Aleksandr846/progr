using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace kyrs_1
{
    // Класс формы
    public partial class Form1 : Form 
    {
        // Путь к файлу с расписанием
        private const string filePath = "schedule.txt";
        // Список игр (расписание)
        private List<Game> schedule = new List<Game>();
        // Конструктор формы
        public Form1()
        {
            InitializeComponent();
            // Приветственное сообщение
            MessageBox.Show("Программа для управления расписанием игр.\nАвтор: Ермолаев Александр Александрович.\nГруппа: 22СН2", "Расписание игр", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Класс, представляющий игру
        public class Game
        {
            // Свойства игры
            public string TeamName { get; set; }
            public DateTime GameDate { get; set; }
            public double AdultTicketPrice { get; set; }
            public double ChildTicketPrice { get; set; }
            // Конструктор игры
            public Game(string teamName, DateTime gameDate, double adultTicketPrice, double childTicketPrice)
            {
                TeamName = teamName;
                GameDate = gameDate;
                AdultTicketPrice = adultTicketPrice;
                ChildTicketPrice = childTicketPrice;
            }

        }
        // Метод обновления списка на форме
        private void UpdateScheduleListBox(List<Game> games = null)
        {
            lstSchedule.Items.Clear();
            foreach (Game game in schedule)
            {
                // Используем ToShortDateString() для вывода только даты без времени
                string formattedDate = game.GameDate.ToShortDateString();
                string displayText = $"{game.TeamName} - {formattedDate} - Цена Взрослый: {game.AdultTicketPrice:C} - Цена Детский: {game.ChildTicketPrice:C}";
                lstSchedule.Items.Add(displayText);
            }
        }
        // Обработчик нажатия кнопки "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Окно для ввода названия команды
            string teamName = InputDialog("Введите название команды");
            if (teamName == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("Введите название команды.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Окно для ввода цены
            double adultTicketPrice = InputPriceDialog("Введите цену билета для взрослых");

            if (adultTicketPrice == -1)
            {
                return;
            }

            // Окно для выбора даты игры
            DateTime gameDate = InputDateDialog("Выберите дату игры");

            // Проверка, была ли выбрана минимальная дата
            if (gameDate == DateTime.MinValue)
            {
                return;
            }

            // Создание новой игры и добавление её в расписание
            Game newGame = new Game(teamName, gameDate, adultTicketPrice, adultTicketPrice * 0.5);
            schedule.Add(newGame);

            // Обновление списка на форме
            UpdateScheduleListBox();

            MessageBox.Show($"Игра для команды '{teamName}' успешно добавлена.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Метод для ввода названия команды
        private string InputDialog(string prompt)
        {
            using (Form inputForm = new Form())
            {
                Label label = new Label() { Left = 20, Top = 20, Text = prompt };
                TextBox textBox = new TextBox() { Left = 20, Top = 60, Width = 175 };
                Button okButton = new Button() { Text = "OK", Left = 210, Width = 70, Top = 48, DialogResult = DialogResult.OK };
                Button cancelButton = new Button() { Text = "Отмена", Left = 210, Width = 70, Top = 78, DialogResult = DialogResult.Cancel };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.Controls.Add(cancelButton);

                inputForm.AcceptButton = okButton;
                inputForm.CancelButton = cancelButton;

                // Проверяем результат диалога
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show("Заполните поле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return InputDialog(prompt); // Рекурсивный вызов в случае пустого ввода
                    }

                    return textBox.Text;
                }
                else
                {
                    // Возвращаем null в случае отмены
                    return null;
                }
            }
        }
        // Метод для ввода цены
        private double InputPriceDialog(string prompt)
        {
            using (Form inputForm = new Form())
            {
                Label label = new Label() { Left = 20, Top = 20, Text = prompt };
                TextBox textBox = new TextBox() { Left = 20, Top = 60, Width = 175 };
                Button okButton = new Button() { Text = "OK", Left = 210, Width = 70, Top = 48 };
                Button cancelButton = new Button() { Text = "Отмена", Left = 210, Width = 70, Top = 78 };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.Controls.Add(cancelButton);

                inputForm.AcceptButton = okButton;

                okButton.Click += (sender, e) => inputForm.DialogResult = DialogResult.OK;
                cancelButton.Click += (sender, e) => inputForm.DialogResult = DialogResult.Cancel;

                // Проверяем результат диалога
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    double result;
                    if (double.TryParse(textBox.Text, out result))
                    {
                        return result;
                    }
                    else
                    {
                        MessageBox.Show("Некорректное значение для цены билета. Пожалуйста, введите числовое значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return InputPriceDialog(prompt); // Рекурсивный вызов в случае ошибочного ввода
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
        // Метод для ввода даты
        private DateTime InputDateDialog(string prompt)
        {
            using (Form dateForm = new Form())
            {
                dateForm.Text = prompt;

                DateTimePicker dtpGameDate = new DateTimePicker();
                dtpGameDate.Format = DateTimePickerFormat.Short;
                dtpGameDate.Location = new Point(50, 20);

                Button btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.DialogResult = DialogResult.OK;
                btnOK.Location = new Point(50, 60);

                Button btnCancel = new Button();
                btnCancel.Text = "Отмена";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(160, 60);

                dateForm.AcceptButton = btnOK;

                dateForm.Controls.Add(dtpGameDate);
                dateForm.Controls.Add(btnOK);
                dateForm.Controls.Add(btnCancel);

                DialogResult dateResult = dateForm.ShowDialog();

                if (dateResult == DialogResult.OK)
                {
                    return dtpGameDate.Value;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }
        // Обработчик нажатия кнопки "Изменить данные"
        private void menuItemSupp_Click(object sender, EventArgs e)
        {
            // Окно для ввода данных
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Введите новые данные";

                // Элементы для ввода
                TextBox txtTeamName = new TextBox();
                txtTeamName.Location = new Point(50, 20);

                DateTimePicker dtpGameDate = new DateTimePicker();
                dtpGameDate.Format = DateTimePickerFormat.Short;
                dtpGameDate.Location = new Point(50, 60);

                NumericUpDown numAdultTicketPrice = new NumericUpDown();
                numAdultTicketPrice.DecimalPlaces = 2;
                numAdultTicketPrice.Minimum = 0;
                numAdultTicketPrice.Maximum = 10000;
                numAdultTicketPrice.Location = new Point(50, 100);

                // Кнопки
                Button btnOK = new Button();
                btnOK.Text = "OK";
                btnOK.DialogResult = DialogResult.OK;
                btnOK.Location = new Point(50, 140);

                Button btnCancel = new Button();
                btnCancel.Text = "Отмена";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(120, 140);

                // Добавление элементов на форму
                inputForm.Controls.Add(txtTeamName);
                inputForm.Controls.Add(dtpGameDate);
                inputForm.Controls.Add(numAdultTicketPrice);
                inputForm.Controls.Add(btnOK);
                inputForm.Controls.Add(btnCancel);

                // Отображение формы и обработка результата
                DialogResult result = inputForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Получение введенных данных
                    string teamName = txtTeamName.Text;
                    DateTime newGameDate = dtpGameDate.Value;
                    double newAdultTicketPrice = (double)numAdultTicketPrice.Value;

                    // Поиск существующей игры
                    Game existingGame = schedule.FirstOrDefault(game => game.TeamName == teamName);

                    if (existingGame == null)
                    {
                        MessageBox.Show($"Команда '{teamName}' не найдена. Дополнение данных невозможно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Обновление данных существующей игры
                    existingGame.GameDate = newGameDate;
                    existingGame.AdultTicketPrice = newAdultTicketPrice;
                    existingGame.ChildTicketPrice = newAdultTicketPrice * 0.5;

                    // Обновление списка на форме
                    UpdateScheduleListBox();

                    MessageBox.Show($"Данные для команды '{teamName}' успешно дополнены.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // Обработчик нажатия кнопки "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверка, выбрана ли запись для удаления
            if (lstSchedule.SelectedIndex == -1)
            {
                // Вывод сообщения, если запись не выбрана
                MessageBox.Show("Запись не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получение выбранной записи
            Game selectedGame = schedule[lstSchedule.SelectedIndex];

            // Подтверждение удаления
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить запись для команды '{selectedGame.TeamName}'?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Удаление записи
                schedule.RemoveAt(lstSchedule.SelectedIndex);

                // Обновление списка на форме
                UpdateScheduleListBox();

                // Вывод сообщения о успешном удалении
                MessageBox.Show("Запись успешно удалена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Обработчик нажатия кнопки "Сохранить в файл"
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Запись данных в файл
                using (StreamWriter writer = new StreamWriter("schedule.txt"))
                {
                    foreach (var game in schedule)
                    {
                        writer.WriteLine($"{game.TeamName}, {game.GameDate.ToString("yyyy-MM-dd")}, {game.AdultTicketPrice}, {game.ChildTicketPrice}");
                    }
                }

                // Вывод сообщения об успешном сохранении
                MessageBox.Show("Данные успешно сохранены в файл!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обработчик нажатия кнопки "Прочитать из файла"
        private void menuItemRead_Click(object sender, EventArgs e)
        {
            try
            {
                string executablePath = Application.ExecutablePath;
                string directoryPath = Path.GetDirectoryName(executablePath);

                string filePath = Path.Combine(directoryPath, "schedule.txt");

                if (File.Exists(filePath))
                {
                    // Чтение данных из файла
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string fileContent = reader.ReadToEnd();
                        MessageBox.Show($"Содержимое файла:\n\n{fileContent}", "Данные из файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Файл schedule.txt не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обработчик нажатия кнопки "Загрузить из файла"
        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            // Чтение данных из файла

            string[] lines = File.ReadAllLines(filePath);

            // Проверка, есть ли данные в файле
            if (lines.Length == 0)
            {
                MessageBox.Show("Файл пуст. Добавьте записи и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            schedule.Clear();
            using (StreamReader reader = new StreamReader("schedule.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string teamName = parts[0];
                    DateTime gameDate = DateTime.Parse(parts[1]);
                    double adultTicketPrice = Convert.ToDouble(parts[2]);
                    double childTicketPrice = Convert.ToDouble(parts[3]);

                    schedule.Add(new Game(teamName, gameDate, adultTicketPrice, childTicketPrice));
                }
            }

            // Обновление списка на форме
            UpdateScheduleListBox();

            // Вывод сообщения об успешном чтении из файла
            MessageBox.Show("Данные успешно загружены из файла!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Обработчик нажатия кнопки "Поиск"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Поиск информации по заданному атрибуту
            string searchTerm = InputDialog("Введите текст");

            // Проверка, был ли введен поисковый запрос
            if (searchTerm == null)
            {
                return;
            }

            var results = schedule.Where(game =>
                game.TeamName.ToLower().Contains(searchTerm.ToLower()) ||
                game.GameDate.ToString().Contains(searchTerm) ||
                game.AdultTicketPrice.ToString().Contains(searchTerm) ||
                game.ChildTicketPrice.ToString().Contains(searchTerm)
            ).ToList();

            // Очистка списка перед добавлением новых результатов
            lstSchedule.Items.Clear();

            // Вывод найденных результатов в ListBox
            foreach (Game result in results)
            {
                lstSchedule.Items.Add($"{result.TeamName} - {result.GameDate.ToString("yyyy-MM-dd")} - Цена Взрослый: {result.AdultTicketPrice:C} - Цена Детский: {result.ChildTicketPrice:C}");
            }
        }
        // Обработчик нажатия кнопки "Сортировка"
        private void btnSort_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли элементы в ListBox
            if (lstSchedule.Items.Count == 0)
            {
                MessageBox.Show("Нет данных для сортировки. Добавьте записи и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < schedule.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < schedule.Count; j++)
                {
                    // Сравниваем цены билетов для взрослых
                    if (schedule[j].AdultTicketPrice < schedule[minIndex].AdultTicketPrice)
                    {
                        minIndex = j;
                    }
                }

                // Меняем местами элементы, если найден минимальный
                if (minIndex != i)
                {
                    Game temp = schedule[i];
                    schedule[i] = schedule[minIndex];
                    schedule[minIndex] = temp;
                }
            }

            // Обновляем список на форме
            UpdateScheduleListBox();

            // Вывод сообщения о завершении сортировки
            MessageBox.Show("Расписание отсортировано по цене билета для взрослых.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Обработчик нажатия кнопки "Создать диаграмму"
        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли данные для построения диаграммы
            if (schedule.Count == 0)
            {
                MessageBox.Show("Нет данных для построения диаграммы. Добавьте записи и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создание диаграммы с выбранными цветами
            GenerateChart();

            // Показываем элементы
            chart.Visible = true;
            label2.Visible = true;

            // Вывод сообщения о том, что диаграмма построена
            MessageBox.Show("Диаграмма построена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Метод для создания диаграммы
        private void GenerateChart()
        {
            // Очистка существующих данных диаграммы
            chart.Series.Clear();

            // Создание новой серии для диаграммы
            Series series = new Series("Цена билета для взрослых");

            // Установка типа диаграммы
            series.ChartType = SeriesChartType.Pie;

            // Добавление данных из расписания в диаграмму
            foreach (Game game in schedule)
            {
                Color lineColor = ChooseLineColor();

                // Проверка, был ли выбран цвет
                if (lineColor == Color.Black)
                {
                    // Если цвет не выбран (диалог был отменен), пропускаем данную точку данных
                    continue;
                }

                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueXY(game.TeamName, game.AdultTicketPrice);
                dataPoint.Color = lineColor;
                series.Points.Add(dataPoint);
            }

            chart.Series.Add(series);
        }


        // Метод для для выбора цвета
        private Color ChooseLineColor()
        {
            // Инициализация диалога выбора цвета
            ColorDialog colorDialog = new ColorDialog();

            // Показать диалог и получить выбранный цвет
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                return colorDialog.Color;
            }
            else
            {
                // Возвращаем цвет по умолчанию, если диалог был отменен
                MessageBox.Show("Цвет не был выбран, переходим к выбору для след игры", "След.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return Color.Black;
            }
        }

        // Обработчик нажатия кнопки "Выход"
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Закрытие приложения
                Application.Exit();
            }
        }
        // Обработчик события загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Присвоение клавиш для меню
            menuItemAdd.ShortcutKeys = Keys.F1;
            menuItemSupp.ShortcutKeys = Keys.F2;
            menuItemDelete.ShortcutKeys = Keys.F3;
            menuItemSaveToFile.ShortcutKeys = Keys.F4;
            menuItemRead.ShortcutKeys = Keys.F5;
            menuItemLoadFromFile.ShortcutKeys = Keys.F6;
            menuItemSearch.ShortcutKeys = Keys.F7;
            menuItemSort.ShortcutKeys = Keys.F8;
            menuItemGenerateChart.ShortcutKeys = Keys.F9;
            menuItemExit.ShortcutKeys = Keys.F10;
            // Скрываем элементы управления при загрузке формы
            chart.Visible = false;
            label2.Visible = false;
        }
       
    }
}
