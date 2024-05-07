using System.Collections.Concurrent;

namespace BackgroundDemoApp
{
	public class SampleData
	{
		// pretending this is the cache
		// ConcurrentBag - thread-safe collection of unordered objects
		public ConcurrentBag<string> Data { get; set; } = new ConcurrentBag<string>();

	}
}
