using Microsoft.VisualBasic.Devices;
using static WinHomeTaskPattern2.Bridge;

namespace WinHomeTaskPattern2
{
    public partial class Form1 : Form
    {
        private WinHomeTaskPattern2.Bridge.Computer computer;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IComputerImplementation implementation = new DesktopComputerImplementation();
            computer = new DesktopComputer(implementation);
            DisplayResult();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IComputerImplementation implementation = new LaptopImplementation();
            computer = new Laptop(implementation);
            DisplayResult();
        }

        private void DisplayResult()
        {
            if (computer != null)
            {
                string processor = textBox1.Text;
                int memoryGB = int.Parse(textBox2.Text);
                int storageGB = int.Parse(textBox3.Text);
                string graphicsCard = textBox4.Text;
                string result = computer.Assemble(processor, memoryGB, storageGB, graphicsCard);
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Select a computer type first.");
            }
        }
    }
}