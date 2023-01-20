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

namespace DZ6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        abstract class Triagle
        {
            protected double side1;
            public double Side1
            {
                get 
                {
                    return side1; 
                } 
                set { } 
            }

            protected double side2;
            public double Side2
            {
                get 
                {
                    return side2; 
                } 
                set { } 
            }

            protected double angel;
            public double Angel
            { 
                get 
                {
                    return angel;
                } 
                set { } 
            }            
            public virtual double perimeter_of_triagle() 
            {
                return Side1 + Side2;
            }
            public virtual double square_of_triagle() 
            {
                return Side1 * Side2 * 0.5;
            }
        }
        // Равнобедренный треугольник
        class Isosceles : Triagle
        {
            public Isosceles(double sid1, double sid2, double ang)
            {
                side1 = sid1;
                side2 = sid2;
                angel = ang * Math.PI / 180 ;
            }
            public override double perimeter_of_triagle()
            {
                base.perimeter_of_triagle();
                if (side1==side2)
                    return side1 + side2 + Math.Sin( angel/2 )*side1*2;
                else
                    return side1 + side2 + Math.Sqrt(Math.Pow(side1,2)+ Math.Pow(side2, 2) - 2 * side1 * side2 * Math.Cos(angel));
            }
            public override double square_of_triagle()
            {
                base.square_of_triagle();
                return side1 * side2 * Math.Sin(angel) * 0.5;
            }
        }
        // Равностороннний треугольник
        class Equilateral : Triagle
        {
            public Equilateral(double sid1, double sid2, double ang)
            {
                side1 = sid1;
                side2 = sid2;
                angel = ang * Math.PI / 180;
            }
            public override double perimeter_of_triagle()
            {
                base.perimeter_of_triagle();
                return side1 + side2 + side2;
            }
            public override double square_of_triagle()
            {
                base.square_of_triagle();
                return Side1 * Side2 * Math.Sqrt(3) * 0.25;
            }
        }
        // Прямоугольный треугольник
        class Right : Triagle
        {
            public Right(double sid1, double sid2, double ang)
            {
                side1 = sid1;
                side2 = sid2;
                angel = (ang * Math.PI) / 180;
            }
            public override double perimeter_of_triagle()
            {
                base.perimeter_of_triagle();
                if (angel == Math.PI / 2)
                    return side1 + side2 + Math.Sqrt(side1 * side1 + side2 * side2);
                
                else 
                {
                    if (side1 > side2)
                        return side1 + side2 + side1 * Math.Sin(angel);
                    else
                        return side1 + side2 + side2 * Math.Sin(angel);
                }
                    
            }
            public override double square_of_triagle()
            {
                base.square_of_triagle();
                if (angel == 90)
                    return side1 * side2 * 0.5;
                else
                    return side1 * side2 * Math.Sin(angel) * 0.5;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ___Button_Click(object sender, RoutedEventArgs e)
        {
            
            if ((double.TryParse(tb_Side1.Text, out double res1) == false) ||
                (double.TryParse(tb_Side2.Text, out double res2) == false) ||
                (double.TryParse(tb_Angel.Text, out double res3) == false) ||
                (tb_Side1.Text == "") || (tb_Side1.Text == "0") ||
                (tb_Side2.Text == "") || (tb_Side2.Text == "0") ||
                (tb_Angel.Text == "") || (tb_Angel.Text == "0") ||
                (Convert.ToDouble(tb_Side1.Text) < 0) ||
                (Convert.ToDouble(tb_Side2.Text) < 0) ||
                (Convert.ToDouble(tb_Angel.Text) < 0) ||
                (Convert.ToDouble(tb_Angel.Text) > 180)  )
            {
                MessageBox.Show("Введите корректные параметры");
            }
            else
            {
                int check = CmB.SelectedIndex; //Берём значение из списка
                double per;
                double squ;
                switch (check)
                {
                    case 0: // Равнобедренный треугольник
                        Isosceles isosceles = new Isosceles(Convert.ToDouble(tb_Side1.Text), Convert.ToDouble(tb_Side2.Text), Convert.ToDouble(tb_Angel.Text));
                        per = isosceles.perimeter_of_triagle();
                        squ = isosceles.square_of_triagle();
                        if (per > 0 && squ > 0)
                        {
                            tb_Perimeter.Text = Convert.ToString(per);
                            tb_Square.Text = Convert.ToString(squ);
                        }
                        else
                            MessageBox.Show("Такого треугольника не существует");
                        break;
                    case 1: // Равностороннний треугольник
                        Equilateral equilateral = new Equilateral(Convert.ToDouble(tb_Side1.Text), Convert.ToDouble(tb_Side2.Text), Convert.ToDouble(tb_Angel.Text));
                        per = equilateral.perimeter_of_triagle();
                        squ = equilateral.square_of_triagle();
                        if (tb_Side1.Text == tb_Side2.Text && double.Parse(tb_Angel.Text) == 60 && per > 0 && squ > 0)
                        {
                            tb_Perimeter.Text = Convert.ToString(per);
                            tb_Square.Text = Convert.ToString(squ);
                        }
                        else
                            MessageBox.Show("Такого треугольника не существует");
                        break;
                    case 2: // Прямоугольный треугольник
                        Right right = new Right(Convert.ToDouble(tb_Side1.Text), Convert.ToDouble(tb_Side2.Text), Convert.ToDouble(tb_Angel.Text));
                        per = right.perimeter_of_triagle();
                        squ = right.square_of_triagle();
                        if (Convert.ToDouble(tb_Angel.Text) <= 90 && per > 0 && squ > 0)
                        {
                            tb_Perimeter.Text = Convert.ToString(per);
                            tb_Square.Text = Convert.ToString(squ);
                        }
                        else
                            MessageBox.Show("Такого треугольника не существует");
                        break;
                }
            }           
        }

        private void CmB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void tb_Square_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tb_Side1_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_Perimeter.Text = String.Format("{0}", "");
            tb_Square.Text = String.Format("{0}", "");
        }

        private void tb_Side2_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_Perimeter.Text = String.Format("{0}", "");
            tb_Square.Text = String.Format("{0}", "");
        }

        private void tb_Angel_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_Perimeter.Text = String.Format("{0}", "");
            tb_Square.Text = String.Format("{0}", "");
        }
    }
}
