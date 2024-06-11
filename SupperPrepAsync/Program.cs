


namespace SupperPrepAsync
{
	internal class Program
	{
		internal class DinnerTable { }
		internal class Wine { } // pouring wine is a syncronous task - think about it. You start, and finish, and then have a glass of wine.
		internal class Mince { }
		internal class Spagetti { }
		internal class Plate { }


		static async Task Main(string[] args)
		{
			var wine = PourWine(); //  this is syncronous
			Console.WriteLine("Wine done!");

			// next we start the mine making process
			var minceTask = CookMince();
			var spagettiTask = CookSpagetti();

			Mince mince = null;
			Spagetti spagetti = null;

			// checking what's going on in the mince task
			Console.WriteLine($"Mince task status = {minceTask.Status}");


			// the await will wait for the task to complete
			//Mince mince = await minceTask;
			//Console.WriteLine("Mince done!");
			List<Task> supperTasks = new List<Task>() { minceTask, spagettiTask };

			while (supperTasks.Any())
			{
				var completedTask = await Task.WhenAny(supperTasks);

				if (completedTask == minceTask)
				{
					// mince task is complete! (could be success or exception)
					Console.WriteLine($"Mince task status = {minceTask.Status}");
					mince = await (Task<Mince>)completedTask;
					Console.WriteLine("Mince is done!");
				}
				else if (completedTask == spagettiTask)
				{
					// spagetti task complete! (could be success or expception)
					spagetti = await (Task<Spagetti>)completedTask;
					Console.WriteLine("Spagetti is done!");
				}

				// removing task from the task list, as it's completed
				await completedTask;
				supperTasks.Remove(completedTask);
			}

			//if (mince != null && spagetti != null)
			//{
				Plate plate = AssemblePlate(mince, spagetti);
			//}
		}

		private static Plate AssemblePlate(Mince mince,Spagetti spagettiTask)
		{
			Console.WriteLine($"Pplate assembled with mince and spagettie! Enjoy!!");
			return new Plate();
		}

		private static async Task<Spagetti> CookSpagetti()
		{
			Console.WriteLine("Turn on the stove...");
			await Task.Delay(500);
			Console.WriteLine("Put the water on to boil...");
			await Task.Delay(1000);
			Console.WriteLine("Add the spagetti...");
			await Task.Delay(1000);
			Console.WriteLine("Looking el`dente...");

			return new Spagetti();
		}

		private static async Task<Mince> CookMince()
		{
			Console.WriteLine("Turn on the stove...");
			await Task.Delay(500);
			Console.WriteLine("Wait for the pan to heat up...");
			await Task.Delay(5000);
			Console.WriteLine("Fry up the onions...");
			await Task.Delay(1000);
			Console.WriteLine("Cook up the mince...");
			await Task.Delay(1000);
			Console.WriteLine("Okay, things are smelling good over here...");

			return new Mince();
		}

		private static Wine PourWine()
		{
			Console.WriteLine("Pouring wine...");
			return new Wine();
		}
	}
}
