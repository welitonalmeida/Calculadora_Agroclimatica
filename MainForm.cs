using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Calculadora_Agroclimática
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			//Dia de ordem do ano
			
		}
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			//Latitude
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			//Botão 'Calcular'
			
			try
			{
				label3.ResetText();
				
				//Cálculo da declinação solar:
				//Equação: declinação=23,45*Sen((360/365)*(284+doa))      "doa = Dia de ordem do ano"
				
				int doa = Convert.ToInt16(textBox1.Text);
				int num1 = 284 + doa;
				float num2 = 0.986301369f;
				float num3 = (num1 * num2);
				double num4 = Convert.ToDouble(num3);
				double seno = Math.Sin((Math.PI) * (num4 / 180.0));
				double declinação = seno * 23.45;
				
				//Cálculo das horas/luz para o dia:
				//Equação: horas=(2/15)*Acos(-Tan(latitude)*Tan(declinação))
				
				double latitude = Convert.ToDouble(textBox2.Text);
				double num5 = (-Math.Tan((Math.PI) * (latitude / 180.0)));
				double num6 = (Math.Tan((Math.PI) * (declinação / 180.0)));
				double num7 = (num5 * num6);
				double num8 = (Math.Acos(num7) * (180 / Math.PI));
				float num9 = 0.1333333f;
				double num10 = num9;
				double horas = (num8 * num9);
				
				//Escreve na label3 a declinação:
				label3.Text=label3.Text+"Resultados: " + "\n" + "A declinação solar para o " + doa + "° dia é: " + Math.Round(declinação, 4) + "°" + "\n";
				
				//Escreve na label3 o números de horas de luz:
				label3.Text=label3.Text+ "A duração astronômica do " + doa + "° dia é: " + Math.Round(horas, 2) + " horas.";
				
			}
			catch(Exception){
				MessageBox.Show("ERRO");
			}
		}
		void Label3Click(object sender, EventArgs e)
		{
			//Caixa de saída dos resultados
		}
	}
}
