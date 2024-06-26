using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_6._7._8._9.KruchininaM
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
            string input = inputTextBox.Text;
            string[] numbers = input.Split(' ');

            if (numbers.Length != 9)
            {
                resultTextBlock.Text = "Введите массив из 9 вещественных чисел через пробел.";
                return;
            }

            double[] nums = new double[9];
            for (int i = 0; i < 9; i++)
            {
                nums[i] = Convert.ToDouble(numbers[i]);
            }

            double[] greaterThanTen = nums.Where(n => Math.Abs(n) > 10).ToArray();

            if (greaterThanTen.Length == 0)
            {
                resultTextBlock.Text = "Нет чисел с модулем больше 10";
                return;
            }

            double average = greaterThanTen.Average();
            resultTextBlock.Text = $"элементы исходного, которые по модулю больше 10: {average}";
        }
        private Queue<double> numberQueue = new Queue<double>();
        private void Enqueue_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(txtNumber.Text, out double number))
            {
                numberQueue.Enqueue(number);
                lstQueue.Items.Add(number);
            }
            else
            {
                MessageBox.Show("Пожалйста введите правильное число.");
            }
        }

        private void Dequeue_Click(object sender, RoutedEventArgs e)
        {
            if (numberQueue.Count > 0)
            {
                double number = numberQueue.Dequeue();
                lstQueue.Items.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("Очередь пуста.");
            }
        }

        private void FindMin_Click(object sender, RoutedEventArgs e)
        {
            if (numberQueue.Count > 0)
            {
                double minValue = numberQueue.Peek();
                foreach (double number in numberQueue)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }
                MessageBox.Show("Минимальный элемент: " + minValue);
            }
            else
            {
                MessageBox.Show("Очередь пуста.");
            }
        }
    }
}