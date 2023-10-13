using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hack_vote2023
{
    public partial class main : Form
    {

        public main()
        {
            InitializeComponent();
            Hide();
        }
        void exec_cmd(string cmd)
        {
            SendKeys.Send(cmd.Replace(Environment.NewLine, ""));
            Console.Beep(200, 200);
            SendKeys.Send("{ENTER}");
            Console.Beep(100, 300);

        }
        void wait(int tempo, int epoch)
        {
            for (int i = 0; i < 15; i++)
            {
                SendKeys.Send("{BS}");
            }
            for (int i = 0; i < tempo; i += 500)
            {
                string txt = epoch.ToString() + "|" + ((float)i / 1000).ToString();
                SendKeys.Send(txt);

                Thread.Sleep(500);

                for (int l = 0; l < txt.Length + 1; l++)
                {
                    SendKeys.Send("{BS}");
                }
            }
        }
        string cords_pausa = "-7 -3 -59";
        int tempo_pausa_curto = 10;//sec

        void small_pause_tp(int epoch)
        {
            var cmd = ".tp " + cords_pausa;
            Console.WriteLine($"[Pausa TP] ->{cmd}");
            exec_cmd(cmd);
            Console.Beep(100, 50);

            wait(tempo_pausa_curto * 1000, epoch);

            Console.Beep(500, 100);
        }
        void Do_parkour(string nom_fich, int i)
        {
            List<string> Dados = File.ReadAllLines(cam + nom_fich).ToList();
            foreach (string dado in Dados)
            {
                if (!dado.StartsWith("!"))
                {
                    var cmd = ".tp " + dado;
                    Console.WriteLine($"[{i}, {nom_fich}] ->{cmd}");
                    exec_cmd(cmd);
                    Thread.Sleep(400);
                }
                Console.WriteLine($"[{i}, {nom_fich}] Conc!");

            }
        }

        string cam = "C:\\Users\\david\\OneDrive\\Documentos\\projectos_csharp\\hack_vote2023\\data\\";

        private void main_Load(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            Console.Beep();
            SendKeys.Send("t");
            Console.Beep(100, 200);//after pressing F5 to run
            var names = new string[] { "penguin.txt" };//penguin gives more money and its completed in less time
            for (int i = 0; i < 50; i++)
            {
                foreach (string name in names)
                {
                    Do_parkour(name, i);
                    Console.Beep(500, 300);
                    Console.Beep(800, 300);
                    Console.Beep(500, 300);
                    small_pause_tp(i);

                }
                Console.WriteLine($"[{i}] Done!");
                Console.WriteLine();
                Console.WriteLine();

            }


        }
    }
}
