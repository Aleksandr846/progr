using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrss_2
{
    public partial class Form1 : Form
    {
        //Конструктор формы
        public Form1()
        {
            InitializeComponent();
            // Приветственное сообщение
            MessageBox.Show("Программа №2.\nАвтор: Ермолаев Александр Александрович.\nГруппа: 22СН2", "2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Обработчик события для кнопки, выполняющей операцию вычисления определенного интеграла.
        private void btnFirst(object sender, EventArgs e)
        {
            //Цикл, который будет повторяться, пока не будет выполнено условие выхода.
            while (true)
            {
                // Окно для ввода данных
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "Введите данные";

                    // Элементы для ввода
                    Label labelIntegralA = new Label();
                    labelIntegralA.Text = "Введите  A:";
                    labelIntegralA.Location = new Point(10, 20);
                    inputForm.Controls.Add(labelIntegralA);

                    TextBox txtIntegralA = new TextBox();
                    txtIntegralA.Location = new Point(10, 45);
                    inputForm.Controls.Add(txtIntegralA);

                    Label labelIntegralB = new Label();
                    labelIntegralB.Text = "Введите B:";
                    labelIntegralB.Location = new Point(10, 70);
                    inputForm.Controls.Add(labelIntegralB);

                    TextBox txtIntegralB = new TextBox();
                    txtIntegralB.Location = new Point(10, 95);
                    inputForm.Controls.Add(txtIntegralB);

                    Label labelAbsolute = new Label();
                    labelAbsolute.Text = "Введите R:";
                    labelAbsolute.Location = new Point(10, 120);
                    inputForm.Controls.Add(labelAbsolute);

                    TextBox txtAbsoluteError = new TextBox();
                    txtAbsoluteError.Location = new Point(10, 145);
                    inputForm.Controls.Add(txtAbsoluteError);

                    // Кнопки
                    Button btnCalculateIntegral = new Button();
                    btnCalculateIntegral.Text = "OK";
                    btnCalculateIntegral.DialogResult = DialogResult.OK;
                    btnCalculateIntegral.Location = new Point(10, 180);
                    inputForm.Controls.Add(btnCalculateIntegral);

                    Button btnCancel = new Button();
                    btnCancel.Text = "Отмена";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.Location = new Point(100, 180);
                    inputForm.Controls.Add(btnCancel);
                    //Показ формы ввода и получение результата (OK или Cancel).
                    DialogResult result = inputForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получение введенных значений и вызов метода для вычисления определенного интеграла
                        if (string.IsNullOrWhiteSpace(txtIntegralA.Text) || string.IsNullOrWhiteSpace(txtIntegralB.Text) || string.IsNullOrWhiteSpace(txtAbsoluteError.Text))
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double a, b, r;

                        if (!double.TryParse(txtIntegralA.Text, out a) || !double.TryParse(txtIntegralB.Text, out b) || !double.TryParse(txtAbsoluteError.Text, out r))
                        {
                            MessageBox.Show("Ошибка ввода. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double integralResult = CalculateIntegral(a, b, r);

                        // Вывод результата
                        MessageBox.Show($"Значение определенного интеграла: {integralResult}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break; // Выходим из цикла после успешного выполнения операции
                    }
                    else
                    {
                        // Если пользователь нажал "Отмена", выходим из цикла
                        break;
                    }
                }

            }
        }

        //Обработчик события для кнопки, выполняющей операцию решения уравнения.
        private void btnSolveEquationForm_Click(object sender, EventArgs e)
        {
            //Цикл, который будет повторяться, пока не будет выполнено условие выхода.
            while (true)
            {
                // Окно для ввода данных
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "Введите данные";
                    inputForm.Width = 300; 

                    // Элементы для ввода
                    Label labelA = new Label();
                    labelA.Text = "Введите A:";
                    labelA.Location = new Point(10, 20);
                    labelA.Width = 250; 
                    inputForm.Controls.Add(labelA);

                    TextBox txtEquationA = new TextBox();
                    txtEquationA.Location = new Point(10, 45);
                    inputForm.Controls.Add(txtEquationA);

                    Label labelB = new Label();
                    labelB.Text = "Введите B:";
                    labelB.Location = new Point(10, 70);
                    labelB.Width = 250; 
                    inputForm.Controls.Add(labelB);

                    TextBox txtEquationB = new TextBox();
                    txtEquationB.Location = new Point(10, 95);
                    inputForm.Controls.Add(txtEquationB);

                    Label labelError = new Label();
                    labelError.Text = "Введите R:";
                    labelError.Location = new Point(10, 120);
                    labelError.Width = 250;
                    inputForm.Controls.Add(labelError);

                    TextBox txtEquationError = new TextBox();
                    txtEquationError.Location = new Point(10, 145);
                    inputForm.Controls.Add(txtEquationError);

                    Label labelMaxIterations = new Label();
                    labelMaxIterations.Text = "Введите N:";
                    labelMaxIterations.Location = new Point(10, 170);
                    labelMaxIterations.Width = 250; 
                    inputForm.Controls.Add(labelMaxIterations);

                    TextBox txtMaxIterations = new TextBox();
                    txtMaxIterations.Location = new Point(10, 195);
                    inputForm.Controls.Add(txtMaxIterations);

                    // Кнопки
                    Button btnSolveEquation = new Button();
                    btnSolveEquation.Text = "OK";
                    btnSolveEquation.DialogResult = DialogResult.OK;
                    btnSolveEquation.Location = new Point(10, 230);
                    inputForm.Controls.Add(btnSolveEquation);

                    Button btnCancel = new Button();
                    btnCancel.Text = "Отмена";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.Location = new Point(100, 230);
                    inputForm.Controls.Add(btnCancel);
                    //Показ формы ввода и получение результата (OK или Cancel).
                    DialogResult result = inputForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получение введенных значений и вызов метода для решения уравнения
                        if (string.IsNullOrWhiteSpace(txtEquationA.Text) || string.IsNullOrWhiteSpace(txtEquationB.Text) || string.IsNullOrWhiteSpace(txtEquationError.Text) || string.IsNullOrWhiteSpace(txtMaxIterations.Text))
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double a, b, error, nMax;

                        if (!double.TryParse(txtEquationA.Text, out a) || !double.TryParse(txtEquationB.Text, out b) || !double.TryParse(txtEquationError.Text, out error) || !double.TryParse(txtMaxIterations.Text, out nMax))
                        {
                            MessageBox.Show("Ошибка ввода. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double equationResult = SolveEquation(a, b, error, nMax);

                        // Вывод результата
                        MessageBox.Show($"Найденный корень уравнения: {equationResult}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break; // Выходим из цикла после успешного выполнения операции
                    }
                    else
                    {
                        // Если пользователь нажал "Отмена", выходим из цикла
                        break;
                    }
                }

            }

        }

        private void menuItemChart1_Click(object sender, EventArgs e)
        {
            //цикл для повторного отображения формы ввода данных в случае ошибок.
            while (true)
            {
                // Создаем новую форму для ввода данных
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "Введите данные для графика";
                    inputForm.Width = 300; 

                    // Элементы для ввода
                    Label labelA = new Label();
                    labelA.Text = "Введите A:";
                    labelA.Location = new Point(10, 20);
                    labelA.Width = 250; 
                    inputForm.Controls.Add(labelA);

                    TextBox txtA = new TextBox();
                    txtA.Location = new Point(10, 45);
                    inputForm.Controls.Add(txtA);

                    Label labelB = new Label();
                    labelB.Text = "Введите B:";
                    labelB.Location = new Point(10, 70);
                    labelB.Width = 250; 
                    inputForm.Controls.Add(labelB);

                    TextBox txtB = new TextBox();
                    txtB.Location = new Point(10, 95);
                    inputForm.Controls.Add(txtB);

                    Label labelStep = new Label();
                    labelStep.Text = "Введите R:";
                    labelStep.Location = new Point(10, 120);
                    labelStep.Width = 250;
                    inputForm.Controls.Add(labelStep);

                    TextBox txtStep = new TextBox();
                    txtStep.Location = new Point(10, 145);
                    inputForm.Controls.Add(txtStep);

                    // Кнопки
                    Button btnOK = new Button();
                    btnOK.Text = "OK";
                    btnOK.DialogResult = DialogResult.OK;
                    btnOK.Location = new Point(10, 180);
                    inputForm.Controls.Add(btnOK);

                    Button btnCancel = new Button();
                    btnCancel.Text = "Отмена";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.Location = new Point(100, 180);
                    inputForm.Controls.Add(btnCancel);

                    DialogResult result = inputForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получение введенных значений
                        if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text) || string.IsNullOrWhiteSpace(txtStep.Text))
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double a, b, step;

                        if (!double.TryParse(txtA.Text, out a) || !double.TryParse(txtB.Text, out b) || !double.TryParse(txtStep.Text, out step))
                        {
                            MessageBox.Show("Ошибка ввода. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }
                        chartFunction.Visible = true;
                        label1.Visible = true;
                        // Вызываем метод для построения графика
                        DrawIntegralGraph(a, b, step, SeriesChartType.Line);
                        break; // Выходим из цикла после успешного выполнения операции
                    }
                    else
                    {
                        // Если пользователь нажал "Отмена", выходим из цикла
                        break;
                    }
                }
            }
        }
        //Метод построения графика функции интеграла
        private void DrawIntegralGraph(double a, double b, double step, SeriesChartType chartType)
        {
            //Очистка существующих данных на графике перед построением нового.
            chartFunction.Series.Clear();
            //Создание серии для графика с указанным именем.
            Series series = new Series("График функции");
            series.ChartType = chartType;
            //Цикл для добавления точек графика
            for (double x = a; x <= b; x += step)
            {
                series.Points.AddXY(x, Math.Cos(Math.Sqrt(x)));
            }
            //Добавление построенной серии на график.
            chartFunction.Series.Add(series);
        }

        //Построение графика уравнения
        private void menuItemChart2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                //цикл для повторного отображения формы ввода данных в случае ошибок.
                // Создаем новую форму для ввода данных
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "Введите данные для графика";
                    inputForm.Width = 300; 

                    // Элементы для ввода
                    Label labelA = new Label();
                    labelA.Text = "Введите A:";
                    labelA.Location = new Point(10, 20);
                    labelA.Width = 250; 
                    inputForm.Controls.Add(labelA);

                    TextBox txtA = new TextBox();
                    txtA.Location = new Point(10, 45);
                    inputForm.Controls.Add(txtA);

                    Label labelB = new Label();
                    labelB.Text = "Введите B:";
                    labelB.Location = new Point(10, 70);
                    labelB.Width = 250; 
                    inputForm.Controls.Add(labelB);

                    TextBox txtB = new TextBox();
                    txtB.Location = new Point(10, 95);
                    inputForm.Controls.Add(txtB);

                    Label labelStep = new Label();
                    labelStep.Text = "Введите R:";
                    labelStep.Location = new Point(10, 120);
                    labelStep.Width = 250; 
                    inputForm.Controls.Add(labelStep);

                    TextBox txtStep = new TextBox();
                    txtStep.Location = new Point(10, 145);
                    inputForm.Controls.Add(txtStep);

                    // Кнопки
                    Button btnOK = new Button();
                    btnOK.Text = "OK";
                    btnOK.DialogResult = DialogResult.OK;
                    btnOK.Location = new Point(10, 180);
                    inputForm.Controls.Add(btnOK);

                    Button btnCancel = new Button();
                    btnCancel.Text = "Отмена";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.Location = new Point(100, 180);
                    inputForm.Controls.Add(btnCancel);

                    DialogResult result = inputForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получение введенных значений
                        if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text) || string.IsNullOrWhiteSpace(txtStep.Text))
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }

                        double a, b, step;

                        if (!double.TryParse(txtA.Text, out a) || !double.TryParse(txtB.Text, out b) || !double.TryParse(txtStep.Text, out step))
                        {
                            MessageBox.Show("Ошибка ввода. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Перезапускаем цикл, чтобы снова показать окно ввода данных
                        }
                        chartFunction.Visible = true;
                        label1.Visible = true;
                        // Вызываем метод для построения графика
                        DrawEquationGraph(a, b, step, SeriesChartType.Line);
                        break; // Выходим из цикла после успешного выполнения операции
                    }
                    else
                    {
                        // Если пользователь нажал "Отмена", выходим из цикла
                        break;
                    }
                }
            }
        }


        // Метод для вычисления определенного интеграла методом прямоугольников
        private double CalculateIntegral(double a, double b, double r)
        {
            int n = 10;
            double s1, s2;
            double h;

            do
            {
                h = (b - a) / n;
                s1 = 0;

                for (int i = 0; i < n; i++)
                {
                    double xi = a + i * h + h / 2;
                    s1 += Math.Cos(Math.Sqrt(xi));
                }

                s1 *= h;

                n *= 2; 

                h = (b - a) / n;
                s2 = 0;

                for (int i = 0; i < n; i++)
                {
                    double xi = a + i * h + h / 2;
                    s2 += Math.Cos(Math.Sqrt(xi));
                }

                s2 *= h;

            } while (Math.Abs(s1 - s2) >= r);

            return s2;
        }

        // Метод для решения уравнения методом хорд
        private double SolveEquation(double a, double b, double error, double nMax)
        {
            double fa = Function(a);
            double fb = Function(b);

            if (fa * fb > 0)
            {
                MessageBox.Show("На заданном интервале нет корней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return double.NaN;
            }

            double x1, fx1;
            double x2 = a;
            double fx2 = fa;
            int n = 0;

            do
            {
                x1 = x2;
                fx1 = fx2;

                x2 = x1 - Function(x1) * (b - a) / (Function(b) - Function(a));
                fx2 = Function(x2);

                n++;

                if (fx2 == 0 || Math.Abs(x2 - x1) < error)
                    break;

                if (Function(x1) * fx2 < 0)
                    b = x2;
                else
                    a = x2;

            } while (n < nMax);

            MessageBox.Show($"Количество итераций: {n}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return x2;
        }

        // Функция, участвующая в уравнении и интеграле
        private double Function(double x)
        {
            return Math.Sinh(x) - Math.Sqrt(x + 1);
        }
        //Метод построения графика уравнения
        private void DrawEquationGraph(double a, double b, double step, SeriesChartType chartType)
        {
            //Очистка существующих данных на графике перед построением нового.
            chartFunction.Series.Clear();
            //Создание серии для графика с указанным именем.
            Series series = new Series("График уравнения");
            series.ChartType = chartType;
            //Цикл для добавления точек графика
            for (double x = a; x <= b; x += step)
            {
                series.Points.AddXY(x, Function(x));
            }

            chartFunction.Series.Add(series);
        }


        //Выход из программы
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }
        //Событие загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            menuItemIntegral.ShortcutKeys = Keys.F1;
            menuItemEquation.ShortcutKeys = Keys.F2;
            menuItemChart1.ShortcutKeys = Keys.F3;
            menuItemChart2.ShortcutKeys = Keys.F4;
            menuItemExit.ShortcutKeys = Keys.F5;
            chartFunction.Visible = false;
            label1.Visible = false;
        }
    }
}
