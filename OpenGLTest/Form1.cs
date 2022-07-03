using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Tao.OpenGl;                           // Для работы с библиотекой OpenGL 
using Tao.FreeGlut;                         // Для работы с библиотекой FreeGLUT 
using Tao.Platform.Windows;                 // Для работы с элементом управления SimpleOpenGLControl

namespace OpenGLTest
{
    public partial class Form1 : Form
    {
        bool continuousMovement = false;    // Условие непрерывного вращения
        int x = 10;                         // Координата X источника света
        int y = 10;                         // Координата Y источника света
        int z = -30;                        // Координата Z источника света
        int alpha = 45;                     // Угол поворота
        int last = 0;                       // Номер последней нарисованной фигуры

        /// <summary>
        /// Рисовка тоновой модели фигуры
        /// </summary>
        /// <param name="obj">Номер фигуры</param>
        private void showSolid(int obj)
        {
            switch (obj)
            {
                case 1:
                    {
                        Glut.glutSolidCone(0.2, 0.75, 16, 8); 
                        break;
                    }

                case 2:
                    {
                        Glut.glutSolidCube(0.75); 
                        break;
                    }
                
                case 3:
                    {
                        Glut.glutSolidCylinder(0.2, 0.75, 16, 16);
                        break;
                    }

                case 4:
                    {
                        Gl.glScaled(0.5, 0.5, 0.5);
                        Glut.glutSolidDodecahedron();
                        break;
                    }
    
                case 5:
                    {
                        Glut.glutSolidIcosahedron(); 
                        break;
                    }

                case 6:
                    {
                        Glut.glutSolidOctahedron();
                        break;
                    }

                case 7:
                    {
                        Glut.glutSolidRhombicDodecahedron(); 
                        break;
                    }

                case 8:
                    {
                        double[] offset = { 0.0 };
                        Glut.glutSolidSierpinskiSponge(7, offset, 1);
                        break;
                    }

                case 9:
                    {
                        Glut.glutSolidSphere(0.75, 16, 16);
                        break;

                    }

                case 10:
                    {
                        Glut.glutSolidTeapot(0.5); 
                        break;
                    }

                case 11:
                    {
                        Gl.glRotated(180, 0, 1, 0);
                        Glut.glutSolidTetrahedron(); 
                        break;
                    }

                case 12:
                    {
                        Glut.glutSolidTorus(0.15, 0.65, 16, 16); 
                        break;
                    }
            }
        }

        /// <summary>
        /// Рисовка фигуры
        /// </summary>
        /// <param name="obj">Номер фигуры</param>
        private void draw(int obj)
        {
            // Очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT |
            Gl.GL_ACCUM_BUFFER_BIT);
            // Матрица проецирования
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glRotated(-30, 1, 0, 0);
            Gl.glRotated(alpha, 0, 1, 0);
            // Видовая матрица
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            if (radioButton1.Checked)
            {
                Gl.glColor3f(1, 1, 1);                                  // Белый цвет
                // Выводим glut-примитив в виде каркаса
                switch (obj)
                {
                    case 1:
                        {
                            Glut.glutWireCone(0.2, 0.75, 16, 8);
                            break;
                        }

                    case 2:
                        {
                            Glut.glutWireCube(0.75); 
                            break;
                        }

                    case 3:
                        {
                            Glut.glutWireCylinder(0.2, 0.75, 16, 16);
                            break;
                        }

                    case 4:
                        {
                            Gl.glScaled(0.5, 0.5, 0.5);
                            Glut.glutWireDodecahedron(); 
                            break;
                        }
                     
                    case 5:
                        {
                            Glut.glutWireIcosahedron();
                            break;
                        }

                    case 6:
                        {
                            Glut.glutWireOctahedron(); 
                            break;
                        }

                    case 7:
                        {
                            Glut.glutWireRhombicDodecahedron(); 
                            break;
                        }

                    case 8:
                        {
                            double[] offset = { 0, 0, 0 };
                            Glut.glutWireSierpinskiSponge(7, offset, 1); 
                            break;
                        }

                    case 9:
                        { 
                            Glut.glutWireSphere(0.75, 16, 16); 
                            break; 
                        }

                    case 10:
                        {
                            Glut.glutWireTeapot(0.5); 
                            break;
                        }

                    case 11:
                        {
                            Gl.glRotated(180, 0, 1, 0);
                            Glut.glutWireTetrahedron(); 
                            break;
                        }

                    case 12:
                        {
                            Glut.glutWireTorus(0.15, 0.65, 16, 16); 
                            break;
                        }
                }
            }
            else if (radioButton2.Checked)
            {
                int k1 = 0;
                int k2 = 0;
                int k3 = 0;
                if (radioButton3.Checked)
                {
                    k1 = 0;
                    k2 = 1;
                    k3 = 0;
                }
                if (radioButton4.Checked)
                {
                    k1 = 0;
                    k2 = 0;
                    k3 = 1;  
                }
                if (radioButton5.Checked)
                {
                    k1 = 1;
                    k2 = 0;
                    k3 = 0;   
                }
                if (radioButton6.Checked)
                {
                    k1 = 1;
                    k2 = 1;
                    k3 = 1;
                }
                if (radioButton7.Checked)
                {
                    k1 = 1;
                    k2 = 0;
                    k3 = 1;
                }
                // Модель освещенности с одним источником цвета
                float[] light_position = { x, y, z, 0 };                // Координаты источника света
                float[] lghtClr = { 1, 1, 1, 0 };                       // Источник излучает белый цвет
                float[] mtClr = { k1, k2, k3, 0 };                      // Материал зеленого цвета
                Gl.glPolygonMode(Gl.GL_FRONT, Gl.GL_FILL);              // Заливка полигонов
                Gl.glShadeModel(Gl.GL_SMOOTH);                          // Вывод с интерполяцией цветов
                Gl.glEnable(Gl.GL_LIGHTING);                            // Будем рассчитывать освещенность
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_position);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, lghtClr);     // Рассеивание
                Gl.glEnable(Gl.GL_LIGHT0);                              // Включаем в уравнение освещенности источник GL_LIGHT0
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mtClr);     // Диффузионная компонента цвета материала
                showSolid(obj);                                         // Выводим тонированный glut-примитив
                Gl.glDisable(Gl.GL_LIGHTING);                           // Будем рассчитывать освещенность
            }
            Pr.Invalidate();
        }

        /// <summary>
        /// Рисовка конуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            last = 1;
            draw(1); 
        }

        /// <summary>
        /// Рисовка куба
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            last = 2;
            draw(2);
        }

        /// <summary>
        /// Рисовка цилиндра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            last = 3;
            draw(3);
        }

        /// <summary>
        /// Рисовка додекаэдра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            last = 4;
            draw(4);
        }

        /// <summary>
        /// Рисовка икосаэдра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            last = 5;
            draw(5);
        }

        /// <summary>
        /// Рисовка октаэдра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            last = 6;
            draw(6);
        }

        /// <summary>
        /// Рисовка ромбического додекаэдра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            last = 7;
            draw(7);
        }

        /// <summary>
        /// Рисовка Фрактала Губка Серпиского
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            last = 8;
            draw(8);
        }

        /// <summary>
        /// Рисовка сферы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            last = 9;
            draw(9); 
        }

        /// <summary>
        /// Рисовка чайника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            last = 10;
            draw(10);
        }

        /// <summary>
        /// Рисовка тетраэдра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            last = 11;
            draw(11);
        }

        /// <summary>
        /// Рисовка тора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            last = 12;
            draw(12); 
        }

        /// <summary>
        /// Непрерывное вращение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            button13.Text = "Стоп";
            if (continuousMovement == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                button13.Text = "Старт";
            }
            continuousMovement = !continuousMovement;
        }

        /// <summary>
        /// Сдвиг источника света по оси OX влево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            x -= 5;
            draw(last);
        }

        /// <summary>
        /// Сдвиг источника света по оси OX вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            x += 5;
            draw(last);
        }

        /// <summary>
        /// Сдвиг источника света по оси OY вверх
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            y += 5;
            draw(last);
        }

        /// <summary>
        /// Сдвиг источника света по оси OY вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            y -= 5;
            draw(last);
        }

        /// <summary>
        /// Сдвиг источника света по оси OZ вперед
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            z += 5;
            draw(last);
        }

        /// <summary>
        /// Сдвиг источника света по оси OZ назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            z -= 5;
            draw(last);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            alpha += 5;
            draw(last);
            Thread.Sleep(100);
        }

        public Form1()
        {
            InitializeComponent();
            // Инициализация контекста окна графического вывода
            Pr.InitializeContexts();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Черный цвет фона
            Gl.glClearColor(0, 0, 0, 1);
            // Инициализация Glut
            Glut.glutInit();
            // Используем в Glut систему цветов RGB, двойную буферизацию 
            //(экранный и внеэкранный буферы) и буфер глубины
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE |
                Glut.GLUT_DEPTH);
            // Активизируем тест глубины
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            radioButton1.Checked = true;
            radioButton3.Checked = true;
        }
    }
}

/*Контрольные вопросы к лабораторной работе № 7
1. Сущность и назначение OpenGL. 
    OpenGL − это некая спецификация, включающая в себя несколько сотен функций. 
Она определяет независимый от языка программирования кросс-платформенный программный интерфейс, с помощью 
которого программист может создавать приложения, использующие двухмерную и трехмерную компьютерную графику. 

2. Назначение Tao Framework. 
    Tao Framework – это свободно распространяемая библиотека с открытым 
исходным кодом, предназначенная для быстрой и удобной разработки кроссплатформенного 
мультимедийного программного обеспечения в среде .NET Framework и Mono. 
    На сегодняшний день Tao Framework − оптимальный путь для использования библиотеки OpenGL 
при разработке приложений в среде .NET на языке C#.

3. Порядок установки и подключения библиотек TAO. 
    Установка TAO через скачаный exe файл, подключение через «Добавить ссылку» перейдите к закладке «Обзор» и 
нажмите кнопку «Обзор». Перейдите в папку bin и выбираем три библиотеки: Tao.OpenGL.dll, Tao.FreeGlut.dll, Tao.Platform.Windows.dll

4. Поддержка OpenGL в VisualC#. 
    

5. Инициализация OpenGL в C#. 

6. Опишите основные методы преобразования объектов, реализованные в OpenGL.
    
 */