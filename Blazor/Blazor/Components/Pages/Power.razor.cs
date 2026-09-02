namespace Blazor.Components.Pages
{
	public partial class Power
	{
		double baseValue;
		double exponent;
		string result = string.Empty;
		void Calculate()
		{
			double calcResult = Math.Pow(baseValue, exponent);
			result = calcResult.ToString("G15"); //Форматирование "G15" убирает лишние нули и предотвращает длинную запись
		}
	}
}
