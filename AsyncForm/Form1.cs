using System.Runtime.CompilerServices;

namespace AsyncForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private async Task<int> CalculateBigNumber()
		{
			await Task.Delay(5000);
			return 1000000;
		}

		private string DecypherBigString()
		{
			return "looooong string...";
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			Task<int> bigNumberTask = Task.Run(() => CalculateBigNumber());
			label1.Text = "Calculating big number...";
			button1.Enabled = false;

			int bigNumber = await bigNumberTask;
			label1.Text = bigNumber.ToString();
			button1.Enabled = true;
		}
	}
}
