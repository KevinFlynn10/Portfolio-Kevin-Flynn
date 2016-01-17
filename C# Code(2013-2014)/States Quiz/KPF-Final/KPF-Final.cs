using System;
using System.Drawing;
using System.Windows.Forms;
class Final : Form
{
    Rectangle[] Rect = new Rectangle[52];
    Rectangle[] srcRect = new Rectangle[52];
    Rectangle[] RP = new Rectangle[11];
    Rectangle Box = new Rectangle(new Point(0, 0), new Size(900, 350));
    Rectangle Box1 = new Rectangle(new Point(160, 408), new Size(220, 50));
    Rectangle Box2 = new Rectangle(new Point(540, 408), new Size(220, 50));
    Rectangle Box3 = new Rectangle(new Point(160, 516), new Size(220, 50));
    Rectangle Box4 = new Rectangle(new Point(540, 516), new Size(220, 50));
    Rectangle Box5 = new Rectangle(new Point(600, 125), new Size(220, 50));
    Rectangle Box6 = new Rectangle(new Point(600, 200), new Size(220, 50));
    Rectangle Box7 = new Rectangle(new Point(600, 275), new Size(220, 50));
    Rectangle Box8 = new Rectangle(new Point(600, 187), new Size(220, 50));
    Rectangle Box9 = new Rectangle(new Point(600, 262), new Size(220, 50));
    Rectangle Box10 = new Rectangle(new Point(600, 337), new Size(220, 50));
    Rectangle Box11 = new Rectangle(new Point(600, 412), new Size(220, 50));
    Rectangle Box12 = new Rectangle(new Point(600, 350), new Size(220, 50));
    Rectangle Box13 = new Rectangle(new Point(650, 25), new Size(220, 50));

    int[] RectX = new int[52];
    int[] RectY = new int[52];
    int[] a = new int[4];
    int j, k, l, m, mouseX, mouseY;
    int right;
    int total = 0;
    int random = 0;
    int totalright = 0;

    String A1, A2, A3, A4;
    String TitleEasy, TitleMedium, TitleMedium1, TitleHard;
    String easy = "Easy";
    String medium = "Medium";
    String hard = "Hard";
    string[] States = new string[52];
    string[] Capitals = new string[52];
    string[] RS = new string[11];

    bool[] correct = new bool[4];
    bool[] placed = new bool[4];
    bool[] statefound = new bool[52];
    bool[] GuessRight = new bool[52];
    bool StartEasy, StartMedium, StartHard, StartReferences, drawn, yes, go;

    Image[] State = new Image[52];
    Image[] StateFlag = new Image[52];

    private ListBox listBox1;
    private ListBox listbox2;

    Random myRandom = new Random();

    static void Main()
    {
        Application.Run(new Final());
    }
    public Final()
    {
        this.Text = "States Quiz";
        this.Top = 200;
        this.Height = 668;
        this.Width = 915;
        this.MaximizeBox = false;
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.EnableNotifyMessage, true);


        correct[0] = false;
        correct[1] = false;
        correct[2] = false;
        correct[3] = false;

        j = myRandom.Next(0, 50);
        k = myRandom.Next(0, 50);
        l = myRandom.Next(0, 50);
        m = myRandom.Next(0, 50);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        
        if (mouseX >= Box5.Left && mouseX <= Box5.Right && mouseY >= Box5.Top && mouseY <= Box5.Bottom && StartEasy == false && StartMedium == false && StartHard == false && StartReferences == false)
        {
            StartHard = false;
            StartMedium = false;
            StartEasy = true;
            this.Refresh();
        }
        else if (mouseX >= Box6.Left && mouseX <= Box6.Right && mouseY >= Box6.Top && mouseY <= Box6.Bottom && StartEasy == false && StartMedium == false && StartHard == false && StartReferences == false)
        {
            StartEasy = false;
            StartHard = false;
            StartMedium = true;
            this.Refresh();
        }
        else if (mouseX >= Box7.Left && mouseX <= Box7.Right && mouseY >= Box7.Top && mouseY <= Box7.Bottom && StartEasy == false && StartMedium == false && StartHard == false && StartReferences == false)
        {
            StartEasy = false;
            StartMedium = false;
            StartHard = true;
            this.Refresh();
        }
        else if (mouseX >= Box12.Left && mouseX <= Box12.Right && mouseY >= Box12.Top && mouseY <= Box12.Bottom && StartEasy == false && StartMedium == false && StartHard == false && StartReferences == false)
        {
            StartEasy = false;
            StartMedium = false;
            StartHard = false;
            StartReferences = true;
            this.Refresh();
        }
        else if (StartReferences == true)
        {
            if (mouseX >= Box13.Left && mouseX <= Box13.Right && mouseY >= Box13.Top && mouseY <= Box13.Bottom)
            {
                StartReferences = false;
                Reset();
            }
        }


        else if (StartEasy == true || StartMedium == true || StartHard == true)
        {
            if (total == 50)
            {
                if (mouseX >= RP[7].Left && mouseX <= RP[7].Right && mouseY >= RP[7].Top && mouseY <= RP[7].Bottom)
                {
                    StartEasy = false;
                    StartMedium = false;
                    StartHard = false;
                    Reset();

                }
                else if (mouseX >= RP[8].Left && mouseX <= RP[8].Right && mouseY >= RP[8].Top && mouseY <= RP[8].Bottom)
                {
                    Reset();
                }
                if (StartEasy == true)
                {
                    if (mouseX >= RP[9].Left && mouseX <= RP[9].Right && mouseY >= RP[9].Top && mouseY <= RP[9].Bottom)
                    {
                        StartEasy = false;
                        StartMedium = true;
                        Reset();
                    }
                    else if (mouseX >= RP[10].Left && mouseX <= RP[10].Right && mouseY >= RP[10].Top && mouseY <= RP[10].Bottom)
                    {
                        StartEasy = false;
                        StartHard = true;
                        Reset();
                    }
                }
                else if (StartMedium == true)
                {
                    if (mouseX >= RP[9].Left && mouseX <= RP[9].Right && mouseY >= RP[9].Top && mouseY <= RP[9].Bottom)
                    {
                        StartEasy = true;
                        StartMedium = false;
                        Reset();
                    }
                    else if (mouseX >= RP[10].Left && mouseX <= RP[10].Right && mouseY >= RP[10].Top && mouseY <= RP[10].Bottom)
                    {
                        StartMedium = false;
                        StartHard = true;
                        Reset();
                    }
                }
                else if (StartHard == true)
                {
                    if (mouseX >= RP[9].Left && mouseX <= RP[9].Right && mouseY >= RP[9].Top && mouseY <= RP[9].Bottom)
                    {
                        StartEasy = true;
                        StartHard = false;
                        Reset();
                    }
                    else if (mouseX >= RP[10].Left && mouseX <= RP[10].Right && mouseY >= RP[10].Top && mouseY <= RP[10].Bottom)
                    {
                        StartMedium = true;
                        StartHard = false;
                        Reset();
                    }
                }
                

            }
            else if (total <= 49)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (total <= 49)
                    {
                        if (mouseX >= RP[i].Left && mouseX <= RP[i].Right && mouseY >= RP[i].Top && mouseY <= RP[i].Bottom)
                        {
                            yes = false;
                            correct[i] = true;
                            checktrue();
                            checkfalse();
                            if (correct[i] == false)
                            {
                                this.Refresh();
                            }
                        }
                    }
                }
            }
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        mouseX = e.X;
        mouseY = e.Y;


        this.Refresh();


    }
    public void checkfalse()
    {
        if (StartEasy == true || StartMedium == true || StartHard == true)
        {
            if (total < 49)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (right != i && correct[i] == true)
                    {
                        statefound[j] = true;
                        GuessRight[j] = false;

                        while (statefound[j] == true)
                        {
                            j = myRandom.Next(0, 50);
                            k = myRandom.Next(0, 50);
                            l = myRandom.Next(0, 50);
                            m = myRandom.Next(0, 50);
                        }

                        total = total + 1;
                        correct[i] = false;

                    }
                }
                if (k == j || k == l || k == m)
                {
                    k = myRandom.Next(0, 50);
                    checkfalse();
                }
                if (l == j || l == m)
                {
                    l = myRandom.Next(0, 50);
                    checkfalse();
                }
                if (m == j)
                {
                    m = myRandom.Next(0, 50);
                    checkfalse();
                }
            }
            else if (total == 49)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (right != i && correct[i] == true)
                    {
                        statefound[j] = true;
                        GuessRight[j] = false;

                        while (statefound[j] == true)
                        {
                            j = 50;
                            k = 50;
                            l = 50;
                            m = 50;
                        }
                        correct[i] = false;
                        total = total + 1;
                    }
                }
            }
        }
    }
    public void checktrue()
    {
        if (StartEasy == true || StartMedium == true || StartHard == true)
        {
            if (total < 49)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (right == i && correct[i] == true)
                    {
                        statefound[j] = true;
                        GuessRight[j] = true;

                        while (statefound[j] == true)
                        {
                            j = myRandom.Next(0, 50);
                            k = myRandom.Next(0, 50);
                            l = myRandom.Next(0, 50);
                            m = myRandom.Next(0, 50);
                        }

                        correct[i] = false;
                        total = total + 1;
                        totalright = totalright + 1;
                    }
                }
                if (k == j || k == l || k == m)
                {
                    k = myRandom.Next(0, 50);
                    checktrue();
                }
                if (l == j || l == m)
                {
                    l = myRandom.Next(0, 50);
                    checktrue();
                }
                if (m == j)
                {
                    m = myRandom.Next(0, 50);
                    checktrue();
                }
            }
            else if (total == 49)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (right == i && correct[i] == true)
                    {
                        statefound[j] = true;
                        GuessRight[j] = true;

                        while (statefound[j] == true)
                        {
                            j = 50;
                            k = 50;
                            l = 50;
                            m = 50;
                        }

                        correct[i] = false;
                        total = total + 1;
                        totalright = totalright + 1;
                    }
                }
            }
        }
    }
    public void DrawBackground(PaintEventArgs e)
    {
        Graphics g;
        g = e.Graphics;

        FontFamily family = new FontFamily("Times New Roman");
        Font fonts = new Font(family, 16.0f, FontStyle.Bold | FontStyle.Italic);
        Font fonts2 = new Font(family, 24.0f, FontStyle.Italic);

        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
        StringFormat format2 = new StringFormat(format1);

        format1.LineAlignment = StringAlignment.Center;
        format1.Alignment = StringAlignment.Center;
        format2.Alignment = StringAlignment.Center;

        String end = "You scored " + totalright + " out of 50!";

        TitleEasy = "Can You Guess the State? (" + (total + 1) + "/50)";
        TitleMedium = "Can You Guess the Capital of ";
        TitleMedium1 = States[j] + "? (" + (total + 1) + "/50)";

        TitleHard = "Can You Guess the Flag? (" + (total + 1) + "/50)";

        bool[] placed = new bool[4];

        g.FillRectangle(Brushes.White, Box);
        g.FillRectangle(Brushes.Red, 0, 0, 150, 350);
        g.FillRectangle(Brushes.Red, 750, 0, 150, 350);
        g.FillRectangle(Brushes.White, 50, 0, 50, 350);
        g.FillRectangle(Brushes.White, 800, 0, 50, 350);

        if (total <= 49 && StartEasy == true)
        {
            A1 = States[j];
            A2 = States[k];
            A3 = States[l];
            A4 = States[m];
        }
        else if (total <= 49 && StartMedium == true)
        {
            A1 = Capitals[j];
            A2 = Capitals[k];
            A3 = Capitals[l];
            A4 = Capitals[m];
        }
        else if (total <= 49 && StartHard == true)
        {
            A1 = States[j];
            A2 = States[k];
            A3 = States[l];
            A4 = States[m];
        }



        RS[0] = A1;
        RS[1] = A2;
        RS[2] = A3;
        RS[3] = A4;

        RP[0] = Box1;
        RP[1] = Box2;
        RP[2] = Box3;
        RP[3] = Box4;


        if (total <= 49)
        {
            if (StartEasy == true)
            {
                RectX[j] = 300;
                RectY[j] = -25;
                srcRect[j] = new Rectangle(0, 0, 612, 792);
                Rect[j] = new Rectangle(RectX[j], RectY[j], 300, 388);
                g.DrawImage(State[j], Rect[j], srcRect[j], GraphicsUnit.Pixel);
                g.DrawString(TitleEasy, fonts, Brushes.Navy, Box, format2);
            }
            else if (StartMedium == true)
            {
                RectX[j] = 300;
                RectY[j] = -25;
                srcRect[j] = new Rectangle(0, 0, 612, 792);
                Rect[j] = new Rectangle(RectX[j], RectY[j], 300, 388);
                g.DrawImage(State[j], Rect[j], srcRect[j], GraphicsUnit.Pixel);
                g.DrawString(TitleMedium, fonts, Brushes.Navy, Box, format2);
                g.DrawString(TitleMedium1, fonts, Brushes.Navy, 450, 30, format2);
            }
            else if (StartHard == true)
            {
                RectX[j] = 300;
                RectY[j] = 86;
                srcRect[j] = new Rectangle(0, 0, 384, 256);
                Rect[j] = new Rectangle(RectX[j], RectY[j], 300, 179);
                g.DrawImage(StateFlag[j], Rect[j], srcRect[j], GraphicsUnit.Pixel);
                g.DrawString(TitleHard, fonts, Brushes.Navy, Box, format2);
            }
        }


        g.FillRectangle(Brushes.Navy, 0, 350, 900, 275);

        random = myRandom.Next(0, 4);

        if (yes == false)
        {
            for (int i = 0; i < 4; i++)
            {
                while (placed[random] == true)
                {
                    random = myRandom.Next(0, 4);
                }
                placed[random] = true;

                a[i] = random;
            }
            yes = true;
        }

        for (int i = 0; i < 4; i++)
        {
            if (total <= 49)
            {
                g.FillRectangle(Brushes.White, RP[i]);
                if (mouseX >= RP[i].Left && mouseX <= RP[i].Right && mouseY >= RP[i].Top && mouseY <= RP[i].Bottom)
                {
                    g.FillRectangle(Brushes.Yellow, RP[i]);
                }
                g.DrawString(RS[a[i]], fonts, Brushes.Navy, (RectangleF)RP[i], format1);
            }
            else
            {
                g.FillRectangle(Brushes.White, RP[i]);
                if (mouseX >= RP[i].Left && mouseX <= RP[i].Right && mouseY >= RP[i].Top && mouseY <= RP[i].Bottom)
                {
                    g.FillRectangle(Brushes.Yellow, RP[i]);
                }
                g.DrawString(RS[i], fonts, Brushes.Navy, (RectangleF)RP[i], format1);
            }

            if (a[i] == 0)
            {
                right = i;
            }
        }
        g.FillRectangle(Brushes.Red, 160, 408, 20, 50);
        g.FillRectangle(Brushes.Red, 540, 408, 20, 50);
        g.FillRectangle(Brushes.Red, 360, 408, 20, 50);
        g.FillRectangle(Brushes.Red, 740, 408, 20, 50);
        g.FillRectangle(Brushes.Red, 160, 516, 20, 50);
        g.FillRectangle(Brushes.Red, 540, 516, 20, 50);
        g.FillRectangle(Brushes.Red, 360, 516, 20, 50);
        g.FillRectangle(Brushes.Red, 740, 516, 20, 50);
        g.FillRectangle(Brushes.Red, 200, 0, 50, 350);
        g.FillRectangle(Brushes.Red, 650, 0, 50, 350);
        g.FillRectangle(Brushes.LightBlue, 0, 374, 900, 10);
        g.FillRectangle(Brushes.LightBlue, 0, 590, 900, 10);
    }
    public void DrawStates(PaintEventArgs e)
    {
        Graphics g;
        g = e.Graphics;

        Image Alabama, Alaska, Arizona, Arkansas, California,
                Colorado, Connecticut, Delaware, Florida, Georgia,
                Hawaii, Idaho, Illinois, Indiana, Iowa, Kansas,
                Kentucky, Louisiana, Maine, Maryland, Massachusetts,
                Michigan, Minnesota, Mississippi, Missouri, Montana,
                Nebraska, Nevada, New_Hampshire, New_Jersey, New_Mexico,
                New_York, North_Carolina, North_Dakota, Ohio, Oklahoma,
                Oregon, Pennsylvania, Rhode_Island, South_Carolina,
                South_Dakota, Tennessee, Texas, Utah, Vermont, Virginia,
                Washington, West_Virginia, Wisconsin, Wyoming;

        Image Alabama1, Alaska1, Arizona1, Arkansas1, California1,
                Colorado1, Connecticut1, Delaware1, Florida1, Georgia1,
                Hawaii1, Idaho1, Illinois1, Indiana1, Iowa1, Kansas1,
                Kentucky1, Louisiana1, Maine1, Maryland1, Massachusetts1,
                Michigan1, Minnesota1, Mississippi1, Missouri1, Montana1,
                Nebraska1, Nevada1, New_Hampshire1, New_Jersey1, New_Mexico1,
                New_York1, North_Carolina1, North_Dakota1, Ohio1, Oklahoma1,
                Oregon1, Pennsylvania1, Rhode_Island1, South_Carolina1,
                South_Dakota1, Tennessee1, Texas1, Utah1, Vermont1, Virginia1,
                Washington1, West_Virginia1, Wisconsin1, Wyoming1;

        //string dir = Path.GetDirectoryName(Application.ExecutablePath);
        //string filename = Path.Combine(dir, @"MyImage.jpg");

        Alabama = Image.FromFile(@"50 States\Alabama.gif");
        Alaska = Image.FromFile(@"50 States\alaska.gif");
        Arizona = Image.FromFile(@"50 States\Arizona.gif");
        Arkansas = Image.FromFile(@"50 States\Arkansas.gif");
        California = Image.FromFile(@"50 States\California.gif");
        Colorado = Image.FromFile(@"50 States\Colorado.gif");
        Connecticut = Image.FromFile(@"50 States\Connecticut.gif");
        Delaware = Image.FromFile(@"50 States\Delaware.gif");
        Florida = Image.FromFile(@"50 States\Florida.gif");
        Georgia = Image.FromFile(@"50 States\Georgia.gif");
        Hawaii = Image.FromFile(@"50 States\Hawaii.gif");
        Idaho = Image.FromFile(@"50 States\Idaho.gif");
        Illinois = Image.FromFile(@"50 States\Illinois.gif");
        Indiana = Image.FromFile(@"50 States\Indiana.gif");
        Iowa = Image.FromFile(@"50 States\Iowa.gif");
        Kansas = Image.FromFile(@"50 States\Kansas.gif");
        Kentucky = Image.FromFile(@"50 States\Kentucky.gif");
        Louisiana = Image.FromFile(@"50 States\Louisiana.gif");
        Maine = Image.FromFile(@"50 States\Maine.gif");
        Maryland = Image.FromFile(@"50 States\Maryland.gif");
        Massachusetts = Image.FromFile(@"50 States\Massachusetts.gif");
        Michigan = Image.FromFile(@"50 States\Michigan.gif");
        Minnesota = Image.FromFile(@"50 States\Minnesota.gif");
        Mississippi = Image.FromFile(@"50 States\Mississippi.gif");
        Missouri = Image.FromFile(@"50 States\Missouri.gif");
        Montana = Image.FromFile(@"50 States\Montana.gif");
        Nebraska = Image.FromFile(@"50 States\Nebraska.gif");
        Nevada = Image.FromFile(@"50 States\Nevada.gif");
        New_Hampshire = Image.FromFile(@"50 States\New_Hampshire.gif");
        New_Jersey = Image.FromFile(@"50 States\New_Jersey.gif");
        New_Mexico = Image.FromFile(@"50 States\New_Mexico.gif");
        New_York = Image.FromFile(@"50 States\New_York.gif");
        North_Carolina = Image.FromFile(@"50 States\North_Carolina.gif");
        North_Dakota = Image.FromFile(@"50 States\North_Dakota.gif");
        Ohio = Image.FromFile(@"50 States\Ohio.gif");
        Oklahoma = Image.FromFile(@"50 States\Oklahoma.gif");
        Oregon = Image.FromFile(@"50 States\Oregon.gif");
        Pennsylvania = Image.FromFile(@"50 States\Pennsylvania.gif");
        Rhode_Island = Image.FromFile(@"50 States\Rhode_Island.gif");
        South_Carolina = Image.FromFile(@"50 States\South_Carolina.gif");
        South_Dakota = Image.FromFile(@"50 States\South_Dakota.gif");
        Tennessee = Image.FromFile(@"50 States\Tennessee.gif");
        Texas = Image.FromFile(@"50 States\Texas.gif");
        Utah = Image.FromFile(@"50 States\Utah.gif");
        Vermont = Image.FromFile(@"50 States\Vermont.gif");
        Virginia = Image.FromFile(@"50 States\Virginia.gif");
        Washington = Image.FromFile(@"50 States\Washington.gif");
        West_Virginia = Image.FromFile(@"50 States\West_Virginia.gif");
        Wisconsin = Image.FromFile(@"50 States\Wisconsin.gif");
        Wyoming = Image.FromFile(@"50 States\Wyoming.gif");

        Alabama1 = Image.FromFile(@"50 States\Alabamaflag.gif");
        Alaska1 = Image.FromFile(@"50 States\alaskaflag.gif");
        Arizona1 = Image.FromFile(@"50 States\Arizonaflag.gif");
        Arkansas1 = Image.FromFile(@"50 States\Arkansasflag.gif");
        California1 = Image.FromFile(@"50 States\Californiaflag.gif");
        Colorado1 = Image.FromFile(@"50 States\Coloradoflag.gif");
        Connecticut1 = Image.FromFile(@"50 States\Connecticutflag.gif");
        Delaware1 = Image.FromFile(@"50 States\Delawareflag.gif");
        Florida1 = Image.FromFile(@"50 States\Floridaflag.gif");
        Georgia1 = Image.FromFile(@"50 States\Georgiaflag.gif");
        Hawaii1 = Image.FromFile(@"50 States\Hawaiiflag.gif");
        Idaho1 = Image.FromFile(@"50 States\Idahoflag.gif");
        Illinois1 = Image.FromFile(@"50 States\Illinoisflag.gif");
        Indiana1 = Image.FromFile(@"50 States\Indianaflag.gif");
        Iowa1 = Image.FromFile(@"50 States\Iowaflag.gif");
        Kansas1 = Image.FromFile(@"50 States\Kansasflag.gif");
        Kentucky1 = Image.FromFile(@"50 States\Kentuckyflag.gif");
        Louisiana1 = Image.FromFile(@"50 States\Louisianaflag.gif");
        Maine1 = Image.FromFile(@"50 States\Maineflag.gif");
        Maryland1 = Image.FromFile(@"50 States\Marylandflag.gif");
        Massachusetts1 = Image.FromFile(@"50 States\Massachusettsflag.gif");
        Michigan1 = Image.FromFile(@"50 States\Michiganflag.gif");
        Minnesota1 = Image.FromFile(@"50 States\Minnesotaflag.gif");
        Mississippi1 = Image.FromFile(@"50 States\Mississippiflag.gif");
        Missouri1 = Image.FromFile(@"50 States\Missouriflag.gif");
        Montana1 = Image.FromFile(@"50 States\Montanaflag.gif");
        Nebraska1 = Image.FromFile(@"50 States\Nebraskaflag.gif");
        Nevada1 = Image.FromFile(@"50 States\Nevadaflag.gif");
        New_Hampshire1 = Image.FromFile(@"50 States\New_Hampshireflag.gif");
        New_Jersey1 = Image.FromFile(@"50 States\New_Jerseyflag.gif");
        New_Mexico1 = Image.FromFile(@"50 States\New_Mexicoflag.gif");
        New_York1 = Image.FromFile(@"50 States\New_Yorkflag.gif");
        North_Carolina1 = Image.FromFile(@"50 States\North_Carolinaflag.gif");
        North_Dakota1 = Image.FromFile(@"50 States\North_Dakotaflag.gif");
        Ohio1 = Image.FromFile(@"50 States\Ohioflag.gif");
        Oklahoma1 = Image.FromFile(@"50 States\Oklahomaflag.gif");
        Oregon1 = Image.FromFile(@"50 States\Oregonflag.gif");
        Pennsylvania1 = Image.FromFile(@"50 States\Pennsylvaniaflag.gif");
        Rhode_Island1 = Image.FromFile(@"50 States\Rhode_Islandflag.gif");
        South_Carolina1 = Image.FromFile(@"50 States\South_Carolinaflag.gif");
        South_Dakota1 = Image.FromFile(@"50 States\South_Dakotaflag.gif");
        Tennessee1 = Image.FromFile(@"50 States\Tennesseeflag.gif");
        Texas1 = Image.FromFile(@"50 States\Texasflag.gif");
        Utah1 = Image.FromFile(@"50 States\Utahflag.gif");
        Vermont1 = Image.FromFile(@"50 States\Vermontflag.gif");
        Virginia1 = Image.FromFile(@"50 States\Virginiaflag.gif");
        Washington1 = Image.FromFile(@"50 States\Washingtonflag.gif");
        West_Virginia1 = Image.FromFile(@"50 States\West_Virginiaflag.gif");
        Wisconsin1 = Image.FromFile(@"50 States\Wisconsinflag.gif");
        Wyoming1 = Image.FromFile(@"50 States\Wyomingflag.gif");


        State[0] = Alabama;
        State[1] = Alaska;
        State[2] = Arizona;
        State[3] = Arkansas;
        State[4] = California;
        State[5] = Colorado;
        State[6] = Connecticut;
        State[7] = Delaware;
        State[8] = Florida;
        State[9] = Georgia;
        State[10] = Hawaii;
        State[11] = Idaho;
        State[12] = Illinois;
        State[13] = Indiana;
        State[14] = Iowa;
        State[15] = Kansas;
        State[16] = Kentucky;
        State[17] = Louisiana;
        State[18] = Maine;
        State[19] = Maryland;
        State[20] = Massachusetts;
        State[21] = Michigan;
        State[22] = Minnesota;
        State[23] = Mississippi;
        State[24] = Missouri;
        State[25] = Montana;
        State[26] = Nebraska;
        State[27] = Nevada;
        State[28] = New_Hampshire;
        State[29] = New_Jersey;
        State[30] = New_Mexico;
        State[31] = New_York;
        State[32] = North_Carolina;
        State[33] = North_Dakota;
        State[34] = Ohio;
        State[35] = Oklahoma;
        State[36] = Oregon;
        State[37] = Pennsylvania;
        State[38] = Rhode_Island;
        State[39] = South_Carolina;
        State[40] = South_Dakota;
        State[41] = Tennessee;
        State[42] = Texas;
        State[43] = Utah;
        State[44] = Vermont;
        State[45] = Virginia;
        State[46] = Washington;
        State[47] = West_Virginia;
        State[48] = Wisconsin;
        State[49] = Wyoming;

        StateFlag[0] = Alabama1;
        StateFlag[1] = Alaska1;
        StateFlag[2] = Arizona1;
        StateFlag[3] = Arkansas1;
        StateFlag[4] = California1;
        StateFlag[5] = Colorado1;
        StateFlag[6] = Connecticut1;
        StateFlag[7] = Delaware1;
        StateFlag[8] = Florida1;
        StateFlag[9] = Georgia1;
        StateFlag[10] = Hawaii1;
        StateFlag[11] = Idaho1;
        StateFlag[12] = Illinois1;
        StateFlag[13] = Indiana1;
        StateFlag[14] = Iowa1;
        StateFlag[15] = Kansas1;
        StateFlag[16] = Kentucky1;
        StateFlag[17] = Louisiana1;
        StateFlag[18] = Maine1;
        StateFlag[19] = Maryland1;
        StateFlag[20] = Massachusetts1;
        StateFlag[21] = Michigan1;
        StateFlag[22] = Minnesota1;
        StateFlag[23] = Mississippi1;
        StateFlag[24] = Missouri1;
        StateFlag[25] = Montana1;
        StateFlag[26] = Nebraska1;
        StateFlag[27] = Nevada1;
        StateFlag[28] = New_Hampshire1;
        StateFlag[29] = New_Jersey1;
        StateFlag[30] = New_Mexico1;
        StateFlag[31] = New_York1;
        StateFlag[32] = North_Carolina1;
        StateFlag[33] = North_Dakota1;
        StateFlag[34] = Ohio1;
        StateFlag[35] = Oklahoma1;
        StateFlag[36] = Oregon1;
        StateFlag[37] = Pennsylvania1;
        StateFlag[38] = Rhode_Island1;
        StateFlag[39] = South_Carolina1;
        StateFlag[40] = South_Dakota1;
        StateFlag[41] = Tennessee1;
        StateFlag[42] = Texas1;
        StateFlag[43] = Utah1;
        StateFlag[44] = Vermont1;
        StateFlag[45] = Virginia1;
        StateFlag[46] = Washington1;
        StateFlag[47] = West_Virginia1;
        StateFlag[48] = Wisconsin1;
        StateFlag[49] = Wyoming1;


        States[0] = "Alabama";
        States[1] = "Alaska";
        States[2] = "Arizona";
        States[3] = "Arkansas";
        States[4] = "California";
        States[5] = "Colorado";
        States[6] = "Connecticut";
        States[7] = "Delaware";
        States[8] = "Florida";
        States[9] = "Georgia";
        States[10] = "Hawaii";
        States[11] = "Idaho";
        States[12] = "Illinois";
        States[13] = "Indiana";
        States[14] = "Iowa";
        States[15] = "Kansas";
        States[16] = "Kentucky";
        States[17] = "Louisiana";
        States[18] = "Maine";
        States[19] = "Maryland";
        States[20] = "Massachusetts";
        States[21] = "Michigan";
        States[22] = "Minnesota";
        States[23] = "Mississippi";
        States[24] = "Missouri";
        States[25] = "Montana";
        States[26] = "Nebraska";
        States[27] = "Nevada";
        States[28] = "New Hampshire";
        States[29] = "New Jersey";
        States[30] = "New Mexico";
        States[31] = "New York";
        States[32] = "North Carolina";
        States[33] = "North Dakota";
        States[34] = "Ohio";
        States[35] = "Oklahoma";
        States[36] = "Oregon";
        States[37] = "Pennsylvania";
        States[38] = "Rhode Island";
        States[39] = "South Carolina";
        States[40] = "South Dakota";
        States[41] = "Tennessee";
        States[42] = "Texas";
        States[43] = "Utah";
        States[44] = "Vermont";
        States[45] = "Virginia";
        States[46] = "Washington";
        States[47] = "West Virginia";
        States[48] = "Wisconsin";
        States[49] = "Wyoming";


        Capitals[0] = "Montgomery";
        Capitals[1] = "Juneau";
        Capitals[2] = "Phoenix";
        Capitals[3] = "Little Rock";
        Capitals[4] = "Sacramento";
        Capitals[5] = "Denver";
        Capitals[6] = "Hartford";
        Capitals[7] = "Dover";
        Capitals[8] = "Tallahassee";
        Capitals[9] = "Atlanta";
        Capitals[10] = "Honolulu";
        Capitals[11] = "Boise";
        Capitals[12] = "Springfield";
        Capitals[13] = "Indianapolis";
        Capitals[14] = "Des Moines";
        Capitals[15] = "Topeka";
        Capitals[16] = "Frankfort";
        Capitals[17] = "Baton Rouge";
        Capitals[18] = "Augusta";
        Capitals[19] = "Annapolis";
        Capitals[20] = "Boston";
        Capitals[21] = "Lansing";
        Capitals[22] = "Saint Paul";
        Capitals[23] = "Jackson";
        Capitals[24] = "Jefferson City";
        Capitals[25] = "Helena";
        Capitals[26] = "Lincoln";
        Capitals[27] = "Carson City";
        Capitals[28] = "Concord";
        Capitals[29] = "Trenton";
        Capitals[30] = "Santa Fe";
        Capitals[31] = "Albany";
        Capitals[32] = "Raleigh";
        Capitals[33] = "Bismarck";
        Capitals[34] = "Columbus";
        Capitals[35] = "Oklahoma City";
        Capitals[36] = "Salem";
        Capitals[37] = "Harrisburg";
        Capitals[38] = "Providence";
        Capitals[39] = "Columbia";
        Capitals[40] = "Pierre";
        Capitals[41] = "Nashville";
        Capitals[42] = "Austin";
        Capitals[43] = "Salt Lake City";
        Capitals[44] = "Montpelier";
        Capitals[45] = "Richmond";
        Capitals[46] = "Olympia";
        Capitals[47] = "Charleston";
        Capitals[48] = "Madison";
        Capitals[49] = "Cheyenne";
    }
    public void Reset()
    {
        total = 0;
        totalright = 0;
        j = myRandom.Next(0, 50);
        k = myRandom.Next(0, 50);
        l = myRandom.Next(0, 50);
        m = myRandom.Next(0, 50);

        correct[0] = false;
        correct[1] = false;
        correct[2] = false;
        correct[3] = false;

        for (int a = 0; a < 52; a++)
        {
            statefound[a] = false;
            GuessRight[a] = false;
        }

        go = false;
        this.Controls.Remove(this.listBox1);
        this.Controls.Remove(this.listbox2);
        
        this.Refresh();

    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g;
        g = e.Graphics;

        FontFamily family = new FontFamily("Times New Roman");
        Font fonts = new Font(family, 16.0f, FontStyle.Bold | FontStyle.Italic);
        Font fonts2 = new Font(family, 24.0f, FontStyle.Italic);

        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
        StringFormat format2 = new StringFormat(format1);

        format1.LineAlignment = StringAlignment.Center;
        format1.Alignment = StringAlignment.Center;
        format2.Alignment = StringAlignment.Near;

        string t = Convert.ToString(total);
        Point origin = new Point(0, 0);



        if (total <= 49)
        {
            if (drawn == false)
            {
                DrawStates(e);
                drawn = true;
            }
            if (StartEasy == true)
            {
                DrawBackground(e);
            }
            else if (StartMedium == true)
            {
                DrawBackground(e);
            }
            else if (StartHard == true)
            {
                DrawBackground(e);
            }
            else if (StartReferences == true)
            {
                g.FillRectangle(Brushes.Navy, 0, 0, 900, 630);
                g.FillRectangle(Brushes.White, 0, 100, 900, 420);
                g.DrawString("Created By:", fonts2, Brushes.Black, 50, 125);
                g.DrawString("Kevin Flynn".PadLeft(100, ' '), fonts, Brushes.Black, 100, 175);
                g.DrawString("Images From:", fonts2, Brushes.Black, 50, 300);
                g.DrawString("http://www.50states.com/".PadLeft(91, ' '), fonts, Brushes.Black, 100, 350);
                g.DrawString("http://web-backgrounds.net/".PadLeft(88, ' '), fonts, Brushes.Black, 100, 400);

                g.FillRectangle(Brushes.White, Box13);



                if (mouseX >= Box13.Left && mouseX <= Box13.Right && mouseY >= Box13.Top && mouseY <= Box13.Bottom)
                {
                    g.FillRectangle(Brushes.Yellow, Box13);
                }

                g.DrawString("Main Menu", fonts, Brushes.Navy, (RectangleF)Box13, format1);
                g.FillRectangle(Brushes.Red, 650, 25, 20, 50);
                g.FillRectangle(Brushes.Red, 850, 25, 20, 50);

                
            }

            else if (StartEasy == false && StartMedium == false && StartHard == false && StartReferences == false)
            {

                Image menu;
                menu = Image.FromFile(@"50 States\menu.jpg");

                RP[4] = Box5;
                RP[5] = Box6;
                RP[6] = Box7;

                State[51] = menu;
                RectX[51] = 0;
                RectY[51] = 0;
                srcRect[51] = new Rectangle(0, 0, 500, 300);
                Rect[51] = new Rectangle(RectX[51], RectY[51], 900, 625);
                g.DrawImage(State[51], Rect[51], srcRect[51], GraphicsUnit.Pixel);

                g.FillRectangle(Brushes.White, Box5);
                g.FillRectangle(Brushes.White, Box6);
                g.FillRectangle(Brushes.White, Box7);
                g.FillRectangle(Brushes.White, Box12);

                for (int i = 4; i < 7; i++)
                {
                    if (mouseX >= RP[i].Left && mouseX <= RP[i].Right && mouseY >= RP[i].Top && mouseY <= RP[i].Bottom)
                    {
                        g.FillRectangle(Brushes.Yellow, RP[i]);
                    }
                }

                if (mouseX >= Box12.Left && mouseX <= Box12.Right && mouseY >= Box12.Top && mouseY <= Box12.Bottom && StartEasy == false && StartMedium == false && StartHard == false)
                {
                    g.FillRectangle(Brushes.Yellow, Box12);
                }

                g.FillRectangle(Brushes.Red, 600, 125, 20, 50);
                g.FillRectangle(Brushes.Red, 800, 125, 20, 50);
                g.FillRectangle(Brushes.Red, 600, 200, 20, 50);
                g.FillRectangle(Brushes.Red, 800, 200, 20, 50);
                g.FillRectangle(Brushes.Red, 600, 275, 20, 50);
                g.FillRectangle(Brushes.Red, 800, 275, 20, 50);
                g.FillRectangle(Brushes.Red, 600, 350, 20, 50);
                g.FillRectangle(Brushes.Red, 800, 350, 20, 50);

                format1.LineAlignment = StringAlignment.Center;
                format1.Alignment = StringAlignment.Center;

                g.DrawString(easy, fonts, Brushes.Navy, (RectangleF)Box5, format1);
                g.DrawString(medium, fonts, Brushes.Navy, (RectangleF)Box6, format1);
                g.DrawString(hard, fonts, Brushes.Navy, (RectangleF)Box7, format1);
                g.DrawString("References", fonts, Brushes.Navy, (RectangleF)Box12, format1);
                g.DrawString("Do You Know the United States?", fonts2, Brushes.White, 325, 50, format2);
            }
        }
        else if (total == 50)
        {
            if (total == 50 && StartEasy == true)
            {
                A1 = "Main Menu";
                A2 = "Play Again";
                A3 = "Medium";
                A4 = "Hard";
            }
            else if (total == 50 && StartMedium == true)
            {
                A1 = "Main Menu";
                A2 = "Play Again";
                A3 = "Easy";
                A4 = "Hard";
            }
            else if (total == 50 && StartHard == true)
            {
                A1 = "Main Menu";
                A2 = "Play Again";
                A3 = "Easy";
                A4 = "Medium";
            }



            RS[7] = A1;
            RS[8] = A2;
            RS[9] = A3;
            RS[10] = A4;

            RP[7] = Box8;
            RP[8] = Box9;
            RP[9] = Box10;
            RP[10] = Box11;

            g.FillRectangle(Brushes.Navy, 0, 0, 900, 625);
            g.FillRectangle(Brushes.White, 0, 525, 900, 25);
            g.FillRectangle(Brushes.Red, 0, 100, 900, 25);

            g.FillRectangle(Brushes.Red, 55, 187, 190, 275);
            g.FillRectangle(Brushes.Red, 275, 187, 190, 275);
            g.FillRectangle(Brushes.LightBlue, 515, 187, 20, 275);
            

            g.DrawString("Final Results", fonts2, Brushes.White, 450, 50, format1);
            g.DrawString("Correct (" + totalright + ")", fonts, Brushes.White, 150, 167, format1);
            g.DrawString("Incorrect (" + (50 - totalright) + ")", fonts, Brushes.White, 370, 167, format1);

            for (int i = 7; i < 11; i++)
            {
                g.FillRectangle(Brushes.White, RP[i]);
                if (mouseX >= RP[i].Left && mouseX <= RP[i].Right && mouseY >= RP[i].Top && mouseY <= RP[i].Bottom)
                {
                    g.FillRectangle(Brushes.Yellow, RP[i]);
                }
                g.DrawString(RS[i], fonts, Brushes.Navy, (RectangleF)RP[i], format1);
            }

            g.FillRectangle(Brushes.Red, 600, 187, 20, 50);
            g.FillRectangle(Brushes.Red, 800, 187, 20, 50);
            g.FillRectangle(Brushes.Red, 600, 262, 20, 50);
            g.FillRectangle(Brushes.Red, 800, 262, 20, 50);
            g.FillRectangle(Brushes.Red, 600, 337, 20, 50);
            g.FillRectangle(Brushes.Red, 800, 337, 20, 50);
            g.FillRectangle(Brushes.Red, 600, 412, 20, 50);
            g.FillRectangle(Brushes.Red, 800, 412, 20, 50);

            if (go == false)
            {
                InitializeComponent();
                go = true;
            }

             
        }
    }
    private void InitializeComponent()
    {
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.listbox2 = new System.Windows.Forms.ListBox();
        this.SuspendLayout();
        // 
        // listBox1
        // 
        this.listBox1.FormattingEnabled = true;
        this.listBox1.ItemHeight = 16;
        this.listBox1.Location = new System.Drawing.Point(275, 202);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(190, 250);
        this.listBox1.TabIndex = 0;
        // 
        // listbox2
        // 
        this.listbox2.FormattingEnabled = true;
        this.listbox2.ItemHeight = 16;
        this.listbox2.Location = new System.Drawing.Point(55, 202);
        this.listbox2.Name = "listbox2";
        this.listbox2.Size = new System.Drawing.Size(190, 250);
        this.listbox2.TabIndex = 1;
        // 
        // Final
        // 

        this.Controls.Add(this.listbox2);
        this.Controls.Add(this.listBox1);
        
        this.Name = "Final";
        this.ResumeLayout(false);


        for (int i = 0; i < 50; i++)
        {
            if (StartEasy == true || StartHard == true)
            {
                if (GuessRight[i] == false)
                {
                    listBox1.Items.Add(States[i]);
                }
                else if (GuessRight[i] == true)
                {
                    listbox2.Items.Add(States[i]);
                }
            }
            else if (StartMedium == true)
            {
                if (GuessRight[i] == false)
                {
                    listBox1.Items.Add(Capitals[i] + ", " + States[i]);
                }
                else if (GuessRight[i] == true)
                {
                    listbox2.Items.Add(Capitals[i] + ", " +States[i]);
                }
            }
        }
    }
}



