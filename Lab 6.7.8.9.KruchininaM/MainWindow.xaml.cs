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

        private void ProcessListButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            LinkedList<char> list = new LinkedList<char>(input.ToCharArray());

            LinkedListNode<char> current = list.First;
            while (current != null)
            {
                if (current.Value < 48)
                {
                    list.Remove(current);
                    break;
                }
                if (Char.IsDigit(current.Value))
                {
                    list.AddAfter(current, '%');
                    current = current.Next;
                }
                current = current.Next;
            }

            OutputTextBlock.Text = string.Join("", list);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(NumberOfRecordsTextBox.Text);
            Dictionary<string, Dictionary<string, int>> purchases = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = PurchaseRecordsTextBox.Text.Split(' ');

                string customer = input[0];
                string product = input[1];
                int quantity = int.Parse(input[2]);

                if (!purchases.ContainsKey(customer))
                {
                    purchases[customer] = new Dictionary<string, int>();
                }

                if (!purchases[customer].ContainsKey(product))
                {
                    purchases[customer][product] = quantity;
                }
                else
                {
                    purchases[customer][product] += quantity;
                }
            }

            foreach (var customer in purchases)
            {
                string customerPurchases = $"{customer.Key}: ";
                foreach (var purchase in customer.Value)
                {
                    customerPurchases += $"{purchase.Key} - {purchase.Value}, ";
                }
                MessageBox.Show(customerPurchases.TrimEnd(',', ' '), "Покупки");
            }
        }
    }
}